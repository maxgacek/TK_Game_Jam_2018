using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEventRigidbody : MonoBehaviour {

	public float mass = 1.0f;
	public float damping = 0.05f;


	void OnDeath(HealthController.DamageData data)
	{
		var r = gameObject.AddComponent<Rigidbody>();
		if (r)
		{
			r.mass = mass;
			r.drag = damping;
		}

		var animator  = GetComponent<Animator>();
		if (animator)
			Destroy(animator);

		Destroy(gameObject.GetComponent<HealthController>());
		Destroy(this);
	}
}
