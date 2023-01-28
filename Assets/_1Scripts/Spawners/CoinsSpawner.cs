using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] _coinsPrefab;
    public List<GameObject> CoinsList;
    public float spawnX = 0f;
    [SerializeField] int spawnY1;
   
    public float CoinsSpawnDistance = 50f;
    public int amountofCoinsParent = 2;
    private Transform playertransform;
    [SerializeField] bool isgeneratedRnumber = true;


    private void Start()
    {
        StartCoroutine(UpdateRandomValues());

        CoinsList = new List<GameObject>();
        playertransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if (playertransform.position.x > (spawnX - amountofCoinsParent * CoinsSpawnDistance) && isgeneratedRnumber == true)
        {
            int randomIndex = Random.Range(0, _coinsPrefab.Length);
            SpawnCoins(randomIndex);
            isgeneratedRnumber = false;
        }
        RemoveTiles();
    }
    void SpawnCoins(int prefabIndex)
    {
        GameObject go;
        go = Instantiate(_coinsPrefab[prefabIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = new Vector3(spawnX + 50f, spawnY1, 0);
        spawnX += CoinsSpawnDistance;
        CoinsList.Add(go);
    }
    void RemoveTiles()
    {
        for (int i = CoinsList.Count - 1; i >= 0; i--)
        {
            if (CoinsList[i] == null)
            {
                CoinsList.RemoveAt(i);
            }
        }
    }
    IEnumerator UpdateRandomValues()
    {
        while (isgeneratedRnumber)
        {
            spawnY1 = Random.Range(5, 10);
            yield return new WaitForSeconds(2);
            isgeneratedRnumber = true;
        }
    }
}