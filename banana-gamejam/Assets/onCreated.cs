using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class onCreated : MonoBehaviour {

    public Rigidbody rb;
    public GameObject explosion;
	public float speed;

	// Update is called once per frame
	void Update () {
        rb.AddForce(transform.forward * speed * Time.deltaTime);
	}


    void OnCollisionStay(Collision col)
    {
        Instantiate(explosion, transform.position, Quaternion.identity).GetComponent<PushOnCollision3D>().activate();
        Destroy(gameObject);
	}
}
