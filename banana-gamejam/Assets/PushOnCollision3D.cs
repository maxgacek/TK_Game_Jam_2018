using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class PushOnCollision3D : MonoBehaviour {

	public float force;
	public Timer activeTime;
	public float radius;

	public float shakeMagnitusde = 0.0f;
	public float shakeRoughness = 2.0f;
	public float shakeFadeIn = 0.1f;
	public float shakeFadeOut = 0.8f;
	public bool explosion = true;

    public bool warm = false;

	public void activate()
	{
		gameObject.SetActive(true);
		activeTime.restart();

		CameraShaker.Instance.ShakeOnce(shakeMagnitusde, shakeRoughness, shakeFadeIn, shakeFadeOut);

	}

	// Use this for initialization
	void Start () {

        if (warm)
            activate();
	}
	
	// Update is called once per frame
	void Update () {
		if(activeTime.isReady())
		{
			gameObject.SetActive(false);
		}
	}
	private void OnTriggerEnter(Collider other)
	{
		var rigidbody = other.gameObject.GetComponent<Rigidbody>();
		if(rigidbody)
		{
			if (!explosion)
			{
				Vector3 toOther = (rigidbody.position - transform.position);
				rigidbody.AddForce(toOther.normalized * force * Time.fixedDeltaTime);
			}
			else
				rigidbody.AddExplosionForce(force * Time.fixedDeltaTime, transform.position, radius);
		}
	}
}
