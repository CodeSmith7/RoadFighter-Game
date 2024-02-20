using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class PlayerCar : MonoBehaviour
{
    public float carSpeed;
    public float carSpeedVertical;
    Vector2 position;
    public static PlayerCar instance;

    public Animator animation;
    Collider2D col;
    

    private void Awake()
    {
        instance = this;   
        
    }
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        animation = GetComponent<Animator>();
        col = GetComponent<Collider2D>();       
        animation.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        string textscore = uiscript.Instance.score.text;

        /*position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;

       
        transform.position = position;*/
        if (Input.anyKey)
        {
            float x = Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;
            transform.Translate(x, 0, 0);

            Debug.Log("Inside Player Movement");


            float clampedX = Mathf.Clamp(transform.position.x, -28.4f, 15.8f);
            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

            uiscript.Instance.totalscore.SetText("Total " + textscore);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemycar") )
        {
            animation.enabled = true;
            StartCoroutine(blast());
        }
        if (collision.gameObject.CompareTag("fuel"))
        {
            track.Instance.IncreaseFuel();
            //fuelSpawn.Instance.fuel.gameObject.SetActive(false);
        }
    }
    public void GameOver ()
    {
        Destroy(gameObject);
        /*uiscript.Instance.gameOver.gameObject.SetActive(true);
        uiscript.Instance.pauseNplay();
*/
        //SceneManager.LoadScene(0);
        Time.timeScale = 0;

        uiscript.Instance.totalscore.gameObject.SetActive(true);

        uiscript.Instance.main.SetActive(true);
        uiscript.Instance.score.gameObject.SetActive(false);
        uiscript.Instance.gameover.gameObject.SetActive(true);
        uiscript.Instance.RestartGameOver.gameObject.SetActive(true);
        uiscript.Instance.menu.SetActive(false);
        uiscript.Instance.speedUI.gameObject.SetActive(false);
        Debug.Log("total score is ->  " + uiscript.Instance.totalscore.text);
       // Time.timeScale = 0;
    }
    IEnumerator blast ()
    {

        animation.Play("blast");
        track.Instance.speed = 0;
        col.enabled = false;    
        yield return  new WaitForSeconds(1);
        GameOver();

    }
   
}
