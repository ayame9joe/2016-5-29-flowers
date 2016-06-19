using UnityEngine;
using System.Collections;

public class FlowerScript : MonoBehaviour {

	//public GameObject script;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Wind") {
			this.gameObject.SetActive (false);

			Invoke ("FlowerBlossomAgain", 5);
		}
	}

	void FlowerBlossomAgain () {
		
		this.gameObject.SetActive (true);

	}
}
