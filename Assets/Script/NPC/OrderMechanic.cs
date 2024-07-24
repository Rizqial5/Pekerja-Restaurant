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
        private int currentSeatIndex;

        private GameObject spawnedFood;

        private Customer customer;
        private sitLoc emptySeat;
        private SeatSystem seatSystem;
        private OrderUI orderUI;
        private FoodSpawner foodSpawner;


        public NpcAnimController npcAnimController;
        public NpcMover npcMover;


        private float timeElapsed = 0f;

        private bool isOrderDone;
        private bool isPermittedToLeave;

        private void Awake()
        {
            customer = GetComponent<Customer>();
            npcAnimController = GetComponent<NpcAnimController>();
            npcMover = GetComponent<NpcMover>();
        }

        private void Start()
        {
            seatSystem = FindAnyObjectByType<SeatSystem>();
            foodSpawner = FindAnyObjectByType<FoodSpawner>();
            isOrderDone = false;
            
        }

        public void SetEmptySeat()
        {
            emptySeat = seatSystem.GetEmptySeat();
            currentSeatIndex = seatSystem.GetSeatIndex();

            if(emptySeat == null)
            {
                customer.SetCustomerToAngry();
                return;
            }

            orderUI = seatSystem.GetOrderUIObject();

            emptySeat.isSeatOccupied = true;
        }
        public Transform EmptySeatPosition()
        {
            if(emptySeat == null)
            {
                return null; 
            }

            return emptySeat.transform;
        }

        

        public void StartOrder()
        {
            
            if(!isOrderDone)
            {
                npcAnimController.SetAnimSit(true, npcMover.ReversePosX());

                

                orderUI.gameObject.SetActive(true);

                if(currentIndexString < orderSequenceStrings.Length)
                {
                    timeElapsed += Time.deltaTime;
                    orderUI.SetOrderUIText(orderSequenceStrings[currentIndexString]);

                    


                    if (timeElapsed >= waitTimePerSequence)
                    {
                        timeElapsed = 0f;

                        if (currentIndexString == 1)
                        {
                            print("makan");
                            spawnedFood = foodSpawner.SpawnFood(currentSeatIndex);
                        }

                        currentIndexString++;
                    }
                }
                else
                {
                    isOrderDone=true;

                    Destroy(spawnedFood);

                    spawnedFood = foodSpawner.SpawnEmptyPlate(currentSeatIndex);

                    orderUI.SetOrderUIText("Done");
                }

                

            } 

        }

        public void SetSeatToEmpty()
        {
            if (customer.isCustomerAngry()) return;

            Destroy(spawnedFood);
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
