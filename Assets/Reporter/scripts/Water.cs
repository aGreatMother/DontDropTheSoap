using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour {

//	bool visible;
	AudioSource waterSple;
	// Use this for initialization
	void Start () {
		waterSple = this.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		formerScore = GameManager.score;

		MoveLogic ();
		MoveUp ();
	}

	void MoveLogic()
	{
	if ((IsStruggleTooMuch() || IsFallingDown())) {
			if(this.transform.position.y<Camera.main.transform.position.y-220f)
			this.transform.position=Camera.main.transform.position.y*Vector3.up-220f*Vector3.up;
			moving=true;
		
		}
  
	}



	bool moving = false;
	//private float speed = 1f;
	void MoveUp(){
	float	speed = GameManager.score / 10f+1f;
		if (moving&&!GameManager.gameOver&&GameManager.start)
			this.transform.Translate (Time.deltaTime * speed * Vector3.up);
	}

	float struggleTimeRefer;
	float StruTimeCounter;
	Vector3 formerPos=Vector3.zero;
	int formerScore;
	bool IsStruggleTooMuch()
	{
		if (formerScore != GameManager.score) {
			struggleTimeRefer = 3f - (GameManager.score / 30f);
			if (struggleTimeRefer < 0.3f)
				struggleTimeRefer = 0.3f;
			formerScore=GameManager.score;
		}

		if (Mathf.Abs (formerPos.y - GameManager.soap.transform.position.y) > 10.7f) {
			formerPos = GameManager.soap.transform.position;
			StruTimeCounter=0f;
		}
		else
			StruTimeCounter += Time.deltaTime;

		if (StruTimeCounter >= struggleTimeRefer) {
			StruTimeCounter = 0f;
			formerPos = GameManager.soap.transform.position;

			return true;

		
		} else
			return false;


	}

	float fallTimeRefer;
	float fallTimeCounter;
	bool IsFallingDown()
	{
		if (formerScore != GameManager.score) {
			fallTimeRefer = 2f - (GameManager.score / 50f);
			if (struggleTimeRefer < 0.15f)
				struggleTimeRefer = 0.15f;
			formerScore=GameManager.score;
		}
	   if (GameManager.soap.GetComponent<Rigidbody2D> ().velocity.y > 0f) {
			fallTimeCounter = 0f;
		} else
			fallTimeCounter += Time.deltaTime;

		if (fallTimeCounter > fallTimeRefer) {
			fallTimeCounter = 0f;
			return true;
		} else
			return false;
	
	
	
	
	}
	bool hasAdateForMoveUpon=false;
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name == "start") {
			Destroy (other.gameObject, 0.1f);

		}

		if (!hasAdateForMoveUpon&& other.gameObject.name == "soap") {
			waterSple.Play();
			GameManager.gameOver=true;
			CameraFollowing.targetYGameOver=other.transform.position.y+50f;
			hasAdateForMoveUpon=true;
		}

	}

//	void OnBecameVisible()
//	{
//		
//		
//		visible = true;
//	}
//	void OnBecameInvisible ()
//	{
//		
//		visible = false;
//		
//	}

}
