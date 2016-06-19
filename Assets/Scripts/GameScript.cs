using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class GameScript : MonoBehaviour {

	private Dictionary<int, GameObject> trails = new Dictionary<int, GameObject>();

	bool mouseDown;

	int touchCount;

	public GameObject petalPrefab;

	GameObject[] petals;


	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0)) {
			mouseDown = true;
		} else if (Input.GetMouseButtonUp(0)) {
			mouseDown = false;
		}

		if (mouseDown) {
			touchCount++;
		}

		for (int i = 0; i < touchCount; i++) {
			// -- Drag
			// ---------------------------------
			if (Input.GetMouseButtonDown(0)) {
				// Store this new value
				if (trails.ContainsKey (i) == false) {
					Vector3 position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
					position.z = 0; // Make sure the trail is visible

					GameObject trail = TrailScript.MakeTrail (position);

					if (trail != null) {
						Debug.Log (trail);
						trails.Add (i ,trail);

					}
				}
			} else if (Input.GetMouseButton(0)) {
				// Move the trail
				if (trails.ContainsKey (i)) {
					GameObject trail = trails [i];

					Camera.main.ScreenToWorldPoint (Input.mousePosition);
					Vector3 position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
					position.z = 0; // Make sure the trail is visible

					trail.transform.position = position;
				}
			} else if (Input.GetMouseButtonUp(0)) {
				// Clear known trails
				if (trails.ContainsKey(i)) {
					GameObject trail = trails [i];

					// Let the trail fade out
					Destroy(trail, trail.GetComponent<TrailRenderer>().time);
					trails.Remove (i);
				}
			}
		}

		GameObject[] inScreenPetals = GameObject.FindGameObjectsWithTag ("Petal");
		for (int i = 0; i < inScreenPetals.Length; i++) {
			if (inScreenPetals [i].transform.position.y < -2) {
				Destroy (inScreenPetals [i]);
			}
		}
	
	}

	public void PetalGenerate (Vector3 position) {

		int petalsNumber = Random.Range (2, 5);
		petals = new GameObject[petalsNumber];
		//GameObject petal;

		//other.gameObject.SetActive (false);
		//Invoke ("DestroyPetal", 4);

		for (int i = 0; i < petalsNumber; i++) {
			petals[i] = Instantiate (petalPrefab, position, 
				Quaternion.Euler(new Vector3(0, 0, Random.Range(-90, 90)))) as GameObject;
			petals[i].gameObject.transform.DOMove (new Vector2 (Random.Range(-3, 3), -3), 8);

			/*petal = Instantiate (petalPrefab, position, 
				Quaternion.Euler(new Vector3(0, 0, Random.Range(-90, 90)))) as GameObject;
			petal.gameObject.transform.DOMove (new Vector2 (Random.Range(-3, 3), -3), 8);

			if (petal.gameObject.transform.position.y < -2) {
				Destroy (petal.gameObject);
			}*/
		}



		//yield return new WaitForSeconds (2);
		Debug.Log ("Destroy petals");



		
	}

	public void DestroyPetal () {
		if (petals != null)
		for (int i = 0; i < petals.Length; i++) {
			if (petals [i] != null) {
				Destroy (petals [i].gameObject);
			}
		}
	}

}
