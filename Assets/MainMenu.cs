using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	public Text highscore;
	public Image logo;
	public Button play;
	public GameObject popUp;
	void Start () {
		highscore.text = "Highscore " + PlayerPrefs.GetFloat ("Highscore").ToString ("00");
		logo.rectTransform.DOScaleX (0.85f, 1.0f).SetLoops (-1, LoopType.Yoyo).SetEase (Ease.InOutSine);
		play.transform.DOScale(new Vector3(0.85f,0.85f,0.85f),1.0f).SetLoops (-1, LoopType.Yoyo).SetEase (Ease.InOutSine);
	}

	public void ToGame()
	{
		SceneManager.LoadScene ("main");

	}
	public void ClearPlayerPrefs()
	{
		PlayerPrefs.DeleteAll ();
	}
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Debug.Log ("Escape is pressed");
			popUp.SetActive (true);

		}
	}
	public void NoButton()
	{
		popUp.SetActive (false);
	}
	public void YesButton()
	{
		Application.Quit();
	}
//	private void OnDialogClose(MNDialogResult result) {
//		//parsing result
//		switch(result) {
//		case MNDialogResult.YES:
//			Debug.Log ("Yes button pressed");
//			Application.Quit();
//			break;
//		case MNDialogResult.NO:
//			Debug.Log ("No button pressed");
//			break;
//		}
//	}
}

