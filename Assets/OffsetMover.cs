using UnityEngine;
using System.Collections;

public class OffsetMover : MonoBehaviour {
	private MeshRenderer mr;
	private Material mt;
	private Vector2 offset;
	public float speed = 0;
	// Use this for initialization
	void Start () {
		mr = GetComponent<MeshRenderer> ();
		mt = mr.material;
		offset = mt.mainTextureOffset;
	}
	
	// Update is called once per frame
	void Update () {
		
	
	
		offset.x += Time.deltaTime * speed;
		mt.mainTextureOffset = offset;
		if (offset.x >= 1)
			offset.x = 0;
	}
}
