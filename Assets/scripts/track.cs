using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class track : MonoBehaviour
{
    public float speed = 1;
    Vector2 offset;
    float  score = 0;
    float fact = 1;
    public static track Instance;
    float fuel = 100;
    float fuelVal;
    float speedVal;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        print("I am in Awake");
    }

    // Start is called before the first frame update
    void Start()
    {
       // StartCoroutine(playerSpeed());
    }

    // Update is called once per frame
    void Update()
    {


        offset = new Vector2(0, Time.time * speed);

        if (!uiscript.Instance.isGamePause && !uiscript.Instance.gameover.gameObject.activeSelf)
        {
            score = score + 1 + speed;
            fuel -= 0.08f;

        }

        score = (int)score;
        fuelVal = (int)fuel;
        speedVal = (int)(speed * 100 -100);
        if (speedVal < 0) speedVal = 0; 
        uiscript.Instance.score.SetText("Score : " + score.ToString());
        uiscript.Instance.fuel.SetText("Fuel : " + fuelVal.ToString());
        uiscript.Instance.speedUI.SetText("Speed : "+ speedVal.ToString());


        GetComponent<Renderer>().material.mainTextureOffset = offset;

        if (score >= 10000)
        {
            Debug.Log("winner");

            uiscript.Instance.main.gameObject.SetActive(true);
            Debug.Log(uiscript.Instance.totalscore.text);

            SceneManager.LoadScene(2);

            Time.timeScale = 0;
        }
        speed += 0.008f * Time.deltaTime;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            speed += 0.04f * Time.deltaTime;
            Debug.Log("Speed up  : " + speed);
        }
        else
        {
            if ( speedVal > 20)
            {
                speed -= 0.02f * Time.deltaTime;
                Debug.Log("Speed down  : " + speed);
            }
           

        }


        if (PlayerCar.instance != null && fuel < 0)
        {
            PlayerCar.instance.GameOver();
        }
    }
    /*IEnumerator playerSpeed()
    {
        yield return new WaitForSeconds(1f);
        speed += 0.05f;
        
        StartCoroutine(playerSpeed());
    }*/
    public void IncreaseFuel()
    {
        Debug.Log("Before Updating " +  fuel);
        fuel = fuel + 10;
        Debug.Log("Inside fuel increament ");
        Debug.Log("After Updating " + fuel);
       

    }
    IEnumerator fuelUpdation()
    {
        yield return new WaitForSeconds(2);
        fuel -= 1;
        StartCoroutine(fuelUpdation());

    }
}
