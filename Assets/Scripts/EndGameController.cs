using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameController : MonoBehaviour
{
    /// <summary>
    /// Time (in s) during which nothing can be done.
    /// </summary>
    public float NoTouchTimer = 2;

    private float noTouchCountdown;
    private bool isCountdownFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        noTouchCountdown = NoTouchTimer;    
    }

    // Update is called once per frame
    void Update()
    {
        if (isCountdownFinished)
        {
            // quit game on escape
            if (Input.GetKey(KeyCode.Escape))
                Application.Quit();

            // On any keypress, go back to the menu
            if (Input.anyKey)
                SceneManager.LoadScene(0);
        }
        else
        {
            noTouchCountdown -= Time.deltaTime;
            if (noTouchCountdown <= 0)
                isCountdownFinished=true;
        }
    }
}
