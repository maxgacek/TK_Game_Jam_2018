using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour {

	public GameObject winTarget;
	public float WinDistance;
	public GameObject winObject;
	public GameObject generalObject;
	
	// Update is called once per frame
	void Update () {
		if( (transform.position - winTarget.transform.position).sqrMagnitude > WinDistance*WinDistance )
		{
			winObject.SetActive(!generalObject.activeInHierarchy);
			generalObject.SetActive(true);

			Destroy(this);
		}
	}

	public void restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
