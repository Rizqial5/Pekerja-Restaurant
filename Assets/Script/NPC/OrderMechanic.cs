using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestPR.Core;
using TestPR.UI;
using TMPro;

namespace TestPR.NPC
{
    public class OrderMechanic : MonoBehaviour
    {
        [SerializeField] Transform customerTable;
        [SerializeField] float waitTimePerSequence;
        [SerializeField] string[] orderSequenceStrings;
       

        private int currentIndexString = 0;
        private Customer customer;
        private sitLoc emptySeat;
        private SeatSystem seatSystem;
        private OrderUI orderUI;


        private float timeElapsed = 0f;

        private bool isOrderDone;
        private bool isPermittedToLeave;

        private void Awake()
        {
            customer = GetComponent<Customer>();
        }

        private void Start()
        {
            seatSystem = FindAnyObjectByType<SeatSystem>();
            isOrderDone = false;
            
        }

        public void SetEmptySeat()
        {
            emptySeat = seatSystem.GetEmptySeat();

            if(emptySeat == null)
            {
                customer.SetCustomerToAngry();
                return;
            }

            orderUI = seatSystem.GetOrderUIObject();

            emptySeat.isSeatOccupied = true;
        }
        public Vector2 EmptySeatPosition()
        {
            if(emptySeat == null)
            {
                return Vector2.zero; 
            }
            
            return emptySeat.transform.position;

        }

        

        public void StartOrder()
        {
            if(!isOrderDone)
            {
                orderUI.gameObject.SetActive(true);

                if(currentIndexString < orderSequenceStrings.Length)
                {
                    timeElapsed += Time.deltaTime;
                    orderUI.SetOrderUIText(orderSequenceStrings[currentIndexString]);


                    if (timeElapsed >= waitTimePerSequence)
                    {
                        timeElapsed = 0f;

             
                        currentIndexString++;
                    }
                }
                else
                {
                    isOrderDone=true;
                    orderUI.SetOrderUIText("Done");
                }
                


            } 

        }

        public void SetSeatToEmpty()
        {
            if (customer.isCustomerAngry()) return;


            currentIndexString = 0;
            orderUI.gameObject.SetActive(false);
            emptySeat.isSeatOccupied = false;
        }



        public bool GetIsOrderDone()
        { return isOrderDone; }
        public bool SetPermittedToLeave(bool value)
        { return isPermittedToLeave = value; }

        public bool IsPermittedToLeave() { return isPermittedToLeave; }
    }
}
