using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class PlayerMotor : MonoBehaviour {

	// Use this for initialization
	private CharacterController controller;
	private Vector3 moveVetor;
	private float verticalVelocity = 0.0f;
	public float speed;
	public float speedMove;
	private float gravity = 12.0f;
	public bool isDead = false;
	private float animationDuration = 1.0f;
	private float startTime;
	public UnityEvent _event = new UnityEvent();
	AudioSource audiov;
	void Start () {
		controller = GetComponent<CharacterController> ();
		startTime = Time.time;
		audiov = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Debug.Log ("Escape is pressed");
			if (isDead == false) {
				Death ();
			}
			else if (isDead) {
				_event.Invoke ();
			}

		}
		if (isDead)
			return;
		if (Time.time - startTime < animationDuration) {
			controller.Move (Vector3.forward * speed * Time.deltaTime);
			return;
		}
		moveVetor = Vector3.zero;

		if (controller.isGrounded) 
		{
			verticalVelocity = -0.5f;
		} 
		else {
			verticalVelocity -= gravity * Time.deltaTime;
			}

		moveVetor.x = Input.GetAxis ("Horizontal") * speedMove;
		if (Input.GetMouseButton (0)) 
		{
			if (Input.mousePosition.x > Screen.width / 2)
				moveVetor.x = speedMove;
			else
				moveVetor.x = -speedMove;
		}
		moveVetor.y = verticalVelocity;

		moveVetor.z = speed;
		controller.Move (moveVetor * Time.deltaTime);
	}
	public void SetSpeed(int modifier)
	{

		speed = 10.0f + modifier;

	}
	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (hit.point.z > transform.position.z + controller.radius && hit.gameObject.tag == "enemy") {
			Death ();
		}
	}
	private void Death()
	{
		isDead = true;
		GetComponent<Score> ().OnDeath ();
		GameObject.Find ("DontDestroy").GetComponent<AdMobManager> ().GameOver ();
		audiov.Play ();
	}
}
