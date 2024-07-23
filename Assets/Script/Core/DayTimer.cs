using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms;
using UnityEngine.Events;

namespace TestPR.Core
{
    public class DayTimer : MonoBehaviour
    {

        [SerializeField] TextMeshProUGUI timerText;
        [SerializeField] float timeScaleMultiplication;
        [SerializeField] int startTargetHour;

       
        private float currentTime = 0f;

        public UnityEvent onHourChanged;
        

     

        // Start is called before the first frame update
        void Start()
        {

            SetStartHour(startTargetHour);

            TimeDisplay();
            
        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager.instance.isWorkHourDone) return;


            currentTime += Time.deltaTime * timeScaleMultiplication;

            int newHour = Mathf.FloorToInt(currentTime / 3600f) % 24;
            int currentHour = Mathf.FloorToInt((currentTime - Time.deltaTime * timeScaleMultiplication) / 3600f) % 24;

            if (newHour != currentHour)
            {
                currentHour = newHour;
                TimeDisplay();

                onHourChanged.Invoke();



                print("satu jam berlalu");
            }

            if (currentHour == 11)
            {
                print("waktunya istirahat");

            }
            //else if (currentHour == 21)
            //{
            //    GameManager.instance.isWorkHourDone = true;
            //    print("Toko sudah ditutup");
            //}


        }
        

        private void TimeDisplay()
        {
            int hours = Mathf.FloorToInt(currentTime / 3600f) % 24;
            //int minutes = Mathf.FloorToInt(timerValue / 60f) % 60;
            timerText.text = string.Format("{0:00}" + ":00 ", hours);
        }

        public void SetStartHour(int startHour)
        {
            currentTime = startHour * 3600f;
        }
    }
}
