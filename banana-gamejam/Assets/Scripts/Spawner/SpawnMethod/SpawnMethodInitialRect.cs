using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMethodInitialRect : MonoBehaviour
{
    //public GameObject obj;

    public GameObject[] objects;

    public Vector3 size;
    public int n;


    private void Update()
    {
        Vector3 v = size / n;
        for (int i = 0; i < n; ++i)
            for (int j = 0; j < n; ++j)
                Instantiate(objects[Random.Range(0, objects.Length)],
                 transform.position + new Vector3(v.x * i, 0, v.z * j) - size * 0.5f,
            Quaternion.identity);


        Destroy(this);
    }
}
