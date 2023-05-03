using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoveControl : MonoBehaviour
{
    public GameObject explosion;
    public float minSpeed = 4f;
    public float maxSpeed = 6f;

    private float moveSpeed;
    private Rigidbody rb;
    private GameObject target; 
    private Vector3 directionToTarget;

    private TimerControl timerControl;

    void Start()
    {
        target = GameObject.Find("Player");
        timerControl = GameObject.Find("TimerControl").gameObject.GetComponent<TimerControl>();
        rb = GetComponent<Rigidbody>();
        moveSpeed = Random.Range(minSpeed, maxSpeed);
    }

    void Update()
    {
        MoveMonster();

        if(timerControl.timeValue < 120f && timerControl.timeValue > 90f)
        {
            minSpeed = 2f;
            maxSpeed = 2f;
        }

        else if(timerControl.timeValue < 90f && timerControl.timeValue > 60f)
        {
            minSpeed = 4f;
            maxSpeed = 4f;
        }

        else if (timerControl.timeValue < 60f && timerControl.timeValue > 30f)
        {
            minSpeed = 6f;
            maxSpeed = 6f;
        }

        else if (timerControl.timeValue < 30f && timerControl.timeValue > 0f)
        {
            minSpeed = 8f;
            maxSpeed = 8f;
        }

        else if (timerControl.timeValue <= 0)
        {
            ObjectSpawnerControl.spawnAllowed = false;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
                ObjectSpawnerControl.spawnAllowed = false;
                Instantiate(explosion, collision.gameObject.transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
                target = null;
                timerControl.losePanel.SetActive(true);
        }
    }

    public void MoveMonster() 
    {
        if(target != null)
        {
            float h = 2f;
            float w = 2f;

            directionToTarget = (target.transform.position - transform.position).normalized;
            rb.velocity = new Vector2(directionToTarget.x * moveSpeed, directionToTarget.y * moveSpeed);
            rb.AddTorque(transform.up * h);
            rb.AddTorque(transform.right * w);

        }
        else
        {
            rb.velocity = Vector3.zero;
        }

        //if (gameObject.transform.position.x < 0)
        //{
        //    gameObject.GetComponent<SpriteRenderer>().flipX = false;
        //}
        //else
        //{
        //    gameObject.GetComponent<SpriteRenderer>().flipX = true;
        //}
    }

}
