using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    Wander,
    Follow,
    Die,
    Attack
};

public class EnemyController : MonoBehaviour
{
    GameObject player;
    public EnemyState currState = EnemyState.Wander;
    public float range;
    public float speed;
    public float attackRange;
    public float coolDownTime;
    private bool coolDownAttack = false;
    private bool chooseDir = false;
    //private bool dead = false;
    private Vector3 randomDirection;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");    
    }

    // Update is called once per frame
    void Update()
    {
        switch(currState){
            case(EnemyState.Wander):
                Wander();
            break;
            case(EnemyState.Follow):
                Follow();
            break;
            case(EnemyState.Die):

            break;
            case(EnemyState.Attack):
                Attack();
            break;
        }

        if(IsPlayerInRange(range) && currState != EnemyState.Die){
            currState = EnemyState.Follow;
        }
        else if(!IsPlayerInRange(range) && currState != EnemyState.Die){
            currState = EnemyState.Wander;
        }

        if(Vector3.Distance(transform.position, player.transform.position) <= attackRange){
            currState = EnemyState.Attack;
        }
    }

    private IEnumerator ChooseDirection(){
        chooseDir = true;
        yield return new WaitForSeconds(Random.Range(2f, 8f));
        randomDirection = new Vector3(0,0, Random.Range(0,360));
        Quaternion nextRotation = Quaternion.Euler(randomDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, nextRotation, Random.Range(0.5f, 2.5f));
        chooseDir = false;
    }

    private bool IsPlayerInRange(float range){
        return Vector3.Distance(transform.position, player.transform.position) <= range;
    }

    void Wander(){
        if  (!chooseDir){
            StartCoroutine(ChooseDirection());
        }

        transform.position += transform.right * speed * Time.deltaTime;
        if(IsPlayerInRange(range)){
            currState = EnemyState.Follow;
        }
    }

    void Follow(){
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
    
    void Attack(){
        if(!coolDownAttack){
            //Health.DamagePlayer(1);
            StartCoroutine(CoolDown());
        }
    }

    private IEnumerator CoolDown()
    {
        coolDownAttack = true;
        yield return new WaitForSeconds(coolDownTime);
        coolDownAttack = false;
    }


    public void Death(){
        Destroy(gameObject);
    } 
}
