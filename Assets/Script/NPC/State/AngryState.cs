using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestPR.NPC
{
    public class AngryState : CharState
    {
        public AngryState(Customer charBehaviour, CharStateMachine charStateMachine) : base(charBehaviour, charStateMachine)
        {
        }

        public override void EnterState()
        {
            charBehaviour.UpdateCustomerAngry();
        }

        public override void ExitState()
        {
            base.ExitState();
        }

        public override void FrameUpdate()
        {
            if (charBehaviour.GetExitLocation() == null) return;

            if (charBehaviour.GetNpcMover().MoveToTarget(charBehaviour.GetExitLocation()))
            {
                charBehaviour.SetTargetPosition(null);
                charBehaviour.CustomerDone();


            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
