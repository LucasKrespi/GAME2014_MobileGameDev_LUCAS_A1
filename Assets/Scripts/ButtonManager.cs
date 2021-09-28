using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private Scene currentScene;
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }

   
    public void StartButton()
    {
        SceneManager.LoadScene(currentScene.buildIndex + 1);
    }
    public void PreviousButton()
    {
        SceneManager.LoadScene(currentScene.buildIndex - 1);
    }
    public void InstructionsButton()
    {
        Debug.Log("INSTRUCTIONS");
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
