using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestPR.NPC;
using TestPR.Core;

namespace TestPR.Character
{
    public class InteractBehaviour : MonoBehaviour
    {

        private bool isInteractAble;

        private Customer interactedNpc;

        private QueueSystem queueSystem;

        private void Awake()
        {
            queueSystem = FindAnyObjectByType<QueueSystem>();
        }

        private void Update()
        {
            if (!isInteractAble) return;

            if(Input.GetKeyDown(KeyCode.K))
            {
                interactedNpc.isPermittedToEnter = true;
                queueSystem.ServeCustomer();

                

                //maka player itu akan move towards to resto
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
