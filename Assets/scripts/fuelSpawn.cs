using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuelSpawn : MonoBehaviour
{
    public GameObject fuel;

    public static float delaytimer = 4f;
    
    float timer;
    public static fuelSpawn Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
    }


    // Start is called before the first frame update
    void Start()
    {
        timer = delaytimer;
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Vector3 fuelPos = new Vector3(Random.Range(-28.4f, 15.8f), transform.position.y,0);
           
            Debug.Log("In fuel spawner");
            Instantiate(fuel ,fuelPos, transform.rotation);

            timer = delaytimer;
            Debug.Log("in car spawner" + delaytimer);
        }
    }
}
