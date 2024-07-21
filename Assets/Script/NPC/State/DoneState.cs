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

            
        }

        public override void ExitState()
        {
            base.ExitState();
        }

        public override void FrameUpdate()
        {
            charBehaviour.MoveToPosition(charBehaviour.GetExitLocation().position);

            if(charBehaviour.IsOnTargetedPosition(charBehaviour.GetExitLocation().position))
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
