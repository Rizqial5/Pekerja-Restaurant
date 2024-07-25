using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TestPR.UI
{
    public class OrderUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI orderText;
        [SerializeField] private Transform target;

        private RectTransform rectTransform;

        private Vector3 initialPosition;

        private void Start()
        {
            rectTransform = GetComponent<RectTransform>();

            initialPosition = rectTransform.position;
        }


        private void Update()
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(target.position);

            rectTransform.position = screenPos;
        }

        public void SetOrderUIText(string text)
        {

            orderText.text = text;

            
        }

        
    }
}
