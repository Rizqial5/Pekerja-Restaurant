using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestPR.UI;
using TestPR.Core;

namespace TestPR.NPC
{
    public class Customer : MonoBehaviour
    {

        #region State Builder

        public CharStateMachine charStateMachine { get; set; }
        public QueueState queueState { get; set; }
        public OrderState orderState { get; set; }
        public AngryState angryState { get; set; }
        public DoneState doneState { get; set; }


        #endregion

        [SerializeField] public float maxValueQueue;
        [SerializeField] private GameObject happyEmotion;
        [SerializeField] private GameObject angryEmotion;

        private OrderMechanic orderMechanic;
        private LoadBarBehaviour loadBarBehaviour;
        private QueueSystem queueSystem;
        private NpcMover npcMover;
       
        

        public int ID { get; private set; }
        public float ArrivalTime { get; private set; }
        public Transform[] queuePoints;
        public Transform exitPoints;
        private int currentQueueIndex = 0;
        private int oldQueueIndex = 0;
        
       
        
        private bool isAngry;
        private Transform targetPosition;


        private bool isPermittedToEnter = false;


        private void Awake()
        {
            orderMechanic = GetComponent<OrderMechanic>();
            loadBarBehaviour = GetComponent<LoadBarBehaviour>();
            npcMover = GetComponent<NpcMover>();
            

            charStateMachine = new CharStateMachine();
            queueState = new QueueState(this, charStateMachine);
            orderState = new OrderState(this, orderMechanic ,charStateMachine);
            angryState = new AngryState(this, charStateMachine);
            doneState = new DoneState(this, charStateMachine);


            
        }
        void Start()
        {
            exitPoints = FindAnyObjectByType<ExitLoc>().transform;
            queueSystem = FindAnyObjectByType<QueueSystem>();
            charStateMachine.Initialize(queueState);

            
        }

        void Update()
        {
            if (GameManager.instance.isWorkHourDone) return;
            charStateMachine.currentCharState.FrameUpdate();

            
        }

        private void FixedUpdate()
        {
            charStateMachine.currentCharState.PhysicsUpdate();
                
        }

        public void Initialize(int id, Transform[] queuePoints)
        {
            ID = id;
            
            this.queuePoints = queuePoints;

            

            MoveToQueuePoint(0); 
        }

        public void MoveToQueuePoint(int queueIndex)
        {
            if (queueIndex < queuePoints.Length)
            {
                oldQueueIndex = currentQueueIndex;
                currentQueueIndex = queueIndex;
               

                SetTargetPosition(queuePoints[queueIndex]);
                
                
                //loadBarBehaviour.DecreaseBarProgress(10);
            }
        }

        public int GetCurrentQueueIndex()
        {
            return currentQueueIndex;
        }

        //public bool GetIsMoving()
        //{
        //    return isMoving;
        //}



        public Transform GetTargetPosition()
        {
            return targetPosition;
        }

        public Transform SetTargetPosition( Transform valueTransform)
        {
            return targetPosition = valueTransform;
        }

        

        public void CustomerDone()
        {
            Destroy(gameObject, 0.5f);
        }


        public void SetCustomerToAngry() // untuk di call di load bar jika progress selesai
        {
            queueSystem.RemoveNPC(this);
            isAngry = true;
        }
        public void UpdateCustomerAngry() 
        {
            angryEmotion.SetActive(true);

            queueSystem.UpdateTotalAngryCustomer();
        }

        public void UpdateCustomerHappy()
        {
            happyEmotion.SetActive(true);
            queueSystem.UpdateTotalSuccesCustomer();
        }
        

        public bool IsQueueIndexChanged()
        {
            if (oldQueueIndex != currentQueueIndex)
            {
                oldQueueIndex = currentQueueIndex;
                return true;
            }

            return false;
        }
        public bool isCustomerAngry()
        { return isAngry; } 
        
        

        public OrderMechanic GetOrderMechanic()
        {
            return orderMechanic;
        }

        public NpcMover GetNpcMover() { return npcMover; }
        public LoadBarBehaviour GetLoadBarBehaviour() { return loadBarBehaviour; }

        public Transform GetExitLocation() { return exitPoints; }

        public bool SetPermittedEnter(bool value)
        {
            return isPermittedToEnter = value;
        }

        public bool GetPermittedEnter()
        {

            return isPermittedToEnter; 
        }

        public bool IsCustomerOnFirstQueue()
        {
            if(currentQueueIndex == 0) return true;

            return false;
        }
    }
}
