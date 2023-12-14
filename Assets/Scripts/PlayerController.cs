using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private GameManager gameManager;
    public float moveSpeed;
    public GameObject rayPrefab;

    public float collisionSpeed;

    public Transform rayParentTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>() ;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.isGamePaused)
        {
            PlayerMovement();
            FollowMouseCursor();
            FireRay();
        }
    }

    void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.up * Time.deltaTime * verticalInput * moveSpeed);
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * moveSpeed);
    }

    void FollowMouseCursor()
    {
        Vector2 Lookdirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        float angle = Mathf.Atan2(Lookdirection.y, Lookdirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void FireRay()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject ray = Instantiate(rayPrefab, rayParentTransform.position, rayParentTransform.transform.rotation);
            ray.transform.SetParent(rayParentTransform);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision.gameObject.CompareTag("Wall"))
        //{
        //    gameManager.GameOver();
        //}

        if(collision.gameObject.CompareTag("Enemy"))
        {
            Vector2 lookDirection = (transform.position - collision.transform.position).normalized;

            playerRb.AddForce(lookDirection * collisionSpeed, ForceMode2D.Impulse);
        }
    }
}
