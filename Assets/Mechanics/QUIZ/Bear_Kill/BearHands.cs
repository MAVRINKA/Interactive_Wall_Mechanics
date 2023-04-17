using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearHands : MonoBehaviour
{
    public GameObject[] HeroLife;
    public int LifeGone;


    private void Start()
    {
        LifeActive();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            LifeGone++;
            HeroLife[LifeGone].SetActive(true);
            Debug.Log("Goal");
            //Destroy(Instantiate(goalParticle, transform.position, Quaternion.identity), 2f);

        }

        //GameObj isDead
        //if(isDead != false)
        //{
        //    Die();
        //}


    }

    //public void Die()
    //{
    //    gameObject.SetActive(false);
    //    //Destroy(Instantiate(deadParticle, transform.position, Quaternion.identity), 2f);
    //}

    //public void OnTriggerEnter(Collider collision)
    //{

    //    if (collision.gameObject.CompareTag("Enemy") && LifeGone > 0)
    //    {
    //        Destroy(collision.gameObject);
    //        LifeActive();
    //    }

    //}

    public void LifeActive()
    {
        LifeGone++;
        HeroLife[LifeGone].SetActive(true);
        Debug.Log("Goal");
        //Destroy(Instantiate(collisionParticle, transform.position, Quaternion.identity), 2f);
    }
}
