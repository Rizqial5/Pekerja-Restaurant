using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestPR.UI
{
    public class OrderUIManager : MonoBehaviour
    {
        [SerializeField] OrderUI[] totalOrderUI;


        
        public OrderUI GetOrderUI(int index)
        {
            return totalOrderUI[index];
        }
    }
}
