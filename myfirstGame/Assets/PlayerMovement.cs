using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController Controller;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float speed = 10f;
    public float gravity = -9.8f;
    public float jumoHeight = 3;
    public float groundDistance = 0.4f;
    Vector3 velocity;
    bool IsGrounded;
    
  
    // Update is called once per frame
    void Update()
    {
        IsGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (IsGrounded && velocity.y<0) 
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            velocity.y = Mathf.Sqrt(jumoHeight * -2 * gravity);
        };


        Vector3 move = transform.right * x +transform.forward *z;
        Controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        Controller.Move(velocity*Time.deltaTime);

        if (IsGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (Input.GetKey("c"))
        {
            Controller.height = 1f;
            speed = 7f;
        }
        else
        {
            Controller.height = 2f;
            speed = 10f;
        }
        if (Input.GetKey("x"))
        {
            speed = 15f;
        }
        else
        {
            speed = 10f;
        }


    }
}
