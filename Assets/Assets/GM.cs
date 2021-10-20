using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    private static GM GMInstance;
    private GameObject player;
    public List<Image> livesImages;

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
       
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerBehavior>().lives < 1)
            SceneManager.LoadScene(3);
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
