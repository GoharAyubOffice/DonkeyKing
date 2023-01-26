using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] _coinsPrefab;
    public List<GameObject> CoinsList;
    public float spawnX = 0f;
    public float spawnY1 = 8f;
    public float spawnY2 = 10f;
    public float spawnY3 = 15f;
    public float CoinsSpawnDistance = 50f;
    public int amountofCoinsParent = 2;
    private Transform playertransform;

    private void Start()
    {
        CoinsList = new List<GameObject>();
        playertransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if (playertransform.position.x > (spawnX - amountofCoinsParent * CoinsSpawnDistance))
        {
            SpawnCoins1(0);
            SpawnCoins2(1);
            SpawnCoins3(2);
        }
    }
    void SpawnCoins1(int prefabIndex)
    {
        GameObject go;
        go = Instantiate(_coinsPrefab[prefabIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = new Vector3(spawnX + 50f, spawnY1, 0);
        spawnX += CoinsSpawnDistance;
        CoinsList.Add(go);
    }
    void SpawnCoins2(int prefabIndex)
    {
        GameObject go;
        go = Instantiate(_coinsPrefab[prefabIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = new Vector3(spawnX + 50f, spawnY2, 0);
        spawnX += CoinsSpawnDistance;
        CoinsList.Add(go);
    }
    void SpawnCoins3(int prefabIndex)
    {
        GameObject go;
        go = Instantiate(_coinsPrefab[prefabIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = new Vector3(spawnX + 50f, spawnY3, 0);
        spawnX += CoinsSpawnDistance;
        CoinsList.Add(go);
    }
}
