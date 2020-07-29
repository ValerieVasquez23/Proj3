using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum LastButton{
    Left,
    Right,
    Up,
    Down
}

public class PlayerController : MonoBehaviour
{
    
    private Rigidbody2D rb;
    public float maxSpeed = 5f;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    private float lastFire;
    public float fireDelay;
    //CameraMovement cameraMovement;
    private LastButton LastButtonPressed;

    void Awake(){
        //find the rigidbody component
        rb = GetComponent<Rigidbody2D>();
    }


    void Update(){
        fireDelay = LevelController.FireRate;
        maxSpeed = LevelController.MoveSpeed;
        float shootH = Input.GetAxis("ShootHorizontal");
        float shootV = Input.GetAxis("ShootVertical");

        //resolve sw, se, nw, ne shooting directions
        if(shootH < 0){
            LastButtonPressed = LastButton.Left;
        } else if(shootH > 0){
            LastButtonPressed = LastButton.Right;
        } else if(shootV < 0){
            LastButtonPressed = LastButton.Down;
        } else if(shootV > 0){
            LastButtonPressed = LastButton.Up;
        }
        
        if(Mathf.Abs(shootH) > Mathf.Abs(shootV)){
            shootV = 0;
        }

        if(Mathf.Abs(shootV) > Mathf.Abs(shootH)){
            shootH = 0;
        }
        if(Mathf.Abs(shootV) == Mathf.Abs(shootH)){
            switch(LastButtonPressed){
                case LastButton.Left:
                shootV = 0;
                break;
                case LastButton.Right:
                shootV = 0;
                break;
                case LastButton.Down:
                shootH = 0;
                break;
                case LastButton.Up:
                shootH = 0;
                break;
            }
        }

        if((shootH != 0 || shootV != 0) && Time.time > lastFire + fireDelay)
        {
                Shoot(shootH, shootV);
                lastFire = Time.time;
                Debug.Log("Tear Fired");
        }
    }
    void FixedUpdate(){
        //calculate vertical and horizontal movement
        float vMoveAmount = Input.GetAxisRaw("Vertical") * Time.fixedDeltaTime;
        float hMoveAmount = Input.GetAxisRaw("Horizontal") * Time.fixedDeltaTime;

        //create the vector for the direction and apply it to the position
        Vector2 direction = new Vector2(hMoveAmount, vMoveAmount).normalized;
        rb.MovePosition(rb.position + (direction * maxSpeed * Time.fixedDeltaTime));
    }

    void Shoot(float x, float y)
    {   
        //when shooting, create object prefab
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
        bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(
            (x < 0) ? Mathf.Floor(x) * bulletSpeed : Mathf.Ceil(x) * bulletSpeed,
            (y < 0) ? Mathf.Floor(y) * bulletSpeed : Mathf.Ceil(y) * bulletSpeed,
            0
        );
    }

}
