using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface displaying sakura time
/// </summary>
public interface ISakuraSubject
{
    // Attach an observer to the subject.
    void Attach(ISakuraObserver observer);

    // Detach an observer from the subject.
    void Detach(ISakuraObserver observer);

    // Notify all observers about an event.
    void Notify();
}
