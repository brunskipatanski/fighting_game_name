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
            Debug.Log("we are Here!1");
            someGameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            someGameObject.SetActive(false);
        }
    }

    public void ResumeGame()
    {
        someGameObject.SetActive(false);
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}