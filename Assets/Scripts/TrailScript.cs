using UnityEngine;
using System.Collections;

/// <summary>
/// Helper class to handle trail effect.
/// </summary>
public class TrailScript : MonoBehaviour {

	private static TrailScript instance;

	// Prefabs

	public GameObject trailPrefab;


	void Awake ()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {

		if (trailPrefab == null)
			Debug.LogError ("Missing Trail Prefab!");
	
	}

	/// <summary>
	/// Create a new trail at the given position
	/// </summary>
	/// <cparam name = "position"></paramc>
	/// <creturns></returnsc>
	public static GameObject MakeTrail(Vector3 position)
	{
		if (instance == null) {
			Debug.LogError ("There is no SpecialEffectsScript in the scene!");
			return null;
		}

		GameObject trail = Instantiate (instance.trailPrefab) as GameObject;
		trail.transform.position = position;

		return trail;
	}


	// Update is called once per frame
	void Update () {
	
	}
}
