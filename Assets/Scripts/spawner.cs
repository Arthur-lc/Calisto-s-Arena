using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject whatToSpawn;
    public int howMany;
    public float interval;
    private float timePassed = 0;
    private GameObject clone;
    private int cloneCount = 0;

    private void Update() {
        timePassed += Time.deltaTime;

        if (timePassed >= interval)
        {
            cloneCount = 0;
            timePassed = 0;
        }
       
        if (cloneCount <= howMany)
        {
            clone = Instantiate(whatToSpawn, transform.position, transform.rotation, transform.parent);
            cloneCount++;
        }
    }
}
