using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ORKGames
{
    public class Podium : MonoBehaviour
    {
        public Selector selector;

        private Rigidbody rigidbody;

        private bool LastSwipeLeft, LastSwipeRight;

        [SerializeField] float SpeedForMagnetizm;//for activation magnetizm;
        [SerializeField] float speed;
        [SerializeField] SwipeController swipeController;
        void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            if (SwipeController.swipeLeft)
            {
                LastSwipeLeft = true;
                LastSwipeRight = false;

                rigidbody.AddTorque(-Vector3.up * swipeController.swipeDelta * speed);
                
            }
            if (SwipeController.swipeRight)
            {
                LastSwipeLeft = false;
                LastSwipeRight = true;

                rigidbody.AddTorque(Vector3.up * swipeController.swipeDelta * speed);
                
            }

            if (!selector.IsSelected)
            {
                float CurrentRotateSpeed = Mathf.Abs(rigidbody.angularVelocity.y);
                if (CurrentRotateSpeed < SpeedForMagnetizm)
                {
                     RotateMagnetizm();
                }
            }

        }
        private void RotateMagnetizm()
        {
            if (LastSwipeRight)
            {
                rigidbody.AddTorque(Vector3.up * (speed * 10f) * Time.fixedDeltaTime);
            }
            if (LastSwipeLeft)
            {
                rigidbody.AddTorque(-Vector3.up * (speed * 10f) * Time.fixedDeltaTime);
               
            }
           
        }
    }

}
