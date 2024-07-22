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

            if(charBehaviour.IsOnTargetedPosition(charBehaviour.GetTargetPosition())) // jika player sudah diposisi queue pertma kali
            {
                charBehaviour.GetLoadBarBehaviour().SpawnBar(charBehaviour.maxValueQueue, charBehaviour.SetCustomerToAngry);
            }

            if(charBehaviour.IsQueueIndexChanged()) // jika posisi antrian player berpindah
            {
                charBehaviour.GetLoadBarBehaviour().DecreaseBarProgress(10f);
            }

            if(charBehaviour.isCustomerAngry())
            {
                
                charBehaviour.charStateMachine.ChangeState(charBehaviour.angryState);
            }

            if(charBehaviour.isPermittedToEnter) // jika NPC sudah di persilahkan untuk masuk resto
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
