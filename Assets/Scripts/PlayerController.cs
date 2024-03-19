using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, ISakuraSubject
{
    public ParticleSystem[] particleSystemPetal;

    /// <summary>
    /// Sakura timer in s
    /// </summary>
    private float sakuraTimer = 0;
    private bool isSakuraTime = false;
    private readonly List<ISakuraObserver> _observers = new();
    private SakuraObserverObject sakuraObject = new();

    //**********************************************************

    // Start is called before the first frame update
    void Start()
    {
        Notify();
    }

    //**********************************************************

    // Update is called once per frame
    void Update()
    {
        if (sakuraTimer > 0 && Input.GetButton("Fire1"))
            this.KeepSakuraTimeOn();
        else if (isSakuraTime)
        {
            DeactivateSakuraTime();
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
        Notify();
    }

    //**********************************************************

    /// <summary>
    /// Activates Sakura time on button press
    /// </summary>
    private void KeepSakuraTimeOn()
    {
        sakuraTimer = Math.Max(sakuraTimer - Time.deltaTime, 0);
        if (!isSakuraTime)
            ActivateSakuraTime();
        if (sakuraTimer <= 0)
        {
            DeactivateSakuraTime();
            sakuraTimer = 0;
        }
        Notify();
    }

    //**********************************************************

    private void ActivateSakuraTime()
    {
        foreach(var particle in particleSystemPetal)
        {
            var em = particle.emission;
            em.enabled = true;
        }
        isSakuraTime = true;
    }

    //**********************************************************

    private void DeactivateSakuraTime()
    {
        foreach (var particle in particleSystemPetal)
        {
            var em = particle.emission;
            em.enabled = false;
        }
        isSakuraTime = false;
    }

    //**********************************************************

    /// <summary>
    /// Getter for isSakuraTime.
    /// </summary>
    public bool IsSakuraTime { get { return isSakuraTime; } }

    //**********************************************************

    /// <summary>
    /// Returns whether Sakura time can be activated or not.
    /// </summary>
    public bool HasSakuraPowerLeft { get { return (sakuraTimer > 0); } }

    //**********************************************************

    public float GetSakuraTimer() { return sakuraTimer; }

    //**********************************************************

    // Attach an observer to the subject.
    public void Attach(ISakuraObserver observer)
    {
        this._observers.Add(observer);
    }

    //**********************************************************

    // Detach an observer from the subject.
    public void Detach(ISakuraObserver observer)
    {
        this._observers.Remove(observer);
    }

    //**********************************************************

    // Notify all observers about an event.
    public void Notify()
    {
        sakuraObject.SakuraTime = this.sakuraTimer;
        foreach (var observer in _observers)
            observer.SakuraUpdate(sakuraObject);
    }
}
