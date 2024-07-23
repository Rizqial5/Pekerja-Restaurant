using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestPR.Core;

namespace TestPR.Character
{
    public class PlayerController : MonoBehaviour
    {
        Rigidbody2D rb;

        [SerializeField] float speed;

        private bool isMovingUp;
        private bool isMovingDown;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager.instance.isWorkHourDone)
            {
                rb.velocity = Vector3.zero;
                return;
            }  // jika waktu kerja sudah habis maka pergerakan player mati

            rb.velocity = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed;

            if(Input.GetKeyDown(KeyCode.W))
            {
                isMovingUp = true;
                isMovingDown = false;

            }else if(Input.GetKeyDown(KeyCode.S))
            {
                isMovingUp = false;
                isMovingDown = true;
            }
            //animation character play
        }


        public bool IsMovingUp() { return isMovingUp; }
        public bool IsMovingDown() { return isMovingDown; }

        
    }
}
