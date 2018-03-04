using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagonShake : MonoBehaviour{

	public float timeMin;
	public float timeMax;
	Timer timerChange = new Timer();
	public float rotationRange;


    public CameraFollow camera;

	float actualRotationAim;

	void randRotation()
	{
		timerChange.cd = Random.Range(timeMin, timeMax);
		actualRotationAim = Random.Range(-rotationRange, rotationRange);
	}

	// Use this for initialization
	void Start () {
		randRotation();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(timerChange.isReadyRestart())
		{
			randRotation();
		}

		float differenceRot = Mathf.DeltaAngle(transform.rotation.eulerAngles.x, actualRotationAim);

		transform.Rotate(differenceRot * Time.deltaTime / timerChange.cd, 0,0);
	}
}
