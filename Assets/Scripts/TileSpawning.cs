using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TileSpawning : MonoBehaviour
{
    [SerializeField] GameObject[] _tilePrefabs;
    public List<GameObject> Tileslist;
    public float spawnX = 0f;
    public float tileLength = 50f;
    public int amountofTiles = 2;
    private Transform playertransform;

    private void Start()
    {
        Tileslist = new List<GameObject>();
        playertransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if (playertransform.position.x > (spawnX - amountofTiles * tileLength))
        {
            SpawnRoad(0);
            SpawnRoad(1);
        }
    }
    void SpawnRoad(int prefabIndex)
    {
        GameObject go;
        go = Instantiate(_tilePrefabs[prefabIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.right * (spawnX + 50f);
        spawnX += tileLength;
        //adding gameobject to list
        Tileslist.Add(go);
    }
}
