using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_enemies : MonoBehaviour
{

    public List<GameObject> spawnPoints;
    public GameObject enemy;
    private bool newEnemyTime = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (newEnemyTime) {
            StartCoroutine(WaitBetweenEnemies());
            newEnemyTime = false;
        }
    }

    IEnumerator WaitBetweenEnemies()
    {
        int objectListInt = Random.Range(0, spawnPoints.Count);
        Instantiate(enemy, spawnPoints[objectListInt].transform.position, Quaternion.identity);
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);
        newEnemyTime = true;

    }
}
