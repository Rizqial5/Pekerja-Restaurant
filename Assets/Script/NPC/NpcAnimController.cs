using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestPR.NPC
{
    public class NpcAnimController : MonoBehaviour
    {
        private Animator npcAnimator;

        private void Awake()
        {
            npcAnimator = GetComponent<Animator>();
        }

        public void SetAnimWalk(bool isStopped)
        {
            npcAnimator.SetBool("isStopped", isStopped);
        }

        public void SetAnimPos(float XPos, float YPos)
        {
            npcAnimator.SetFloat("XPos", XPos);
            npcAnimator.SetFloat("YPos", YPos);
        }

        public void SetAnimSit(bool isOnSeat, float SitXPos)
        {
            npcAnimator.SetBool("isOnSeat", isOnSeat);
            npcAnimator.SetFloat("SitXPos", SitXPos);
        }

        
    }
}
