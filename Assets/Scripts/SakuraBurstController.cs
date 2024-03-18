using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Destroys the particle system when it finishes playing.
/// </summary>
public class SakuraBurstController : MonoBehaviour
{
    private new ParticleSystem particleSystem;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        particleSystem.Play(); // Start the particle system.
        Debug.Log("Particle started");
    }

    //**********************************************************

    private void Update()
    {
        if (!particleSystem.isPlaying)
        {
            Debug.Log("Particle stopped");
            GameObject.Destroy(this.gameObject);
        }
    }
}
