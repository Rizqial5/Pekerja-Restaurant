using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestPR.NPC;
using TMPro;

namespace TestPR.Core
{
    public class QueueSystem : MonoBehaviour
    {
        [SerializeField] private GameObject customerPrefab; 
        [SerializeField] private Transform queueStartPoint; 
        [SerializeField] private Transform[] queuePoints; 

        [SerializeField] private float customerArrivalInterval = 5f; 
        [SerializeField] private float serviceTime = 10f; 
        [SerializeField] private int maxCustomers = 4; 
        

        private int totalCustomer;
        private int totalAngryCustomer;
        private int totalSuccesfullyOrder;

        private Queue<Customer> customerQueue = new Queue<Customer>();
        private float timer = 0f;
        private int customerID = 1;
        

        void Start()
        {
            //InvokeRepeating("GenerateCustomer", customerArrivalInterval, customerArrivalInterval);
        }

        void Update()
        {


           if(GameManager.instance.isWorkHourDone)
            {
                CancelInvoke("GenerateCustomer");
                return;
            }

            if(Input.GetKeyDown(KeyCode.Space))
            {
                GenerateCustomer();
            }

            UpdateQueuePositions();
            
        }

        void GenerateCustomer()
        {
            if (customerQueue.Count < maxCustomers)
            {
                GameObject customerObject = Instantiate(customerPrefab, queueStartPoint.position, Quaternion.identity);

                totalCustomer++;

                Customer newCustomer = customerObject.GetComponent<Customer>();
                float arrivalTime = 2;
                newCustomer.Initialize(customerID++, arrivalTime, queuePoints);
                customerQueue.Enqueue(newCustomer);
                Debug.Log("Customer " + newCustomer.ID + " arrived at " + newCustomer.ArrivalTime);
            }
        }

        public void ServeCustomer()
        {
            if (customerQueue.Count > 0)
            {
                Customer servedCustomer = customerQueue.Dequeue();
                Debug.Log("Customer " + servedCustomer.ID + " is being served.");


                /*Destroy(servedCustomer.gameObject);*/ // Menghapus pelanggan setelah dilayani
            }
        }

        void UpdateQueuePositions()
        {
            int queueIndex = 0;
            foreach (Customer customer in customerQueue)
            {
                if (customer.GetCurrentQueueIndex() != queueIndex)
                {
                    customer.MoveToQueuePoint(queueIndex);
                }
                queueIndex++;
            }
        }

        public void RemoveNPC(Customer npc)
        {
            List<Customer> tempQueue = new List<Customer>(customerQueue);

            if (tempQueue.Remove(npc))
            {
                customerQueue = new Queue<Customer>(tempQueue);
               
            }
        }

        public int UpdateTotalAngryCustomer()
        { 
            return totalAngryCustomer++; 
        }

        public int GetTotalAngryCustomer()
        {

            return totalAngryCustomer; 
        
        }
        public int UpdateTotalSuccesCustomer()
        {
            return totalSuccesfullyOrder ++;
        }

        public int GetTotalSuccesCustomer()
        {

            return totalSuccesfullyOrder;

        }

        public int GetTotalCustomer()
        {
            return totalCustomer;
        }


    }
}
