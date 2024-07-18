using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TestPR.NPC
{
    public class StartState : CharState
    {
        public StartState(Customer charBehaviour, CharStateMachine charStateMachine) : base(charBehaviour, charStateMachine)
        {
        }

        public override void EnterState()
        {
            
            base.EnterState();
            Debug.Log("Masuk");
            
        }

        public override void ExitState()
        {
            base.ExitState();

            //charBehaviour.isNpcOnQueue = false;
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
