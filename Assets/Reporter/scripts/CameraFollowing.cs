using UnityEngine;
using System.Collections;



public class CameraFollowing : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public GameObject hero;
	// Update is called once per frame
	void Update () {
		if (this.transform.position.y < 0f && Application.loadedLevel == 0) {
			this.transform.position = new Vector3 (this.transform.position.x, 0f, this.transform.position.z);
			//StopAllCoroutines ();
		}
		FollowSoapHorizon ();
			FollowSoapVertical ();
			OnceGameOver ();
		
	}
	public float yOff;


	void FollowSoapVertical()
	{
		if (GameManager.gameOver) {
			StopCoroutine(AcclerateDownToGetSoap());
			StopCoroutine(AcclerateUpToGetSoap());	
		}

		if (!speedUpDown && hero.transform.position.y > this.transform.position.y + 2 * yOff && hero.GetComponent<Rigidbody2D> ().velocity.y > 0) {

			StopCoroutine(AcclerateDownToGetSoap());
			StartCoroutine (AcclerateUpToGetSoap ());
		}
       
		if (!speedUpUp&& hero.transform.position.y < this.transform.position.y-3*yOff  && hero.GetComponent<Rigidbody2D> ().velocity.y <0f) {

			StopCoroutine(AcclerateUpToGetSoap());	
			StartCoroutine(AcclerateDownToGetSoap());

			//this.transform.Translate(hero.GetComponent<Rigidbody2D> ().velocity*5*Time.deltaTime);		
		}

	}
	public float  speedAddUp;
	public float accelerateDown;

	bool speedUpUp=false;
	IEnumerator AcclerateUpToGetSoap()
	{   int acclerateCount=0;
		speedUpUp = true;
		while (!GameManager.gameOver&&hero.transform.position.y >= this.transform.position.y-2f*yOff
		       &&hero.GetComponent<Rigidbody2D> ().velocity.y>0f) {
			

			this.transform.Translate (hero.GetComponent<Rigidbody2D>().velocity.y*Vector2.up*Time.deltaTime+
			                          speedAddUp * Vector2.up* Time.deltaTime);
			acclerateCount++;	
			yield return 0;
			
			
		}
		acclerateCount = 0;
		speedUpUp = false;
		StopCoroutine (AcclerateUpToGetSoap());
		
		
	}







	bool speedUpDown=false;
   IEnumerator AcclerateDownToGetSoap()
	{int acclerateCount=0;
		speedUpDown = true;
		while (!GameManager.gameOver&&hero.transform.position.y <= this.transform.position.y+2f*yOff
		       &&hero.GetComponent<Rigidbody2D> ().velocity.y<0f) {
				

			this.transform.Translate (hero.GetComponent<Rigidbody2D>().velocity.y*Vector2.up*Time.deltaTime+
				                  acclerateCount* accelerateDown * Vector2.down* Time.deltaTime);
			acclerateCount++;	
			yield return 0;
		
		
		}
		acclerateCount = 0;
		speedUpDown = false;
		StopCoroutine (AcclerateDownToGetSoap());


	}

	enum CameraVerticalState
	{
		left,
		right,
		middle
		
	}

	public float xFollowRefer=35f; 
	public float xEdgeRefer=45f;
	bool catchingHori=false;
	CameraVerticalState camVertiState=CameraVerticalState.left;
	void FollowSoapHorizon()
	{
	

		if (!GameManager.gameOver&&!catchingHori && hero.transform.position.x > xEdgeRefer&&camVertiState!=CameraVerticalState.right) {
			StartCoroutine(MoveToEdge(60f));
			camVertiState=CameraVerticalState.right;
		}
		if (!GameManager.gameOver&&!catchingHori && hero.transform.position.x < -xEdgeRefer&&camVertiState!=CameraVerticalState.left) {
			StartCoroutine(MoveToEdge(-60f));
			camVertiState=CameraVerticalState.left;
		}
		if (!GameManager.gameOver&&!catchingHori && Mathf.Abs (hero.transform.position.x) <= xFollowRefer ) {
			if( camVertiState != CameraVerticalState.middle)
			{StartCoroutine(ToCatchTheSoap());
				camVertiState=CameraVerticalState.middle;}
			else if(!GameManager.gameOver)
				this.transform.position= new Vector3(hero.transform.position.x,this.transform.position.y,this.transform.position.z);
		}

	}


	 
	IEnumerator ToCatchTheSoap()
	{

		catchingHori = true;
		float moveTime=1.5f;
		float timeCount=0f;
		while (!GameManager.gameOver&&Mathf.Abs(this.transform.position.x- hero.transform.position.x)>1f&&
		       Mathf.Abs (hero.transform.position.x) <= xEdgeRefer) {
			timeCount+=Time.deltaTime;
			Vector3 middlePos=Vector3.Lerp(this.transform.position,hero.transform.position,timeCount/moveTime);
			this.transform.position= new Vector3(middlePos.x,this.transform.position.y,this.transform.position.z);
			yield return 0;
		
		}
		if(Mathf.Abs(this.transform.position.x- hero.transform.position.x)<=1f)
		this.transform.position= new Vector3(hero.transform.position.x,this.transform.position.y,this.transform.position.z);
		catchingHori = false;
		StopCoroutine (ToCatchTheSoap());
	}

	IEnumerator MoveToEdge(float targetX)
	{
		float moveTime=1.5f;
		catchingHori = true;
		float timeCount = 0f;
		Vector3 targetPos = targetX * Vector3.right;
		while (!GameManager.gameOver&& Mathf.Abs(this.transform.position.x-targetX)>1f&&
		       Mathf.Abs (hero.transform.position.x) > xFollowRefer) {
			timeCount+=Time.deltaTime;
			Vector3 middlePos=Vector3.Lerp(this.transform.position,targetPos,timeCount/moveTime);
			this.transform.position= new Vector3(middlePos.x,this.transform.position.y,this.transform.position.z);
			yield return 0;
			
		}
		if(Mathf.Abs(this.transform.position.x-targetX)<=1f)
		this.transform.position= new Vector3(targetX,this.transform.position.y,this.transform.position.z);
		catchingHori = false;
		StopCoroutine (MoveToEdge(targetX));
	}

	public static float targetYGameOver;
	void OnceGameOver()
	{
	if (GameManager.gameOver) {
			StartCoroutine(MoveToY(targetYGameOver));
		
		}
	}


	 IEnumerator MoveToY(float targetY)
	{
		float moveTime=3f;

		float timeCount = 0f;
		Vector3 targetPos = targetY * Vector3.up;
		while (Mathf.Abs(this.transform.position.y-targetY)>1f) {
			timeCount+=Time.deltaTime;
			Vector3 middlePos=Vector3.Lerp(this.transform.position,targetPos,timeCount/moveTime);
			this.transform.position= new Vector3(this.transform.position.x,middlePos.y,this.transform.position.z);
			yield return 0;
			
		}
		if(Mathf.Abs(this.transform.position.y-targetY)<=1f)
			this.transform.position= new Vector3(this.transform.position.x,targetY,this.transform.position.z);

		StopCoroutine ( MoveToY(targetY));
	}

}
