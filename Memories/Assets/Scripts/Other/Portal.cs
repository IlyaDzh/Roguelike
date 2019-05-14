using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    private bool enter=false;
    private GameObject m;

    private void Update() 
    {
        if (enter && Input.GetKeyDown(KeyCode.E)) 
        {
            m.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        m = other.gameObject;
        enter = true;
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        enter = false;
    }
}
