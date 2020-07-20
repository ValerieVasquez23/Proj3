using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public int maxSpeed = 5;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate(){
        //calculate vertical and horizontal movement
        float vMoveAmount = Input.GetAxisRaw("Vertical") * Time.fixedDeltaTime;
        float hMoveAmount = Input.GetAxisRaw("Horizontal") * Time.fixedDeltaTime;

        //create the vector for the direction and apply it to the position
        Vector2 direction = new Vector2(hMoveAmount, vMoveAmount).normalized;
        rb.MovePosition(rb.position + (direction * maxSpeed * Time.fixedDeltaTime));
    }


    /*
    void Update()
    {
        playerMovement();
    }

    void playerMovement(){

        //Horizontal Movement
        float zMoveAmount= 
        zMoveAmount = Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime;
        transform.Translate(zMoveAmount, 0, 0);
        
        //Vertical Movement
        float yMoveAmount= 
        yMoveAmount = Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime;
        transform.Translate(0, yMoveAmount, 0);
    }
    */
}
