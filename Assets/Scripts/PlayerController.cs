using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// Sakura timer in ms
    /// </summary>
    private float sakuraTimer = 0;
    private bool isSakuraTime = false;
    private PlayerControls controls;

    /// <summary>
    /// Called on initialization
    /// </summary>
    private void Awake()
    {
        controls = new PlayerControls();
        controls.Player.Fire.performed += ctx => ActivatePetals();

    }

    //**********************************************************

    // Start is called before the first frame update
    /*void Start()
    {
    }*/

    //**********************************************************

    // Update is called once per frame
    void Update()
    {
    }

    //**********************************************************

    /// <summary>
    /// Increase the sakura timer.
    /// </summary>
    /// <param name="addedTimeCounter"></param>
    internal void IncreaseCounter(float addedTimeCounter)
    {
        sakuraTimer += addedTimeCounter;
    }

    //**********************************************************

    /// <summary>
    /// Activates Sakura time on button press
    /// </summary>
    private void ActivatePetals()
    {
        Debug.Log("Button Pressed");
        if (sakuraTimer > 0)
        {
            sakuraTimer = Math.Max(sakuraTimer - Time.deltaTime, 0);
            isSakuraTime = true;
            if (sakuraTimer <= 0)
            {
                isSakuraTime = false;
                sakuraTimer = 0;
            }
        }
    }

    //**********************************************************

    private void OnEnable()
    {
        controls.Player.Enable();
    }

    //**********************************************************

    private void OnDisable()
    {
        controls.Player.Disable();
    }

    //**********************************************************

    public float GetSakuraTimer() { return sakuraTimer; }
}
