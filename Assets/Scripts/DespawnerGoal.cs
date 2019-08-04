using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnerGoal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
