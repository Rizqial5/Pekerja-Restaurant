using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestPR.NPC;
using TestPR.Core;

namespace TestPR.Character
{
    public class InteractBehaviour : MonoBehaviour
    {

        [SerializeField] private GameObject interactMark;

        private bool isInteractAble;

        private Customer interactedNpc;

        private QueueSystem queueSystem;

        private AnimationController animController;

        private void Awake()
        {
            queueSystem = FindAnyObjectByType<QueueSystem>();
            animController = GetComponent<AnimationController>();
        }

        private void Update()
        {

            interactMark.SetActive(isInteractAble);

            if (!isInteractAble) return;

            if(Input.GetKeyDown(KeyCode.Mouse0))
            {

                animController.InteractTriggered();


                if(!interactedNpc.GetPermittedEnter())
                {
                    if(!interactedNpc.IsCustomerOnFirstQueue()) return;

                    interactedNpc.SetPermittedEnter(true);
                    queueSystem.ServeCustomer();
                }
                
                if(interactedNpc.GetOrderMechanic().GetIsOrderDone())
                {
                    interactedNpc.GetOrderMechanic().SetPermittedToLeave(true);
                }
                

                
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Interact")
            {
                isInteractAble = true;
                interactedNpc = collision.gameObject.GetComponentInParent<Customer>();
            }
                
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.tag == "Interact")
            {
                isInteractAble = true;
                interactedNpc = collision.gameObject.GetComponentInParent<Customer>();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Interact")
            {
                isInteractAble = false;
                interactedNpc = null;
            }
        }
    }
}
