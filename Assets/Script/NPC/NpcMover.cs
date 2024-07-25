using System.Collections;
using System.Collections.Generic;
using TestPR.Core;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Tilemaps;

namespace TestPR.NPC
{
    public class NpcMover : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        
        private NavMeshAgent npcAgent;

        private Transform target;

        private NpcAnimController animController;

        private float NPCPosX = 0;

        private void Awake()
        {
            animController = GetComponent<NpcAnimController>();
        }

        private void Start()
        {
            npcAgent = GetComponent<NavMeshAgent>();

            npcAgent.updateRotation = false;
            npcAgent.updateUpAxis = false;

            

        }

        private void Update()
        {
            if (GameManager.instance.isWorkHourDone)
            {
                npcAgent.isStopped = true;
                return;
            }

            NpcXPosition();
            if (HasReachedTarget())
            {
                npcAgent.isStopped = true;
            }
            else
            {
                npcAgent.isStopped = false;
            }

            animController.SetAnimWalk(npcAgent.isStopped);

            animController.SetAnimPos(NPCPosX, npcAgent.velocity.y);
        }


        public void NpcXPosition()
        {
            if(npcAgent.velocity.x < 0)
            {
                NPCPosX =  -1;

            }else if(npcAgent.velocity.x > 0)
            {
                NPCPosX = 1;
            }
        }
        

        public void SetTarget(Transform target)
        {
            npcAgent.SetDestination(target.position);
        }

        public bool HasReachedTarget()
        {
            if (!npcAgent.pathPending)
            {
                if (npcAgent.remainingDistance <= npcAgent.stoppingDistance)
                {
                    if (!npcAgent.hasPath || npcAgent.velocity.sqrMagnitude == 0f)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public float ReversePosX()
        {
            if(NPCPosX == -1)
            {
                return 1;

            } else if(NPCPosX == 1)
            {
                return -1;
            }

            return 0;
        }


    }
}
