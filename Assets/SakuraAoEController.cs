using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Manage collision between the AoE and trees, to trigger blooming.
/// </summary>
public class SakuraAoEController : MonoBehaviour
{
    public GameObject player;
    public GameObject tree;

    private PlayerController pc;
    private Type treeType;

    //**********************************************************

    // Start is called before the first frame update
    void Start()
    {
        pc = player.GetComponent<PlayerController>();
        treeType = tree.GetType();
    }

    //**********************************************************

    private void OnTriggerEnter(Collider other)
    {
        if (pc.IsSakuraTime && other.gameObject.GetType() == treeType)
        {
        }
    }
}
