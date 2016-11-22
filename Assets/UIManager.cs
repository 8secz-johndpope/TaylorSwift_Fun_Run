using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	// Use this for initialization
	private bool isPause = true;
	void Start () {
		Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void pauze()
	{   
		isPause = !isPause;
		if (isPause) 
			Time.timeScale = 0;
		else
			Time.timeScale = 1;

	}
}
