using System.Collections;
using System.Collections.Generic;
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

        private float stoppingDistance = 0.001f;

        private Transform target;

        private void Start()
        {
            npcAgent = GetComponent<NavMeshAgent>();

            npcAgent.updateRotation = false;
            npcAgent.updateUpAxis = false;

            

        }

        private void Update()
        {
            if (HasReachedTarget())
            {
                npcAgent.isStopped = true;
            }
            else
            {
                npcAgent.isStopped = false;
            }
        }
        //public bool MoveToTarget(Transform target)
        //{
        //    if(target == null) return false;

        //    Vector3 direction = (target.position - transform.position).normalized;
            
        //    float distanceToTarget = Vector3.Distance(transform.position, target.position);


        //    if(distanceToTarget <= stoppingDistance)
        //    {
        //        return true;
        //    }

            
        //    Vector3 finalDirection = direction.normalized;

        //    transform.position += finalDirection * moveSpeed * Time.deltaTime;

        //    return false;
        //}

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


    }
}
