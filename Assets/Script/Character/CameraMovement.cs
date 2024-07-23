using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestPR.Character
{
    public class CameraMovement : MonoBehaviour
    {

        private PlayerController player;

        [SerializeField] private float offsetUp = 1f;
        [SerializeField] private float offsetDown = 1f;
        [SerializeField] private float speedCamera = 2f;

        [SerializeField] private float targetYMax;


        private float initialCameraY;
        

        private void Start()
        {
            player = FindAnyObjectByType<PlayerController>();

            initialCameraY = transform.position.y;
        }


        private void FixedUpdate()
        {
            Vector3 playerViewportPosition = Camera.main.WorldToViewportPoint(player.transform.position);

           

            if (playerViewportPosition.y >=  offsetUp)
            {
                if (!player.IsMovingUp()) return;
                if (transform.position.y >= targetYMax) return;

                MoveCameraVertical();
            }
            else if (playerViewportPosition.y <= offsetDown && transform.position.y > initialCameraY)
            {
                if (!player.IsMovingDown()) return;
                MoveCameraVertical();
            }
        }

        private void MoveCameraVertical()
        {

            

            transform.Translate(new Vector3(0, Input.GetAxisRaw("Vertical")) * speedCamera * Time.deltaTime );
        }

        

        

    }
}
