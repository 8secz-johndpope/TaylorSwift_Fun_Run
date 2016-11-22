using UnityEngine;
using System.Collections;

public class BGLooper : MonoBehaviour {

	int numBGPanels = 5;

	void Start() {

	}

	void OnTriggerEnter(Collider collider) {
		Debug.Log ("Triggered: " + collider.name);

		float widthOfBGObject = collider.transform.localScale.x;
		Debug.Log (widthOfBGObject + "  " + collider.name);

		Vector3 pos = collider.transform.position;

		pos.x += widthOfBGObject * numBGPanels;


		collider.transform.position = pos;

	}
}
