using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject hint;

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
            Destroy(this);
        }
    }
}
