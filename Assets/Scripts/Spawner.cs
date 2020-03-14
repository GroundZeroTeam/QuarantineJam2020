using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    [Range(0, 10)]
    private float spawnTimeRangeMax;

    [SerializeField]
    [Range(0, 10)]
    private float spawnTimeRangeMin;

    [SerializeField]
    private bool randomizeSpawnTime = false;

    [SerializeField]
    private GameObject spawnObject;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitForSpawn()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(Random.Range(spawnTimeRangeMin, spawnTimeRangeMax));

        Instantiate(spawnObject, transform.position, Quaternion.identity);

        StartCoroutine(WaitForSpawn());
    }
}
