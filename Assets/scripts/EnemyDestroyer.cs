using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemycar"))
        {
           // Debug.Log("I am in detroyer ");
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("fuel"))
        {
            Destroy(collision.gameObject);
        }
        
    }
}
