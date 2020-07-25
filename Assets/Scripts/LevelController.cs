using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelController : MonoBehaviour
{

    public static LevelController instance;
    private static float health = 8;
    private static int maxHealth = 8;
    private static float moveSpeed = 300f;
    private static float fireRate = 0.5f;
    private static float bulletSize = 215f;
    public static float Health {get => health; set => health = value;}
    public static int MaxHealth{get => maxHealth; set => maxHealth = value;}
    public static float MoveSpeed {get => moveSpeed; set => moveSpeed = value;}
    public static float FireRate {get => fireRate; set => fireRate = value;}
    public static float BulletSize {get => bulletSize; set => bulletSize = value;}

    public Text healthText;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null){
            instance = this;
        }
    }

    public static void DamagePlayer(int damage){
        Health -= damage;
        if(Health <= 0){
            killPlayer();
        }

    }

    public static void HealPlayer(float healAmount){
        health = Mathf.Min(maxHealth, health + healAmount);
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

    }
}
