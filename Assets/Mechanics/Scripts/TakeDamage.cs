using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TakeDamage : MonoBehaviour
{
    public float health = 1;
    public UnityEvent takeDamage;
    public void TakeDamages(float damageValue)
    {
        health -= damageValue;
        if(health <= 0)
        {
            Die();

            if(takeDamage != null)
            takeDamage.Invoke();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
