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

            //animation character play
        }

        
    }
}
