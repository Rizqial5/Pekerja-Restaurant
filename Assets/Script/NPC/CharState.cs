using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestPR.NPC
{
    public class CharState
    {
        protected Customer charBehaviour;
        protected CharStateMachine charStateMachine;
        

        public CharState(Customer charBehaviour,CharStateMachine charStateMachine)
        {
            this.charBehaviour = charBehaviour;
            this.charStateMachine = charStateMachine;
            
           
        }

        public virtual void EnterState() { }
        public virtual void ExitState() { }
        public virtual void FrameUpdate() { }
        public virtual void PhysicsUpdate() { }
    }
}
