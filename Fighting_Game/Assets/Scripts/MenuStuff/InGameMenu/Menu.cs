using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] public GameObject someGameObject;

    // Start is called before the first frame update
    void Start()
    {
        // Make sure the name provided to GameObject.Find matches the object's name exactly.
        // someGameObject = GameObject.Find("InGameMenu");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !someGameObject.activeSelf)
        {
            someGameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            someGameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void ResumeGame()
    {
        someGameObject.SetActive(false);
        Time.timeScale = 1;

    }

    public void ToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}