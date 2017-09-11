using UnityEngine;
using System.Collections;

public class GetPowerFromMagnet : MonoBehaviour {

	Animator anim;
	AudioSource platicHit;
	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();
		rigid = this.GetComponent<Rigidbody2D> ();
		platicHit=this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameManager.start && !anim.GetBool ("chase")&& Random.Range (1, 48) == 1 )
			anim.SetBool ("chase",true);
		else 
			anim.SetBool ("chase",false);

		if(!GameManager.gameOver)
		anim.SetFloat("ySpeed",rigid.velocity.y);
		OnceDead ();
	}
	void OnCollisionStay2D(Collision2D colled)
	{
		if (colled.gameObject.name == "MagnetR"&&colled.transform.position.x<this.transform.position.x&&
		    !MakeMagnetOut.magRComeTooClose) {
					this.GetComponent<Rigidbody2D> ().AddForce (colled.transform.up *0.15f);
			}
		if (colled.gameObject.name == "MagnetB"&&colled.transform.position.x>this.transform.position.x&&
		    !MakeMagnetOut.magBComeTooClose) {
			this.GetComponent<Rigidbody2D> ().AddForce (colled.transform.up *0.15f);
		}
	}

	void OnCollisionEnter2D(Collision2D colled)
	{

		if (colled.gameObject.tag == "tube" &&this.GetComponent<Rigidbody2D>().velocity.sqrMagnitude>=1000f)
			platicHit.Play ();
	}

	void OnCollisionExit2D(Collision2D colled)
	{

	}
	
	Rigidbody2D rigid;


	//NEXT PART FOR SOAP'S DEATH!!!!!
	void OnceDead()
	{
		if(!alreadyDead&& GameManager.gameOver&&!anim.GetBool("dead")){

			anim.applyRootMotion=false;
			anim.SetBool("dead",true);
			rigid.gravityScale=0f;
			rigid.velocity=Vector3.zero;
			vertiRefer=this.transform.position.y+3f;
			StartCoroutine (FallInWater());
		}

	}
	bool alreadyDead=false;
	void StartFloat()
	{
		StopCoroutine (FallInWater ());
		StopCoroutine (CameOutWater ());

		alreadyDead = true;
		anim.SetBool ("dead", false);
		StartCoroutine (FloatRandom ());

//		anim.enabled = false;
		rigid.angularDrag = 1000000f;
		rigid.mass = 1f;

		StartCoroutine (FloatUpAndDown ());
	 }

	float horiMoveRate=0.5f;
	float horiMoveRateCounter;
	IEnumerator FloatRandom()
	{
		while (horiMoveRateCounter<=horiMoveRate) {
			horiMoveRateCounter+=Time.deltaTime;
			yield return 0;
		}
		horiMoveRateCounter = 0f;
		rigid.AddForce (70f * Vector3.right);
		StopCoroutine (FloatRandom ());
		StartCoroutine (FloatRandom ());
	}

	float vertiRefer ;
	float vertiMoveRate = 3f;
	float vertiMoveRateCounter;
	 float dir=1f;
	IEnumerator FloatUpAndDown()
	{
		float dValue = Random.Range (0.3f, 1f);
		vertiMoveRate = dValue*10f ;
		vertiMoveRateCounter = 0f;
		while (Mathf.Abs ( this.transform.position.y-(vertiRefer+dir*dValue))>=0.1f) {
			if(rotationTime<=roationCounter)
				this.transform.localEulerAngles=-90f*Vector3.forward;
			vertiMoveRateCounter+=Time.deltaTime; 
			Vector3 middlePos=Vector3.Lerp(this.transform.position.y*Vector3.up,(vertiRefer+dir*dValue)*Vector3.up
			                               ,(vertiMoveRateCounter/vertiMoveRate));
			this.transform.position=new Vector3(this.transform.position.x,middlePos.y,this.transform.position.z);
			yield return 0;
		}


		this.transform.position=new Vector3 (this.transform.position.x, vertiRefer+dir*dValue,this.transform.position.z);
		dir = -dir;
		StopCoroutine (FloatUpAndDown ());
		StartCoroutine (FloatUpAndDown ());
	}

	float FallingTime=1.65f;
	float fallingTimeCounter;
	IEnumerator FallInWater(){
		while (Mathf.Abs(this.transform.position.y-(vertiRefer-20f))>0.1f) {
			fallingTimeCounter+=Time.deltaTime;
			Vector3 middle=Vector3.Lerp(this.transform.position.y*Vector3.up,(vertiRefer-20f)*Vector3.up,
			                            (fallingTimeCounter/FallingTime) );
			this.transform.position=new Vector3(this.transform.position.x,middle.y,this.transform.position.z);
			yield return 0;
		}
		this.transform.position=new Vector3(this.transform.position.x,vertiRefer-20f,this.transform.position.z);
		StopCoroutine (FallInWater ());
		StartCoroutine (CameOutWater ());
		StartCoroutine (RotaionWhenCameOutWater ());
	}

	float rotationTime=1.5f;
	float roationCounter;
	IEnumerator RotaionWhenCameOutWater(){
	while (rotationTime>roationCounter) {
			roationCounter+=Time.deltaTime;
			Vector3 middleRa=Vector3.Lerp(0f*Vector3.forward,-90f*Vector3.forward,
			                              (0.7f+(roationCounter/rotationTime) ));
			this.transform.localEulerAngles=new Vector3(0f,0f,middleRa.z);
			yield return 0;
		}
		StopCoroutine (RotaionWhenCameOutWater ());
	
	}



	float upTime=2f;
	float upTimeCounter;
	IEnumerator CameOutWater(){
		while (Mathf.Abs(this.transform.position.y-(vertiRefer))>0.1f) {
			upTimeCounter+=Time.deltaTime;
			Vector3 middle=Vector3.Lerp(this.transform.position.y*Vector3.up,(vertiRefer)*Vector3.up,
			                            (upTimeCounter/upTime) );
			this.transform.position=new Vector3(this.transform.position.x,middle.y,this.transform.position.z);




			yield return 0;
		}
		this.transform.position=new Vector3(this.transform.position.x,vertiRefer,this.transform.position.z);
		StopCoroutine (CameOutWater());
		StartFloat ();

	}

	//	void AnimChange()
//	{
//		float ySpeed = rigid.velocity.y;
//	
//
//
//		if (ySpeed <= -yReference) {
//						if (!anim.GetBool ("down"))		
//								anim.SetBool ("down", true);
//			            if(anim.GetBool("up"))
//						anim.SetBool ("up", false);
//			return;		
//		} if (ySpeed >= yReference) {
//						if (!anim.GetBool ("up"))		
//								anim.SetBool ("up", true);
//			if(anim.GetBool("down"))
//				anim.SetBool ("down", false);		
//			return;			
//		} if(ySpeed >- yReference&&ySpeed < yReference){
//			if(anim.GetBool("down"))
//			anim.SetBool ("down", false);		
//			if(anim.GetBool("up"))
//				anim.SetBool ("up", false);
//			return;	
//		}
//	}
//	



}
