using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Basic_FallBack_stage");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game has been quit!");
    }

    public void SoundVolume()
    {

    }
}
