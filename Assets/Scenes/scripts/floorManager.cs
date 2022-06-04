using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorManager : MonoBehaviour
{
   [SerializeField] GameObject[] floorPrefabs;
    public void spawnFloor()
    {
        int r =Random.Range(0,10);
        if (r <= 7)
        { GameObject floor = Instantiate(floorPrefabs[0], transform);
            floor.transform.position = new Vector3(Random.Range(-2.1f, 3.5f), -6f, 0f);
        }
        else
        {
            GameObject floor = Instantiate(floorPrefabs[1], transform);
            floor.transform.position = new Vector3(Random.Range(-2.1f, 3.5f), -6f, 0f);
        }
         

    }
}
