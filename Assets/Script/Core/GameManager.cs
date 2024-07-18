using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace TestPR.Core
{
    public class GameManager : MonoBehaviour
    {

        public static GameManager instance;

        
        [SerializeField] Transform npcLoc;

        public bool isWorkHourDone;

        public UnityEvent onWorkHourDone;


        // Start is called before the first frame update
        void Start()
        {
            instance = this;
        }

        // Update is called once per frame
        void Update()
        {
            if(isWorkHourDone)
            {
                onWorkHourDone.Invoke();
            }

            
        }

       
    }
}
