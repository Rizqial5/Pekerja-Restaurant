using System.Collections;
using System.Collections.Generic;
using TestPR.Core;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace TestPR.UI
{
    public class OrderBar : MonoBehaviour
    { 
        

        public UnityEvent onDone;

        private float maxValue;
        private Slider loadSlider;

        private void Start()
        {
            loadSlider = GetComponent<Slider>();
        }

        private void Update()
        {
            if (GameManager.instance.isWorkHourDone) return;

            loadSlider.maxValue = maxValue;
            loadSlider.value += 10 * Time.deltaTime;

            if (loadSlider.value >= loadSlider.maxValue)
            {
                onDone.Invoke();
                Destroy(gameObject, 0.5f);  
            }

        }

        public void SetLoadingBar(float maxValue, UnityAction functionToCall, Transform parent)
        {
            

            onDone.AddListener(functionToCall);

            transform.SetParent(parent, false);

            

            this.maxValue = maxValue;
            
        }

        public void DecreaseProgressBar(float decreaseValue)
        {
            loadSlider.value -= decreaseValue;
        }

        public void DestorySpawnedBar()
        {
            
            Destroy(gameObject);
        }
    }
}
