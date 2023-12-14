using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    void Update()
    {
        
    }

    public void DestroyRay()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
    }

}
