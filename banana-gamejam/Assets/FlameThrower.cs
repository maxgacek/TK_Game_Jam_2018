using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlameThrower : MonoBehaviour {

	public GameObject prefab;
	public string pressCode = "Fire3";
	public ResourceController resource;
	public float cost;
	public Timer cd;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown(pressCode) && cd.isReady() && resource.Spend( cost) )
		{
			cd.restart();
			Instantiate(prefab, transform.position, transform.rotation);
		}
	}
}
