using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    [Range(0, 120)]
    private float initialSpawnDelay = 5.0f;

    [SerializeField]
    private bool canSpawn = false;

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

    [SerializeField]
    private bool randomSpawnDirection = false;

    [SerializeField]
    private Vector2 randomSpawnDirectionLimitsX = new Vector2(-180f, 180f);
    
    [SerializeField]
    private Vector2 randomSpawnDirectionLimitsY = new Vector2(-180f, 0f);



    [SerializeField]
    private Quaternion spawnDirection;


    [SerializeField]
    private bool movable = false;

    [SerializeField]
    private Vector3[] points;

    private Vector3 currentTransform;
    private int transformIndex = 0;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForSpawn());

        if (movable && points.Length > 0)
        {
            currentTransform = points[0];
        }
    }

    // Update is called once per frame
    void SwitchPosition()
    {
        if (movable && points.Length > 0)
        {
            transformIndex++;
            if (transformIndex >= points.Length)
            {
                transformIndex = 0;
            }

            currentTransform = points[transformIndex];

            transform.position = transform.position + currentTransform;
        }
    }

    IEnumerator WaitForSpawn()
    {

        if (canSpawn)
        {
            //yield on a new YieldInstruction that waits for 5 seconds.
            yield return new WaitForSeconds(Random.Range(spawnTimeRangeMin, spawnTimeRangeMax));
        } else
        {
            yield return new WaitForSeconds(initialSpawnDelay);
        }

        if (randomSpawnDirection)
        {
            spawnDirection = new Quaternion(Random.Range(randomSpawnDirectionLimitsX.x, randomSpawnDirectionLimitsX.y), Random.Range(randomSpawnDirectionLimitsY.x, randomSpawnDirectionLimitsY.y), 0f, 0f);
        }

        Instantiate(spawnObject, transform.position, spawnDirection);

        SwitchPosition();

        StartCoroutine(WaitForSpawn());
    }
}
