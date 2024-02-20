using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner  : MonoBehaviour
{
    public GameObject[] Cars;
    public float maxPosition = 15.8f;
    public float minPosition = -28.4f;
    public static float delaytimer = 2f;
    public float timer;
    public int carNo;
    public static CarSpawner Instance;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
           // DontDestroyOnLoad(Instance);
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
            Vector3 carPos = new Vector3(Random.Range(minPosition, maxPosition), transform.position.y, transform.position.z);
            carNo = Random.Range(0, Cars.Length);
            Debug.Log("total  cars are ->   " + Cars.Length);
            Debug.Log(carNo + "  " + Cars[carNo]); 
            Instantiate(Cars[carNo], carPos, transform.rotation);

            timer = delaytimer;
            Debug.Log("in car spawner"+delaytimer);
        }
    }
}
