using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

namespace TestPR.NPC
{
    public class NpcMover : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        

        private float stoppingDistance = 0.001f;

        public bool MoveToTarget(Transform target)
        {
            if(target == null) return false;

            Vector3 direction = (target.position - transform.position).normalized;
            
            float distanceToTarget = Vector3.Distance(transform.position, target.position);


            if(distanceToTarget <= stoppingDistance)
            {
                return true;
            }

         
            
            transform.position += direction * moveSpeed * Time.deltaTime;

            return false;
        }

        
    }
}
