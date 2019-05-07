using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject hint;
    public GameObject death;


    void Awake() 
    {
        if (PlayerStats.death)
        {
            hint.SetActive(false);
            PlayerStats.death=false;
        }
    }

    void Start() 
    {
        if (hint.activeInHierarchy)
            Time.timeScale=0;
        else Time.timeScale=1;
    }

    void Update()
    {
        if (hint.activeInHierarchy && Input.anyKeyDown)
        {
            hint.SetActive(false);
            Time.timeScale=1;
        }
        if (PlayerStats.HP <= 0 && !PlayerStats.death)
        {
            GameObject.FindGameObjectWithTag("Player").SetActive(false);
            GetComponent<AudioSource>().Play();
            death.SetActive(true);
            PlayerStats.death = true;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
