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
        private SpawnedUIObjectBehaviour spawnedUIObject;
       
        private RectTransform barRectTransform;

        private OrderBar spawnedBar;

        private bool isAlreadySpawned;

        private void Awake()
        {
            spawnedUIObject = GetComponent<SpawnedUIObjectBehaviour>();
        }

        private void Start()
        {
            barObjectParent = FindAnyObjectByType<GameUI>().transform;

            isAlreadySpawned = false;
        }
        private void Update()
        {
            if (spawnedBar == null) return;

            spawnedUIObject.UpdateUIPositionWorld(barRectTransform, targetPosition);

            //UpdateBarPosition();
        }

        public void SpawnBar(float maxValue, UnityAction functionCall)
        {
            if (isAlreadySpawned) return;

            spawnedBar = Instantiate(barObject);

            spawnedBar.SetLoadingBar(maxValue, functionCall, barObjectParent);

            barRectTransform = spawnedBar.GetComponent<RectTransform>();

            isAlreadySpawned = true;
        }

        public void DestroyBar()
        {
            if (spawnedBar == null) return;

            spawnedBar.DestorySpawnedBar();          
        }

        public void DecreaseBarProgress(float decreaseValue)
        {
            if (spawnedBar == null) return;

            spawnedBar.DecreaseProgressBar(decreaseValue);

            print("Customer lumayan sabar -" + decreaseValue);
        }
    }
}
