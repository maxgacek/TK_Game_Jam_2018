using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour {

    public float speed = 0.5f;

    public Material mat;

    void Update () {
        Vector2 offset = new Vector2(0* speed, 0);

        mat.mainTextureOffset = offset;
	}
}
