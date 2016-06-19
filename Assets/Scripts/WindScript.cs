using UnityEngine;
using System.Collections;


public class WindScript : MonoBehaviour {

	public GameObject script;

	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {


	
	}

	void OnTriggerEnter2D (Collider2D other) {
		//Debug.Log ("Touch the Flower");
		if (other.gameObject.tag == "Flower") {

			//GameScript.PetalGenerate (other.transform.position);
			script.GetComponent<GameScript> ().PetalGenerate (other.transform.position);

		}
	}
		
}
