using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject Player;
    public static LevelController instance;
    private static int maxHealth = 6;
    private static float moveSpeed = 300f;
    private static float fireRate = 0.5f;
    private static float bulletSize = 215f;

    public static float MoveSpeed {get => moveSpeed; set => moveSpeed = value;}
    public static float FireRate {get => fireRate; set => fireRate = value;}
    public static float BulletSize {get => bulletSize; set => bulletSize = value;}

    //private Health health;

    // Start is called before the first frame update
    void Awake()
    {
       //health = Player.GetComponent<Health>();

        if(instance == null){
            instance = this;
        }
    }

    public static void Breakfast(float healAmount){
       //health = Mathf.Min(maxHealth, health + healAmount);
        //maxHealth += 2;
    }

    public static void MoveSpeedChange(float speed){
        moveSpeed += speed;
    }

    public static void FireRateChange(float rate){
        fireRate -= rate;
    }
    public static void BulletSizeChange (float size){
        bulletSize += size;
    }

    private static void killPlayer(){
        Debug.Log("Youre Dead!!!!");
    }

    void Update(){
        //healthtext.text = "Health:" + health + "/" + maxHealth;
    }
}
