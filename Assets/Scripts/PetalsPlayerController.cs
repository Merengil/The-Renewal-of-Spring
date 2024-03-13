using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manage the petals particle effect on the player.
/// </summary>
public class PetalsPlayerController : MonoBehaviour
{
    private ParticleSystem petalsParticleSys;

    //**********************************************************

    // Start is called before the first frame update
    void Start()
    {
        petalsParticleSys = GetComponent<ParticleSystem>();
        var emission = petalsParticleSys.emission;
        emission.enabled = false;
    }

    //**********************************************************

    // Update is called once per frame
    /*void Update()
    {

    }*/
}
