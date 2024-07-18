using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TestPR.UI;
using UnityEngine.Events;

namespace TestPR.NPC
{
    public class LoadBarBehaviour : MonoBehaviour
    {
        [SerializeField] OrderBar barObject;
        [SerializeField] Transform targetPosition;


        private Transform barObjectParent;
       
        private RectTransform barRectTransform;

        private OrderBar spawnedBar;

        private void Start()
        {
            barObjectParent = FindAnyObjectByType<GameUI>().transform;
        }
        private void Update()
        {
            if (spawnedBar == null) return;

            Vector3 screenPosition = Camera.main.WorldToScreenPoint(targetPosition.position);

            barRectTransform.position = screenPosition;
        }

        public void SpawnBar(float maxValue, UnityAction functionCall)
        {
            spawnedBar = Instantiate(barObject);

            spawnedBar.SetLoadingBar(maxValue, functionCall, barObjectParent);

            barRectTransform = spawnedBar.GetComponent<RectTransform>();
        }

        public void DecreaseBarProgress(float decreaseValue)
        {
            if (spawnedBar == null) return;

            spawnedBar.DecreaseProgressBar(decreaseValue);

            print("Customer lumayan sabar" + decreaseValue);
        }
    }
}
