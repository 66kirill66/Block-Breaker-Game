using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    private Rigidbody2D _rb2D;

    [SerializeField] int jumpForse = 50;
    [SerializeField] int currentCubs = 18;
    [SerializeField] Canvas canvasStart;
    [SerializeField] ParticleSystem breake;
    [SerializeField] Transform player;
    public bool inPlay;
    public bool isJump;

    void Start()
    {
        Time.timeScale = 0;
        canvasStart.enabled = true;
        _rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {       
        BallPositionOnGame();
        RespondToDebugKeeys();
        WinGame();     
    }
    void FixedUpdate()
    {
        MooveUp();
    }
    void BallPositionOnGame()
    {
        if (!inPlay)
            transform.position = player.transform.position;
    }
    void MooveUp()
    {
        if (Input.GetKey(KeyCode.Space) & !isJump)
        {
            inPlay = true;
            _rb2D.AddForce(Vector2.up * jumpForse);
        }       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        switch (collision.gameObject.tag)
        {
            case "Player":

                Debug.Log("!!!");
                break;

            case "Cube":
                isJump = true;
                Vector2 plase = collision.gameObject.transform.position;
                Instantiate(breake, plase, breake.transform.rotation);
                Destroy(collision.gameObject) ;
                currentCubs--;              
                break;

            case "wall":
                Time.timeScale = 0f;
                ReloadLevel();
                break;
        }
    }
    private void WinGame()
    {
        if(currentCubs == 0)
        {
            Time.timeScale = 0;
            NextLevel();   
        }
    }
    void ReloadLevel()
    {
        int CarrentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CarrentScene);
    }
     void NextLevel( )
    {
        int CarrentScene = SceneManager.GetActiveScene().buildIndex;
        int NextSceneIndex = CarrentScene + 1;
        if (NextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            NextSceneIndex = 0;
        }
        SceneManager.LoadScene(NextSceneIndex);
    }
    public void StartGame()
    {
        Time.timeScale = 1;
        canvasStart.enabled = false;
    }
    private void RespondToDebugKeeys()  // Hot Keys
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            NextLevel();
        }
    }
}
