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
        private bool isPermittedToLeave;

        private void Awake()
        {
            customer = GetComponent<Customer>();
        }

        private void Start()
        {
            isOrderDone = false;
            customerTable = FindAnyObjectByType<sitLoc>().transform; // kayaknya dirubah
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
            print("Done, Ready to Leave");

            yield return null;
            
        }

        public bool SetPermittedToLeave(bool value)
        { return isPermittedToLeave = value; }

        public bool IsPermittedToLeave() { return isPermittedToLeave; }
    }
}
