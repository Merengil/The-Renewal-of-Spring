using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Manage collision between the AoE and trees, to trigger blooming.
/// </summary>
public class SakuraAoEController : MonoBehaviour, IBloomingTreeSubject
{
    public GameObject player;
    public GameObject tree;
    public GameObject bloomingTree; // Reference to the new FBX prefab with LODs


    private PlayerController pc;
    private string treeName;
    private List<IBloomingTreeObserver> observers = new();

    //**********************************************************

    // Start is called before the first frame update
    void Start()
    {
        pc = player.GetComponent<PlayerController>();
        treeName = tree.name;
    }

    //**********************************************************

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && pc.HasSakuraPowerLeft)
        {
            Collider[] colliders = Physics.OverlapSphere(this.transform.position, 5);
            foreach (Collider collider in colliders)
                if (collider.gameObject.name.StartsWith(treeName))
                    BloomTree(collider);
        }
    }

    //**********************************************************

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(treeName + " " + other.gameObject.name);
        if (pc.IsSakuraTime && other.gameObject.name.StartsWith(treeName))
            BloomTree(other);
    }

    //**********************************************************

    private void BloomTree(Collider otherTree)
    {

        // Instantiate the new FBX prefab
        GameObject newFBXInstance = Instantiate(bloomingTree,
            otherTree.transform.position,
            otherTree.transform.rotation);

        // Get the LODGroup component of the original GameObject
        LODGroup originalLODGroup = otherTree.GetComponent<LODGroup>();

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

                    // Removes the original object
                    GameObject.Destroy(otherTree.gameObject);

                    NotifyBloomingTree();
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

    //**********************************************************

    public void Attach(IBloomingTreeObserver observer)
    {
        observers.Add(observer);
    }

    //**********************************************************

    public void Detach(IBloomingTreeObserver observer)
    {
        observers.Remove(observer);
    }

    //**********************************************************

    public void NotifyBloomingTree()
    {
        foreach (IBloomingTreeObserver observer in observers)
            observer.BloomingTreeUpdate();
    }
}
