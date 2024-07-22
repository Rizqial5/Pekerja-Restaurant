using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestPR.UI;

namespace TestPR.Core
{
    public class SeatSystem : MonoBehaviour
    {
        [SerializeField] private sitLoc[] totalSeats;

        private OrderUIManager orderUIManager;

        private void Awake()
        {
            orderUIManager = GetComponent<OrderUIManager>();
        }

        public sitLoc GetEmptySeat()
        {
            for (int i = 0; i < totalSeats.Length; i++)
            {
                if (!totalSeats[i].isSeatOccupied)
                {
                    return totalSeats[i];
                }
            }

            return null;

        }

        public OrderUI GetOrderUIObject()
        {
            for (int i = 0; i < totalSeats.Length; i++)
            {
                if (!totalSeats[i].isSeatOccupied)
                {
                    return orderUIManager.GetOrderUI(i);
                }
            }

            return null;
        }

        
    }
}
