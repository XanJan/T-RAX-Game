using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstical : MonoBehaviour
{
    public List<GameObject> obsticals;
    public GameObject spawnPosition;
    private float addTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onSpeedChange += UpdateSpeed;
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
        GameObject i = Instantiate(obsticals[Random.Range(0, obsticals.Count)], spawnPosition.transform);
        i.GetComponent<ObsticalController>().setSpeed(addTime);
        StartCoroutine(RandomSpawnTime());
    }

    private void UpdateSpeed()
    {
        addTime += 1f; 
    }
}
