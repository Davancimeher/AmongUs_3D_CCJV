using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  
        public CharacterController _controller;
        public float _speed = 10;
        public float _rotationSpeed = 180;
    public Animator animator;

        private Vector3 rotation;

        public void Update()
        {
            this.rotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * _rotationSpeed * Time.deltaTime, 0);

            Vector3 move = new Vector3(0, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime);
            move = this.transform.TransformDirection(move);
            _controller.Move(move * _speed);
            this.transform.Rotate(this.rotation);
        if (Input.GetAxis("Horizontal") != 0 || (Input.GetAxis("Vertical") != 0))
        {
            animator.SetFloat("tharek", 1f);

        }
        else
            animator.SetFloat("tharek", 0f);
    }
}
    
 
      



