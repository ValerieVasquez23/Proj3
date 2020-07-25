using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthUIController : MonoBehaviour
{
    public GameObject heartContainer;
    private float fillValue;


    void Update()
    {
        fillValue = (float)LevelController.Health;
        fillValue = fillValue / LevelController.MaxHealth;
        heartContainer.GetComponent<Image>().fillAmount = fillValue;
    }
}
