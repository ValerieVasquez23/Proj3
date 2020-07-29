using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    [Header("Health System")]
    public int _health;
    public int _numofHearts;
    public Image[] _hearts;
    public Sprite _fullheart;
    public Sprite _emptyHeart;
    public int _deathCooldownTime = 5;
    public int _cooldownTime = 2;
    private bool _coolDownAttack = false;
    private bool _deathCoolDown = false;
    private bool IsDead = false;
    public int _deathDelay = 2;



    [Header("Sounds and Detail")]
    [SerializeField] AudioClip _PlayerHurtSound = null;
    [SerializeField] AudioClip _PlayerDeathSound = null;

    void Update(){
        
        //prevents the health from being greater than the number of heart containers
        if (_health > _numofHearts){
            _health = _numofHearts;
        }

        //for loop creates the hearts and displays them as either empty or full
        for(int i = 0; i < _hearts.Length; i++){
            if(i < _health){
                _hearts[i].sprite = _fullheart;
            } else {
                _hearts[i].sprite = _emptyHeart;
            }

            if(i < _numofHearts){
                _hearts[i].enabled = true;
            } else{
                _hearts[i].enabled = false;
            }
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            AddHeath();
        }
    }

    private IEnumerator OnTriggerStay2D(Collider2D other){
        if(other.gameObject.tag == "Enemy"){
            if(_health > 0){
                if(!_coolDownAttack){
                    Debug.Log("Health = " + _health);
                    AudioHelper.PlayerClip2D(_PlayerHurtSound, 1);
                    _health -= 1;
                    _coolDownAttack = true;
                    
                    yield return new WaitForSeconds(_cooldownTime);
                    _coolDownAttack = false;
                }
            }
            else if(_health <= 0 && !IsDead)
            {   
                if(!_coolDownAttack){
                IsDead = true;
                // play the audio, then wait for the death cooldown before changing scenes
                Debug.Log("You DIED!");
                //play death sound at volume 1
                AudioHelper.PlayerClip2D(_PlayerDeathSound, 1);
                
                //wait for the delay, then play kill
                yield return new WaitForSeconds(_deathDelay);
                Death();
                }
            }
        }
    }

    void Death(){
        
        SceneManager.LoadScene("YoureDead", LoadSceneMode.Single);
    }
    private IEnumerator AttackCoolDown(){
        _coolDownAttack = true;
        yield return new WaitForSeconds(_cooldownTime);
        _coolDownAttack = false;
    }

    void AddHeath(){
        _numofHearts += 1;
        _health += 1;
    }

}
