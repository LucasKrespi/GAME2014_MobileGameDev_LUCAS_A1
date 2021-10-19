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
        RefreshSounds("start");
    }
    public void MenutButton()
    {
        SceneManager.LoadScene(0);
        RefreshSounds();
    }
    public void PreviousButton()
    {
        SceneManager.LoadScene(currentScene.buildIndex - 1);
        RefreshSounds();
    }
    public void NextButton()
    {
        SceneManager.LoadScene(currentScene.buildIndex + 1);
        RefreshSounds("next");
    }
    public void InstructionsButton()
    {
        SceneManager.LoadScene(1);
        RefreshSounds();
    }

    public void ExitButton()
    {
        RefreshSounds();
        Application.Quit();
    }

    private void RefreshSounds(string buttonFunc = "")
    {
    
       
        if(buttonFunc == "start")
        {
            SoundManager.GetSoundManagerInstance().StopAllSound();
            SoundManager.GetSoundManagerInstance().PlaySound("select");
            SoundManager.GetSoundManagerInstance().PlaySound("backgroundMusicGamePlay");
            return;
        }
        if (buttonFunc == "next")
        {
            SoundManager.GetSoundManagerInstance().StopAllSound();
            SoundManager.GetSoundManagerInstance().PlaySound("select");
            SoundManager.GetSoundManagerInstance().PlaySound("backgroundMusicMenu");
            return;
        }

        SoundManager.GetSoundManagerInstance().PlaySound("select");
        return;
    }
}
