using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TestPR.NPC
{
    public class QueueState : CharState
    {
        public QueueState(Customer charBehaviour, CharStateMachine charStateMachine) : base(charBehaviour, charStateMachine)
        {
        }

        public override void EnterState()
        {

            charBehaviour.MoveToQueuePoint(charBehaviour.GetCurrentQueueIndex());

        }

        public override void ExitState()
        {
            base.ExitState();
        }

        public override void FrameUpdate()
        {
            base.FrameUpdate();



            if (charBehaviour.GetIsMoving())
            {
                charBehaviour.MoveToPosition(charBehaviour.GetTargetPosition());
            }

            if(charBehaviour.isPermittedToEnter)
            {
                charBehaviour.charStateMachine.ChangeState(charBehaviour.orderState);
            }



        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
