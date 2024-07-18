using System.Collections;
using System.Collections.Generic;
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

            loadSlider.value += 10 * Time.deltaTime;

            if (loadSlider.value == maxValue)
            {
                onDone.Invoke();
                Destroy(gameObject, 0.5f);
            }

        }

        public void SetLoadingBar(float maxValue, UnityAction functionToCall)
        {
            onDone.AddListener(functionToCall);

            Slider loadSLider = GetComponent<Slider>();

            this.maxValue = maxValue;
            
        }
    }
}
