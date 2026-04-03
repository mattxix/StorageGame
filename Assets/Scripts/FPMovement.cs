using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class FPMovement : MonoBehaviour
{
    public float speed = 10;
    float h, v;
    public float gravity = -9.8f;
    public float jumpStrength = 10.0f;
    float velocity;
    float gravityMultiplier = 3.0f;

    //public AudioClip walkClip;
    public AudioClip jumpClip;
    public AudioSource source;

    CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = h * speed;
        float moveY = v * speed;
        Vector3 movement = new Vector3(moveX, 0, moveY);
        //Debug.Log($"{h}, {v}");
        movement = Vector3.ClampMagnitude(movement, speed);

        if (isGrounded() && velocity < 0)
        {
            velocity = -1;
        }
        else
        {
            velocity += gravity * gravityMultiplier * Time.deltaTime;
        }

        movement.y = velocity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        controller.Move(movement);
    }

    //Player is walking
    public void MoveInput(InputAction.CallbackContext ctx)
    {
        h = ctx.ReadValue<Vector2>().x;
        v = ctx.ReadValue<Vector2>().y;
        //source.PlayOneShot(walkClip);
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if(!isGrounded())
        {
            return;
        }

        if(ctx.performed)
        {
            source.PlayOneShot(jumpClip);
            velocity *= jumpStrength;
        }

    }

    bool isGrounded()
    {
        return controller.isGrounded;
    }
}
