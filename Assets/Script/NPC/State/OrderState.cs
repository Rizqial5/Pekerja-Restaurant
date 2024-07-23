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
            charBehaviour.GetLoadBarBehaviour().DestroyBar();
            orderMechanic.SetEmptySeat();

           
            

        }

        public override void ExitState()
        {
            orderMechanic.SetSeatToEmpty();
        }

        public override void FrameUpdate()
        {
            if(charBehaviour.isCustomerAngry())
            {
                charBehaviour.charStateMachine.ChangeState(charBehaviour.angryState);
                return;
            }

            if (orderMechanic.GetIsOrderDone() && orderMechanic.IsPermittedToLeave())// ditambahi jika customer juga sudah dipersilahkan keluar
            {
                charBehaviour.charStateMachine.ChangeState(charBehaviour.doneState);
            }


            if (orderMechanic.EmptySeatPosition() == null) return;

            charBehaviour.GetNpcMover().SetTarget(orderMechanic.EmptySeatPosition());

            if (charBehaviour.GetNpcMover().HasReachedTarget())
            {
                //charBehaviour.GetNpcMover().SetTarget(null);
                orderMechanic.StartOrder();
            }

            //if (charBehaviour.GetNpcMover().MoveToTarget(orderMechanic.EmptySeatPosition()))
            //{
            //    charBehaviour.SetTargetPosition(null);
            //    orderMechanic.StartOrder();

            //}




        }

        

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        
    }
}
