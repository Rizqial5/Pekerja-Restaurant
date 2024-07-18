using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestPR.NPC
{
    public class CharStateMachine : MonoBehaviour
    {
        public CharState currentCharState { get; set; }
        public CharState oldCharState { get; set; }

        public void Initialize(CharState starttingState)
        {
            currentCharState = starttingState;

            currentCharState.EnterState();
        }

        public void ChangeState(CharState newState)
        {
            oldCharState = currentCharState;

            currentCharState.ExitState();

            currentCharState = newState;

            currentCharState.EnterState();
        }
    }
}

