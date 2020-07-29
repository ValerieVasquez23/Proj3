using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;
    public int _damageAmount;
    
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Update(){
        if(health > numOfHearts){
            health = numOfHearts;
        }
     
        for (int i = 0; i < hearts.Length; i++){
            if(i < health){
                hearts[i].sprite = fullHeart;
            } else{
                hearts[i].sprite = fullHeart;
            }
            if(i < numOfHearts){
                hearts[i].enabled = true;
            } else{
                hearts[i].enabled = false;
            }
        }

        /*if(Input.GetKeyDown(KeyCode.Space)){
            health -= 1;
        }*/
    }

    /*
    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Enemy" && health > 0)
        {
            DamagePlayer(_damageAmount);
        } 
            
        if(health <= 0) {
            KillPlayer();
        }
    }
    
    public void DamagePlayer(int _damageAmount)
    {
        //subtract from health
        health -= _damageAmount;
        Debug.Log("Health is: " + health);
    }

    public void KillPlayer(){
        Debug.Log("You're dead!");
    }
    */
}
