using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Transform target;
    private GameManager gameManager;

    private NavMeshAgent agent;

    private bool followPlayer = true;

    private Rigidbody2D enemyRb;

    public float collisionSpeed;

    private float dontFollowTime = 2f;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        enemyRb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player").transform;
        followPlayer = true;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (followPlayer && !gameManager.isGamePaused)
        {
            agent.SetDestination(target.position);
        }

        if(!followPlayer)
        {
            timer += Time.deltaTime;
            if(timer > dontFollowTime)
            {
                followPlayer = true;
                timer = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.CompareTag("Ray"))
        {
            followPlayer = false;

            Vector2 lookDirection = (transform.position - collision.transform.position).normalized;

            enemyRb.AddForce(lookDirection * collisionSpeed, ForceMode2D.Impulse);
        }
    }
}
