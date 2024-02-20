using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class uiscript : MonoBehaviour
{
    public static uiscript Instance;
    public GameObject menu;
    public GameObject play;
    public GameObject exit;
    public GameObject restart;
    public GameObject main;
    public GameObject gameover;
    public GameObject winner;
    public GameObject RestartGameOver;   
    /*public GameObject gameOver;*/
    public bool isGamePause;
    
    public TMP_Text score;
    public TMP_Text totalscore;
    public TMP_Text fuel;
    public TMP_Text speedUI;



    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        play.SetActive(false);
        exit.SetActive(false);
        restart.SetActive(false);
        

    }


    // Start is called before the first frame update

    void Start()
    {
        Time.timeScale = 1f;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gameover.activeSelf)
        {
            pauseNplay();
        }
        
    }
    public void pauseNplay()
    {
        isGamePause = !isGamePause;

        if (isGamePause)
        {
            Time.timeScale = 0f;    //Pause
            menu.SetActive(false);
            play.SetActive(true);
            exit.SetActive(true);
            restart.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f; //play
            play.SetActive(false);
            menu.SetActive(true);
            exit.SetActive(false);
            restart.SetActive(false);
        }
    }
    public void restartButton()
    {
        SceneManager.LoadScene(1);

    }
    public void exitButton()
    {
        SceneManager.LoadScene(0);
    }
    public void mainmenu()
    {
        SceneManager.LoadScene(0);
    }
   

}
