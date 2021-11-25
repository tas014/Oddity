using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public float speed = 5f;

    Vector3 velocity;
    public float gravity = -9.81f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float X = Input.GetAxis("Horizontal");
        float Z = Input.GetAxis("Vertical");

        //transform modifica el vector relativo a la direccion de la camara, new Vector3 crearia coordenadas globales
        Vector3 move = transform.right*X + transform.forward*Z;

        controller.Move(move * speed * Time.deltaTime);

        if(velocity.y < 100) {
            velocity.y += gravity * Time.deltaTime;
        } 
        controller.Move(velocity * Time.deltaTime);
    }
}
