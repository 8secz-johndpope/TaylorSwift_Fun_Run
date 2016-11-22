using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class Score : MonoBehaviour {

	// Use this for initialization
	public float score = 0.0f;
	public int publicScore = 0;
	public int difficultyLevel = 1;
	private int maxDifficultyLevel = 20;
	private int scoreToNextLevel = 2;
	public Text scoreTest;
	private bool isDead = false;
	public DeathMenu deathMenu;
	void Update () {
		if (isDead)
			return;
		//if (score >= scoreToNextLevel)
			//LevelUp ();
	//	score += Time.deltaTime * difficultyLevel;
		scoreTest.text = publicScore.ToString ("00");
		if (publicScore >= 5) {
			GetComponent<PlayerMotor> ().speed = 15;
		}
		if (publicScore >= 10) {
			GetComponent<PlayerMotor> ().speed = 20;
		}
		if (publicScore >= 50) {
			GetComponent<PlayerMotor> ().speed = 25;
		}
		if (publicScore >= 100) {
			GetComponent<PlayerMotor> ().speed = 26;
		}
		
	}
	void LevelUp()
	{
		if (difficultyLevel == maxDifficultyLevel)
			return;
		scoreToNextLevel *= 2;
		difficultyLevel++;
		GetComponent<PlayerMotor>().SetSpeed (difficultyLevel);
	}
	public void OnDeath()
	{

		isDead = true;
		if(PlayerPrefs.GetFloat("Highscore") < publicScore)
			PlayerPrefs.SetFloat ("Highscore", publicScore);


		deathMenu.ToggleEndMenu (publicScore);
	}
	public void AnimScore()
	{
		scoreTest.rectTransform.DOPunchScale(new Vector3(0.13f,0.13f,1f),0.4f,5,1f);
	}
}
