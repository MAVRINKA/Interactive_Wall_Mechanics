using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldLife : MonoBehaviour
{
    [Header("LifePlayer")]
    public GameObject[] HeroLife;

    public GameObject deadParticle;
    public GameObject collisionParticle;
    public int LifeGone;


    private void Update()
    {
        if (LifeGone <= 0)
        {
            //Debug.Log("GAME OVER");
            //isDead = true;
            Die();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            LifeGone--;
            HeroLife[LifeGone].SetActive(false);
            Debug.Log("Goal");
            //Destroy(Instantiate(goalParticle, transform.position, Quaternion.identity), 2f);

        }

        //GameObj isDead
        //if(isDead != false)
        //{
        //    Die();
        //}

     
    }

    public void Die()
    {
        gameObject.SetActive(false);
        Destroy(Instantiate(deadParticle, transform.position, Quaternion.identity), 2f);
    }

    public void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.CompareTag("Enemy") && LifeGone > 0)
        {
            Destroy(collision.gameObject);
            LifeActive();

        }

    }

    public void LifeActive()
    {
        LifeGone--;
        HeroLife[LifeGone].SetActive(false);
        Debug.Log("Goal");
        Destroy(Instantiate(collisionParticle, transform.position, Quaternion.identity), 2f);
    }
}
