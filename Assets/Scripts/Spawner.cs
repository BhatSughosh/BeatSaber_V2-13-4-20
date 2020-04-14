using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] cube;
    public Transform[] spawnPos;
    public float spawnTime;
    public float maxTime;
    public float minTime;
    public int start;
    int spawn;
    int pos;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ReSpawn());
    }

    // Update is called once per frame
    private void Update()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }
    IEnumerator ReSpawn()
    {
        yield return new WaitForSeconds(start);
        while (true)
        {
            spawn = Random.Range(0, 2);
            pos = Random.Range(0, 3);
            //Vector3 position = new Vector3(Random.Range(-2,2), Random.Range(1,5), 17);
            GameObject Cube = Instantiate(cube[spawn], spawnPos[pos]);
            Cube.transform.localPosition = Vector3.zero;
            Cube.transform.Rotate(transform.forward, 90 * (Random.Range(0, 4)));
                

            yield return new WaitForSeconds(spawnTime);
        }
    }
}
