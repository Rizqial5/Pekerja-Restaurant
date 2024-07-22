using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Tilemaps;
using UnityEngine;

namespace TestPR.UI
{
    public class OrderUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI orderText;


        public void SetOrderUIText(string text)
        {

            orderText.text = text;

            
        }

        
    }
}
