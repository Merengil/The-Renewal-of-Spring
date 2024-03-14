using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SakuraValueController : MonoBehaviour, ISakuraObserver
{
    public GameObject player;

    private TextMeshProUGUI textmesh;

    // Start is called before the first frame update
    void Start()
    {
        PlayerController pc = player.GetComponent<PlayerController>();
        pc.Attach(this);
        textmesh = this.GetComponent<TextMeshProUGUI>();
        if (textmesh == null)
            throw new System.Exception("No TextMeshPro assigned to that text. Should never happen");
    }

    //**********************************************************

    public void SakuraUpdate(SakuraObserverObject sakuraObject)
    {
        textmesh.text = ((int)Math.Ceiling(sakuraObject.SakuraTime)).ToString();
    }

}
