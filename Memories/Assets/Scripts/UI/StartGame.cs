using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject death;
    public GameObject pause;


    void Awake() 
    {
        PlayerStats.death=false;
    }

    void Update()
    {
        if (PlayerStats.HP <= 0 && !PlayerStats.death)
        {
            GameObject.FindGameObjectWithTag("Player").SetActive(false);
            GetComponent<AudioSource>().Play();
            death.SetActive(true);
            PlayerStats.death = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                pause.SetActive(false);
                Time.timeScale = 1;
            } else if (Time.timeScale == 1) {
                pause.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void RestartGame()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
            GameObject.FindGameObjectWithTag("Player").SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ExitTheGame()
    {
        Application.Quit();
    }
}
