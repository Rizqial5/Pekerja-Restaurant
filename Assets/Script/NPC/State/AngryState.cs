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
            charBehaviour.MoveToPosition(charBehaviour.GetExitLocation().position);

            if (charBehaviour.IsOnTargetedPosition(charBehaviour.GetExitLocation().position))
            {
                charBehaviour.CustomerDone();
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
