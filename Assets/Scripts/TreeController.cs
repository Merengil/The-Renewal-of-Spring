using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Unused
/*
public class TreeController : MonoBehaviour
{
    public GameObject newFBXPrefab; // Reference to the new FBX prefab with LODs

    /// <summary>
    /// Make the tree bloom.
    /// </summary>
    public void Bloom()
    {
        // Instantiate the new FBX prefab
        GameObject newFBXInstance = Instantiate(newFBXPrefab, transform.position, transform.rotation);

        // Get the LODGroup component of the original GameObject
        LODGroup originalLODGroup = GetComponent<LODGroup>();

        if (originalLODGroup != null && newFBXInstance != null)
        {
            // Get the LODs array from the LODGroup component
            LOD[] originalLODs = originalLODGroup.GetLODs();

            if (originalLODs.Length > 0)
            {
                // Get the mesh filter of the new FBX instance
                MeshFilter newMeshFilter = newFBXInstance.GetComponentInChildren<MeshFilter>();

                if (newMeshFilter != null)
                {
                    // Set the replacement mesh for the LODs
                    for (int i = 0; i < originalLODs.Length; i++)
                    {
                        // Accessing the mesh filter of the renderer
                        MeshFilter rendererMeshFilter = originalLODs[i].renderers[0].GetComponent<MeshFilter>();
                        if (rendererMeshFilter != null)
                        {
                            rendererMeshFilter.sharedMesh = newMeshFilter.sharedMesh;
                        }
                        else
                        {
                            Debug.LogError("MeshFilter not found in the renderer.");
                        }
                    }

                    // Update the LODs array in the LODGroup component
                    originalLODGroup.SetLODs(originalLODs);
                }
                else
                {
                    Debug.LogError("MeshFilter not found in the new FBX instance.");
                }
            }
            else
            {
                Debug.LogError("No LODs found in the original GameObject.");
            }
        }
        else
        {
            Debug.LogError("LODGroup component or new FBX instance not found.");
        }
    }

    internal void SetSakuraTree(GameObject sakuraTree)
    {
        throw new NotImplementedException();
    }
}
*/