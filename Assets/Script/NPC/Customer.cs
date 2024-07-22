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

        private OrderMechanic orderMechanic;
        private LoadBarBehaviour loadBarBehaviour;
        private QueueSystem queueSystem;
        

        public int ID { get; private set; }
        public float ArrivalTime { get; private set; }
        public Transform[] queuePoints;
        public Transform exitPoints;
        private int currentQueueIndex = 0;
        private int oldQueueIndex = 0;
        
        private float speed = 5f;
        private bool isMoving = false;
        private bool isAngry;
        private Vector2 targetPosition;
        

        public bool isPermittedToEnter {  get; set; }


        private void Awake()
        {
            orderMechanic = GetComponent<OrderMechanic>();
            loadBarBehaviour = GetComponent<LoadBarBehaviour>();
            

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

            charStateMachine.currentCharState.FrameUpdate();

            
        }

        private void FixedUpdate()
        {
            charStateMachine.currentCharState.PhysicsUpdate();
                
        }

        public void Initialize(int id, float arrivalTime, Transform[] queuePoints)
        {
            ID = id;
            ArrivalTime = arrivalTime;
            this.queuePoints = queuePoints;

            

            MoveToQueuePoint(0); 
        }

        public void MoveToQueuePoint(int queueIndex)
        {
            if (queueIndex < queuePoints.Length)
            {
                oldQueueIndex = currentQueueIndex;
                currentQueueIndex = queueIndex;
                targetPosition = queuePoints[queueIndex].position;
                isMoving = true;
                
                //loadBarBehaviour.DecreaseBarProgress(10);
            }
        }

        public int GetCurrentQueueIndex()
        {
            return currentQueueIndex;
        }

        public bool GetIsMoving()
        {
            return isMoving;
        }


        public bool SetIsMoving(bool value)
        {
            return isMoving = value;
        }

        public Vector2 GetTargetPosition()
        {
            return targetPosition;
        }

        public void MoveToPosition(Vector2 target)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target, step);

            if (IsOnTargetedPosition(target))
            {
                isMoving = false;

                //loadBarBehaviour.SpawnBar(maxValueQueue, CustomerAngry);

            }
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
            print("Customer marah - marah");
            queueSystem.UpdateTotalAngryCustomer();
        }

        public void UpdateCustomerHappy()
        {
            queueSystem.UpdateTotalSuccesCustomer();
        }
        public bool IsOnTargetedPosition(Vector2 target)
        {
            return (Vector2)transform.position == target;
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

        public LoadBarBehaviour GetLoadBarBehaviour() { return loadBarBehaviour; }

        public Transform GetExitLocation() { return exitPoints; }


    }
}
