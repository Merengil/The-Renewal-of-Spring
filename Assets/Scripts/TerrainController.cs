using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TerrainController : MonoBehaviour
{
    public GameObject petal;
    public GameObject player;
    public GameObject tree;
    public GameObject flower;
    public Terrain terrain;
    public int InitialNumberOfPetals = 5000;
    public int InitialNumberOfTrees = 100;
    public int InitialNumberOfFlowers = 1000;

    private Vector3 tempvect = new();
    private GameObject newObj;

    //**********************************************************

    // Start is called before the first frame update
    void Start()
    {
        terrain = GetComponent<Terrain>();
        GenerateRandomObjects(petal, InitialNumberOfPetals, true);
        GenerateRandomObjects(tree, InitialNumberOfTrees, false);
        GenerateRandomObjects(flower, InitialNumberOfTrees, false);
    }

    //**********************************************************

    /// <summary>
    /// Populate a map with a gameObject
    /// </summary>
    /// <param name="gameObj">Reference to the gameobject to populate the map with</param>
    /// <param name="numberObjects">Number of objects to populate the map with</param>
    private void GenerateRandomObjects(GameObject gameObj, int numberObjects, bool isPetal)
    {
        Vector3 terrainSize = terrain.terrainData.size;
        for (int i = 0; i < numberObjects; i++) {
            // Random coordinates on Terrain
            tempvect.x = (float)Math.Truncate(UnityEngine.Random.Range(0, terrainSize.x));
            tempvect.y = 0;
            tempvect.z = (float)Math.Truncate(UnityEngine.Random.Range(0, terrainSize.z));

            // Convert to world space
            tempvect = terrain.transform.TransformPoint(tempvect);

            // Getting height
            tempvect.y = terrain.SampleHeight(tempvect);
            if (isPetal)
                tempvect.y += 1;

            // Instanciating the petal
            newObj = GameObject.Instantiate(gameObj,
                tempvect,
                Quaternion.identity);

            // Not enough time to do this in a clean way, that will have to be fixed
            // one day...
            if (isPetal)
                newObj.GetComponent<PetalController>().SetPlayer(player);
        }
    }
}
