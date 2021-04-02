using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class playermouvement2 : MonoBehaviour
{
    public CharacterController controller;
    

    public float speed = 6f;
    public Animator animator;
    public float TurnSmoothTime = 0.1f;
    float TurnSmoothVelocity;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 Direction = new Vector3(horizontal, 0f, vertical).normalized;
   

        if (Direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(Direction.x, Direction.z) * Mathf.Rad2Deg ;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle,ref TurnSmoothVelocity, TurnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 movedirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(movedirection.normalized * speed * Time.deltaTime);
        }
        if (Input.GetAxis("Horizontal") != 0 || (Input.GetAxis("Vertical") != 0))
        {
            animator.SetFloat("tharek", 1f);

        }
        else
            animator.SetFloat("tharek", 0f);
    }
}