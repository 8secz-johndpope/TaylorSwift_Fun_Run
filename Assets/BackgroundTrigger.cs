using UnityEngine;
using System.Collections;
using DG.Tweening;

public class BackgroundTrigger : MonoBehaviour {
	public float[] nums;
	public GameObject _fon;
	private GameObject tilemanager;
	public bool _setSky;
	void Start()
	{
		tilemanager = GameObject.Find("TileManager");

	}
	void OnTriggerEnter(Collider other) {
		tilemanager.GetComponent<TileManager>().BackgroundChancher (nums[0], nums[1], nums[2],nums[3],nums[4]);
		tilemanager.GetComponent<TileManager> ().SetActiveSky (_setSky);
		_fon.GetComponent<SpriteRenderer> ().DOFade (0, 0.4f);

	}
}
