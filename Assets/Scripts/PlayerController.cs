using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ParticleSystem particleSystem;

    /// <summary>
    /// Sakura timer in ms
    /// </summary>
    /// TODO: Put that to 0
    private float sakuraTimer = 30;
    private bool isSakuraTime = false;

    //**********************************************************

    // Start is called before the first frame update
    /*void Start()
    {
    }*/

    //**********************************************************

    // Update is called once per frame
    void Update()
    {
        if (sakuraTimer > 0 && Input.GetButton("Fire1"))
            this.ActivatePetals();
        else if (isSakuraTime)
        {
            isSakuraTime = false;
            var em = particleSystem.emission;
            em.enabled = false;
        }

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
        sakuraTimer = Math.Max(sakuraTimer - Time.deltaTime, 0);
        if (!isSakuraTime)
            ActivateSakuraPower();
        if (sakuraTimer <= 0)
        {
            DeactivateSakuraPower();
            sakuraTimer = 0;
        }
    }

    //**********************************************************

    private void ActivateSakuraPower()
    {
        var em = particleSystem.emission;
        em.enabled = true;
        isSakuraTime = true;
    }

    //**********************************************************

    private void DeactivateSakuraPower()
    {
        var em = particleSystem.emission;
        em.enabled = false;
        isSakuraTime = false;
    }


    //**********************************************************

    public float GetSakuraTimer() { return sakuraTimer; }
}
