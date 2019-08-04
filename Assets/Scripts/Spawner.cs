using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnedThing;
    public GameObject goal;
    
    int tick = 0;
    // Start is called before the first frame update
    void Start()
    {
        spawnedThing.GetComponent<Move>().moveTo = goal;
    }

    // Update is called once per frame
    void Update()
    {
        if(++tick % 400 == 0)
        {
            Instantiate(spawnedThing, transform.position, Quaternion.identity);
        }
    }
}
