using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownTiles : MonoBehaviour {
	public GameObject target1;
	public GameObject target2;

	public bool Up;
	public bool Down;

	// Use this for initialization
	void Start () {
		Up = true;	
	}

	// Update is called once per frame
	void Update () {
		if (Up == true) {
			transform.Translate (0, 0.01f, 0);
		} else if (Down == true) {
			transform.Translate (0, -0.01f, 0);
		}

	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Target1") {
			Down = true;
			Up = false;
		}

	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Target2") {
			Down = false;
			Up = true;
		}
	}
}
