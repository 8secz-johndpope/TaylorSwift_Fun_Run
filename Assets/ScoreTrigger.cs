using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.Events;

public class ScoreTrigger : MonoBehaviour {

	// Use this for initialization
	public Score _score;
	public UnityEvent _eventOne = new UnityEvent();
	public UnityEvent _eventTwo = new UnityEvent();
	public UnityEvent _eventAudio = new UnityEvent();


	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "enemy") {
			_score.publicScore++;
			_score.AnimScore ();
			_eventAudio.Invoke ();
		
		}
		if (other.gameObject.tag == "right") {
			_eventOne.Invoke ();
	

		}
		if (other.gameObject.tag == "left") {
			_eventTwo.Invoke ();
		

		}
	}
}
