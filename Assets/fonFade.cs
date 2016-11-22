using UnityEngine;
using System.Collections;
using DG.Tweening;

public class fonFade : MonoBehaviour {

	public GameObject _fon;

	void Start()
	{


	}
	void OnTriggerEnter(Collider other) {

		_fon.GetComponent<SpriteRenderer> ().DOFade (0, 0.4f);
	}
}
