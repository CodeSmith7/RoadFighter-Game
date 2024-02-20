using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuelBox : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
   
    void Start()
    {

    }
        
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            speed += 0.04f * Time.deltaTime;
            Debug.Log("Speed up  : " + speed);
        }
        transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);    
        }
    }
}
