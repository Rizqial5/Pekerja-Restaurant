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
            base.FrameUpdate();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
