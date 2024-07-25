using System.Collections;
using System.Collections.Generic;
using TestPR.Core;
using UnityEngine;

namespace TestPR.Character
{
    public class AnimationController : MonoBehaviour
    {
        private Animator playerAnimator;


        private void Awake()
        {
            playerAnimator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (GameManager.instance.isWorkHourDone)
            {
                playerAnimator.enabled = false;
                return;
            }


            if(Input.GetAxisRaw("Horizontal") == 1)
            {
                playerAnimator.SetFloat("XPos", 1);
                playerAnimator.SetFloat("YPos", 0);

            } else if(Input.GetAxisRaw("Horizontal") == - 1)
            {
                playerAnimator.SetFloat("XPos", -1);
                playerAnimator.SetFloat("YPos", 0);
            }

            if (Input.GetAxisRaw("Vertical") == 1)
            {
                playerAnimator.SetFloat("YPos", 1);
                playerAnimator.SetFloat("XPos", 0);

            }
            else if (Input.GetAxisRaw("Vertical") == -1)
            {
                playerAnimator.SetFloat("YPos", -1);
                playerAnimator.SetFloat("XPos", 0);
            }
            


        }

        public void SetPlayerWalk(float walkSpeed)
        {
            playerAnimator.SetFloat("WalkSpeed", walkSpeed);
        }

        public void InteractTriggered()
        {
            playerAnimator.SetTrigger("Interacted");
        }
    }
}
