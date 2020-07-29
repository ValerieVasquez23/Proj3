using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    [SerializeField] AudioClip _tearLandingSound;
    public float lifeTime;
    void Start(){
        StartCoroutine(DeathDelay());
        transform.localScale = new Vector2(LevelController.BulletSize, LevelController.BulletSize);
    }

    IEnumerator DeathDelay(){
        yield return new WaitForSeconds(lifeTime);
        AudioHelper.PlayerClip2D(_tearLandingSound, 1);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other){

        
        
        if(other.tag == "Enemy"){
            Debug.Log("enemy shot!");
            other.gameObject.GetComponent<EnemyController>().Death();
            AudioHelper.PlayerClip2D(_tearLandingSound, 1);
            Destroy(gameObject);
        }
        
        if(other.tag == "Boundary"){
            Destroy(gameObject);
            AudioHelper.PlayerClip2D(_tearLandingSound, 1);
        }

    }
}
