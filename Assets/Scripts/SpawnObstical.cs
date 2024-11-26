using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstical : MonoBehaviour
{
    public List<GameObject> obsticals;
    public GameObject spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RandomSpawnTime()
    {
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        Spawn();
    }

    private void Spawn()
    {
        Instantiate(obsticals[Random.Range(0, obsticals.Count)], spawnPosition.transform);
        StartCoroutine(RandomSpawnTime());
    }
}
