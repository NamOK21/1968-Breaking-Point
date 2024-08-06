using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Player playerHealth;
    [SerializeField] private Image totalhealthbar;
    [SerializeField] private Image currenthealthbar;
     
    private void Start()
    {
        totalhealthbar.fillAmount = playerHealth.health;
    }

    private void Update()
    {
        currenthealthbar.fillAmount = playerHealth.health/100;
    }
}
