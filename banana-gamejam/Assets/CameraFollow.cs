using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject player;
    Vector3 pos;
    public Vector3 margin;

    public Transform player1;
    public Transform player2;

    public float[] camZoomPos;

    public Vector3 center;

    public Transform[] transformArray;  

    private Vector3 camZoomed;

    public float cameraSpeed = 0.1f;

	void FixedUpdate () {
        //center = ((player2.position - player1.position) / 2.0f) + player1.position;

        center = (transformArray[0].position + transformArray[1].position + transformArray[2].position) / transformArray.Length;

        pos.x = Mathf.Lerp(transform.position.x, center.x + margin.x, cameraSpeed);
        pos.y = Mathf.Lerp(transform.position.y, center.y + margin.y, cameraSpeed);
        pos.z = Mathf.Lerp(transform.position.z, center.z + margin.z, cameraSpeed);
        
        //margin.z = Mathf.Lerp(margin.z, camZoomed.z, 0.1f);

        transform.position = pos;

        transform.LookAt(center);
    }

}
