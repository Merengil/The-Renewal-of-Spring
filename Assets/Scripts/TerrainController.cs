using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TerrainController : MonoBehaviour
{
    public GameObject petal;
    public GameObject player;
    public Terrain terrain;
    public int InitialNumberOfPetals = 5000;
    
    private Vector3 tempvect = new();
    private GameObject newPetal;

    //**********************************************************

    // Start is called before the first frame update
    void Start()
    {
        terrain = GetComponent<Terrain>();
        GenerateRandomPetalsObjects(InitialNumberOfPetals);
    }

    //**********************************************************

    private void GenerateRandomPetalsObjects(int numberPetals)
    {
        Vector3 terrainSize = terrain.terrainData.size;
        for (int i = 0; i < numberPetals; i++) {
            // Random coordinates on Terrain
            tempvect.x = (float)Math.Truncate(UnityEngine.Random.Range(0, terrainSize.x));
            tempvect.y = 0;
            tempvect.z = (float)Math.Truncate(UnityEngine.Random.Range(0, terrainSize.z));

            // Convert to world space
            tempvect = terrain.transform.TransformPoint(tempvect);

            // Getting height
            tempvect.y = terrain.SampleHeight(tempvect) + 0.5f;

            // Instanciating the petal
            newPetal = GameObject.Instantiate(petal,
                tempvect,
                Quaternion.identity);
            newPetal.GetComponent<PetalController>().SetPlayer(player);
        }
    }

    //**********************************************************

    // Update is called once per frame
    void Update()
    {
        
    }
}
