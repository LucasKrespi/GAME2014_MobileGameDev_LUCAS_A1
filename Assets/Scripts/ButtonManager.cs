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
        SceneManager.LoadScene(2);
    }
    public void MenutButton()
    {
        SceneManager.LoadScene(0);
    }
    public void PreviousButton()
    {
        SceneManager.LoadScene(currentScene.buildIndex - 1);
    }
    public void NextButton()
    {
        SceneManager.LoadScene(currentScene.buildIndex + 1);
    }
    public void InstructionsButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
