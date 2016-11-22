using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class DeathMenu : MonoBehaviour {

	public Text scoreText;
	public GameObject ScoreObj;
	public Text bestScoreText;
	public Image backgroundImage;
	public Button play;
	private bool isShowned = false;
	private float transition = 0.0f;
	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
		play.transform.DOScale(new Vector3(1.2f,1.2f,1.2f),1.0f).SetLoops (-1, LoopType.Yoyo).SetEase (Ease.InOutSine);
	}
	
	// Update is called once per frame
	void Update () {
		if (!isShowned)
			return;
		transition += Time.deltaTime * 2;
		backgroundImage.color = Color.Lerp (new Color (1, 1, 1, 0), new Color (1, 1, 1, 1), transition);
	}
	public void ToggleEndMenu(float score)
	{
	gameObject.SetActive (true);
		ScoreObj.SetActive (false);
		scoreText.text = score.ToString ("00");
		bestScoreText.text = PlayerPrefs.GetFloat ("Highscore").ToString ("00");
		isShowned = true;
	}

	public void Restart()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);

	}
	public void ToMenu()
	{
		SceneManager.LoadScene ("Menu");

	}
}
