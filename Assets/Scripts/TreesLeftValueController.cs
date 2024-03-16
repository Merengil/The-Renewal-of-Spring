using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreesLeftController : MonoBehaviour, IBloomingTreeObserver
{
    public int NumberOfTreesToCut = 25;
    public GameObject AoE;

    private int treesLeft;
    private TextMeshProUGUI textmesh;

    //**********************************************************

    // Start is called before the first frame update
    void Start()
    {
        AoE.GetComponent<SakuraAoEController>().Attach(this);
        treesLeft = NumberOfTreesToCut;
        textmesh = this.GetComponent<TextMeshProUGUI>();
        if (textmesh == null)
            throw new System.Exception("No TextMeshPro assigned to that text. Should never happen");
    }

    //**********************************************************

    public void BloomingTreeUpdate()
    {
        if (treesLeft > 0)
        {
            treesLeft--;
            textmesh.text = treesLeft.ToString();
            if (treesLeft == 0)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
