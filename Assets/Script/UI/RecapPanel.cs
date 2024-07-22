using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TestPR.UI
{
    public class RecapPanel : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI totalHappyValue;
        [SerializeField] TextMeshProUGUI totalAngryValue;
        [SerializeField] TextMeshProUGUI totalValue;


        public void SetRecapPanel(int happyValue,int angryValue, int totalvalue)
        {
            totalHappyValue.text = happyValue.ToString();
            totalAngryValue.text = angryValue.ToString();
            totalValue.text = totalvalue.ToString();
        }
    }
}
