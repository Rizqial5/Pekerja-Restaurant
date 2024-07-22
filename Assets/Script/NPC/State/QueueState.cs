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



            if (charBehaviour.IsQueueIndexChanged()) // jika posisi antrian player berpindah
            {
                charBehaviour.GetLoadBarBehaviour().DecreaseBarProgress(10f);
            }

            if (charBehaviour.isCustomerAngry())
            {

                charBehaviour.charStateMachine.ChangeState(charBehaviour.angryState);
            }

            if (charBehaviour.isPermittedToEnter) // jika NPC sudah di persilahkan untuk masuk resto
            {
                charBehaviour.charStateMachine.ChangeState(charBehaviour.orderState);
            }



            if (charBehaviour.GetTargetPosition() == null) return;

            if (charBehaviour.GetNpcMover().MoveToTarget(charBehaviour.GetTargetPosition()))
            {
                charBehaviour.SetTargetPosition(null);
                charBehaviour.GetLoadBarBehaviour().SpawnBar(charBehaviour.maxValueQueue, charBehaviour.SetCustomerToAngry);
            }

            

           



        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
