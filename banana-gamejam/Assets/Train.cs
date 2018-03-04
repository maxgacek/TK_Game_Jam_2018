using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour {

    public bool active = true;

    Vector3 pos = new Vector3 (0,0,0);
    public float effectSpeed = 0.5f;

	void Update () {

        if (active)
        {
            gameObject.transform.SetPositionAndRotation(pos, Quaternion.identity);
            pos.x += effectSpeed;
        }

    }
}
