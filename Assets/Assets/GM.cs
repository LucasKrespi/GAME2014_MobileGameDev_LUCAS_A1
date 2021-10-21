using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    private static GM GMInstance;
    private GameObject player;
    private PlayerBehavior playerBehavior;
    public List<Image> livesImages;
    public Text timerText;
    private int timer;
    public Text score;
    private int initialTime = 120;

    private void Awake()
    {
        if (GMInstance == null)
        {
            GMInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerBehavior = player.GetComponent<PlayerBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if  (playerBehavior.coopCount > 4)
        {
            //10 points for everybeat on the clock + 1000 points for the 5 coops being full
            playerBehavior.addScore(timer * 10 + 1000);
            initialTime = 120;
            SceneManager.LoadScene(3);
            PlayerPrefs.SetInt("score", playerBehavior.score);
        }
        if (playerBehavior.lives < 1 || timer < 0)
        {
            initialTime = 120;
            SceneManager.LoadScene(3);
            PlayerPrefs.SetInt("score", playerBehavior.score);
        }

        timer = initialTime - (int)Time.timeSinceLevelLoad;
        
        timerText.text = timer.ToString();

        score.text = "Score: " + playerBehavior.score;
    }

    public void UpdateLivesDisplay(int currentLives)
    {
        livesImages[currentLives].enabled = false;
    }
    
    public static GM getGMInstance()
    {
        return GMInstance;
    }
}
