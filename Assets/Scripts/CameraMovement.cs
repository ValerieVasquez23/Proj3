using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform room1Position = null;
    public Transform room2Position = null;
    public float smoothTime = 0.3f;
    public Vector3 velocity = Vector3.zero;
    public Camera mainCamera;
    bool enteringRoom1 = false;  
    bool enteringRoom2 = false;
    void Update()
    {
        if(enteringRoom2){
            SwitchingtoRoom2();
            enteringRoom2 = false;
        }

        if(enteringRoom1){
            SwitchingtoRoom1();
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.name == "Player" && this.gameObject.name == "Room1Switcher"){
            enteringRoom2 = true;
            Debug.Log("Hit room 1 trigger");
        }

        if(other.gameObject.tag == "Player"){
            enteringRoom1 = true;
            Debug.Log("Hit room 1 trigger");
        }        
    }
    public void SwitchingtoRoom2()
    {
        mainCamera.transform.position = Vector3.SmoothDamp(mainCamera.transform.position, room2Position.position, ref velocity, smoothTime);
    }
        public void SwitchingtoRoom1()
    {
        mainCamera.transform.position = Vector3.SmoothDamp(mainCamera.transform.position, room1Position.position, ref velocity, smoothTime);
    }
}
