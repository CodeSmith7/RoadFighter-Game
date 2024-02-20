using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class enemyCar : MonoBehaviour
{
    public float speed; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed += track.Instance.speed * 0.01f ;
        float clampedX = Mathf.Clamp(transform.position.x, -7.69f, 3.61f);


        transform.Translate(new Vector3 (0, 1, 0) * speed * Time.deltaTime);

        /* if (CarSpawner.Instance.carNo != 9)
         {
             transform.Translate(new Vector3(clampedX, 0, 0) * Time.deltaTime);
         }*/
       

    }
}
