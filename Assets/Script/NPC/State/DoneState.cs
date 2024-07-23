using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestPR.NPC
{
    public class DoneState : CharState
    {

        
        public DoneState(Customer charBehaviour, CharStateMachine charStateMachine) : base(charBehaviour, charStateMachine)
        {
        }

        public override void EnterState()
        {
            Debug.Log("Makan sudah selesai");

            charBehaviour.UpdateCustomerHappy();
            
        }

        public override void ExitState()
        {
            base.ExitState();
        }

        public override void FrameUpdate()
        {

            if (charBehaviour.GetExitLocation() == null) return;

            charBehaviour.GetNpcMover().SetTarget(charBehaviour.GetExitLocation());

            if (charBehaviour.GetNpcMover().HasReachedTarget())
            {
                //charBehaviour.GetNpcMover().SetTarget(null);
                charBehaviour.CustomerDone(); 
            }


            //if (charBehaviour.GetNpcMover().MoveToTarget(charBehaviour.GetExitLocation()))
            //{
            //    charBehaviour.SetTargetPosition(null);
            //    charBehaviour.CustomerDone();


            //}

            
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
