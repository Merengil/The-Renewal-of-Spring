using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
            OnButtonClick();
    }

    //**********************************************************

    /// <summary>
    /// Change scene.
    /// </summary>
    public void OnButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
