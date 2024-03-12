using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    /// <summary>
    /// Sakura timer in ms
    /// </summary>
    private int sakuraTimer = 0;

    // Start is called before the first frame update
    /*void Start()
    {
    }

    //**********************************************************

    // Update is called once per frame
    void Update()
    {

    }*/

    //**********************************************************

    /// <summary>
    /// Increase the sakura timer.
    /// </summary>
    /// <param name="addedTimeCounter"></param>
    internal void IncreaseCounter(int addedTimeCounter)
    {
        sakuraTimer += addedTimeCounter;
    }
}
