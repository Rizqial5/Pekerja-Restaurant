using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestPR.NPC
{
    public class OrderState : CharState
    {
        OrderMechanic orderMechanic;
        private bool isArrive;
        public OrderState(Customer charBehaviour, OrderMechanic orderMechanic ,CharStateMachine charStateMachine) : base(charBehaviour, charStateMachine)
        {
            this.orderMechanic = charBehaviour.GetOrderMechanic();
        }

        public override void EnterState()
        {
            Debug.Log("Customer sudah memasuki restoran");

            
        }

        public override void ExitState()
        {
            base.ExitState();
        }

        public override void FrameUpdate()
        {
            if (CheckTablePosition())
            {
                charBehaviour.MoveToPosition(orderMechanic.EmptyTablePosition());

            } else if(!CheckTablePosition())
            {
                orderMechanic.StartOrder();
            }


            if(orderMechanic.GetIsOrderDone())
            {
                charBehaviour.charStateMachine.ChangeState(charBehaviour.doneState);
            }
            


        }

        private bool CheckTablePosition()
        {
            return (Vector2)charBehaviour.transform.position != orderMechanic.EmptyTablePosition();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        
    }
}
