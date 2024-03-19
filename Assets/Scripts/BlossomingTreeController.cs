using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BlossomingTreeController : MonoBehaviour
{
    private float ctdn = 1;
    private bool isCtdnFinished = false;
    private LODGroup lodGroup;

    //**********************************************************

    // Start is called before the first frame update
    void Start()
    {
        lodGroup = GetComponent<LODGroup>();
    }

    //**********************************************************

    // Update is called once per frame
    void Update()
    {
        if (!isCtdnFinished)
        {
            ctdn -= Time.deltaTime;
            SetAlpha(1-ctdn);
            if (ctdn <= 0)
            {
                ctdn = 0;
                isCtdnFinished = true;
                SetAlpha(1);
            }
        }
    }

    //**********************************************************

    /// <summary>
    /// Sets a specific alpha value to the material
    /// </summary>
    /// <param name="alphaValue"></param>
    private void SetAlpha(float alphaValue)
    {
        // Get all LODs
        LOD[] lods = lodGroup.GetLODs();

        // Loop through each LOD level
        for (int i = 0; i < lods.Length; i++)
        {
            // Get all renderers in the current LOD level
            Renderer[] renderers = lods[i].renderers;

            // Loop through each renderer and modify materials
            for (int j = 0; j < renderers.Length; j++)
            {
                // Get the materials of the current renderer
                Material[] materials = renderers[j].materials;

                // Loop through each material and modify the alpha value
                for (int k = 0; k < materials.Length; k++)
                {
                    // Check if the material has a transparency property
                    if (materials[k].HasProperty("_Mode"))
                    {
                        // Set the rendering mode to transparent
                        materials[k].SetFloat("_Mode", 2); // 2 represents the value for "Transparent" mode

                        // Set the alpha value directly
                        Color color = materials[k].color;
                        color.a = alphaValue;
                        materials[k].color = color;

                        // Apply the changes
                        materials[k].SetFloat("_Mode", 3); // 3 represents the value for "Transparent" mode with shadows
                        materials[k].EnableKeyword("_ALPHABLEND_ON");
                        materials[k].EnableKeyword("_ALPHAPREMULTIPLY_ON");
                        materials[k].renderQueue = 3000;
                    }
                    /*else
                    {
                        Debug.LogWarning("Material does not have a transparency property.");
                    }*/
                }
            }
        }
    }
}
