using System.Collections;
using System.Collections.Generic;
using TestPR.UI;
using UnityEngine;
using UnityEngine.Events;


namespace TestPR.Core
{
    public class GameManager : MonoBehaviour
    {

        public static GameManager instance;

        
        [SerializeField] RecapPanel recapPanel;

        public bool isWorkHourDone;

        public UnityEvent onWorkHourDone;

        private QueueSystem queueSystem;


        // Start is called before the first frame update
        void Start()
        {
            instance = this;

            queueSystem = FindAnyObjectByType<QueueSystem>();
        }

        // Update is called once per frame
        void Update()
        {

            if(Input.GetKeyDown(KeyCode.O))
            {
                isWorkHourDone = true;
            }

            if(isWorkHourDone)
            {
                recapPanel.gameObject.SetActive(true);

                recapPanel.SetRecapPanel(queueSystem.GetTotalSuccesCustomer(), queueSystem.GetTotalAngryCustomer(), queueSystem.GetTotalCustomer());
                onWorkHourDone.Invoke();
            }

            
        }

       
    }
}
