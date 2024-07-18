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
            base.EnterState();
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
