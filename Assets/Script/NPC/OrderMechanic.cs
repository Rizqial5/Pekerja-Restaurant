using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestPR.NPC
{
    public class OrderMechanic : MonoBehaviour
    {
        [SerializeField] Transform customerTable;
        [SerializeField] float waitTimePerSequence;
       

        private Customer customer;

        private bool isOrderDone;

        private void Awake()
        {
            customer = GetComponent<Customer>();
        }

        private void Start()
        {
            isOrderDone = false;
            customerTable = FindAnyObjectByType<sitLoc>().transform;
        }
        public Vector2 EmptyTablePosition()
        {

            return customerTable.position;

        }

        

        

        public void StartOrder()
        {
            if(!isOrderDone)
            {
                StartCoroutine(OrderSequence());
            } 
            

        }

        public bool GetIsOrderDone()
        { return isOrderDone; }

        public IEnumerator OrderSequence() // percobaan
        {
            print("ordering....."); // diganti loading bar
            yield return new WaitForSeconds(waitTimePerSequence);

            print("Wating order.....");
            yield return new WaitForSeconds(waitTimePerSequence);


            print("eating.......");
            yield return new WaitForSeconds(waitTimePerSequence);

            isOrderDone=true;

            yield return null;
            
        }
    }
}
