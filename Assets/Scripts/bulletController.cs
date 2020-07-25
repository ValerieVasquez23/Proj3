using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    public float lifeTime;
    void Start(){
        StartCoroutine(DeathDelay());
        transform.localScale = new Vector2(LevelController.BulletSize, LevelController.BulletSize);
    }

    IEnumerator DeathDelay(){
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Enemy"){
            Debug.Log("enemy shot!");
            other.gameObject.GetComponent<EnemyController>().Death();
            Destroy(gameObject);
        }
        
        if(other.tag == "Boundary"){
            Destroy(gameObject);
        }
    }
}
