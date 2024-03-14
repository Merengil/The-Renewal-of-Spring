using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

/// <summary>
/// Interface for getting sakura time
/// </summary>
public interface ISakuraObserver
{
    // Receive update from subject
    void SakuraUpdate(SakuraObserverObject sakuraObject);
}
