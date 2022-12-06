using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linus : MonoBehaviour
{


    public int playerPosition;


    CharacterController controller;

    Vector3 forward; //frente & tras
    Vector3 strafe; //esquerda & direita
    Vector3 vertical; //pulo & gravidade

    float forwardSpeed = 1f;
    float strafeSpeed = 1f;


    void Start()
    {
        controller = GetComponent<CharacterController>();    
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            forwardSpeed = 2f;
            strafeSpeed = 2f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            forwardSpeed = 1f;
            strafeSpeed = 1f;
        }
        float fowardInput = Input.GetAxisRaw("Vertical");
        float strafeInput = Input.GetAxisRaw("Horizontal");

        // force = input * speed * direction
        forward = fowardInput * forwardSpeed * transform.forward;
        strafe = strafeInput * strafeSpeed * transform.right;

        Vector3 finalVelocity = forward + strafe + vertical;

        controller.Move(finalVelocity * Time.deltaTime);
        

    }

}
