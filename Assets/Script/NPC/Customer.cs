using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        private OrderMechanic orderMechanic;

        public int ID { get; private set; }
        public float ArrivalTime { get; private set; }
        public Transform[] queuePoints;
        private int currentQueueIndex = 0;
        
        private float speed = 5f;
        private bool isMoving = false;
        private Vector2 targetPosition;

        public bool isPermittedToEnter {  get; set; }


        private void Awake()
        {
            orderMechanic = GetComponent<OrderMechanic>();

            charStateMachine = new CharStateMachine();
            queueState = new QueueState(this, charStateMachine);
            orderState = new OrderState(this, orderMechanic ,charStateMachine);
            angryState = new AngryState(this, charStateMachine);
            doneState = new DoneState(this, charStateMachine);


            
        }
        void Start()
        {
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
                currentQueueIndex = queueIndex;
                targetPosition = queuePoints[queueIndex].position;
                isMoving = true;
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

            if ((Vector2)transform.position == target)
            {
                isMoving = false;

            }
        }

        public OrderMechanic GetOrderMechanic()
        {
            return orderMechanic;
        }
    }
}
