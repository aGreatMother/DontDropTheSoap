using UnityEngine;
using System.Collections;

public class AutoPlay : MonoBehaviour {

	// Use this for initialization
	public bool autoOn=false;
	Transform soap;
	Transform direction;
	MakeMagnetOut magOutMan;
	void Start () {
		soap = GameObject.Find ("soap").GetComponent<Transform> ();
		direction = GameObject.Find ("oriOne").GetComponent<Transform> ();
		magOutMan = this.GetComponent<MakeMagnetOut> ();
		if (PlayerPrefs.GetInt ("highestScore") > 50)
			StartCoroutine (DelayTime (5f));
		else
			autoOn = true;
	}

	
	// Update is called once per frame
	void Update () {
		MakeMagOut ();
	if (Input.touchCount == 2) {
			if(autoOn)
			StartCoroutine(DelayTime(3f));
			else
				delayCounter=0f;
		   
		}
	}
	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.tag == "dir") {
			direction=other.transform;
		
		}
	}
	public float magLongOff = 8f;
	public GameObject magRPrefab;
	public GameObject magBPrefab;
	GameObject magROn;
	GameObject magBOn;
	void MakeMagOut()
	{
		if (autoOn&&!delaying&&magROn==null&&magBOn==null&&
			soap.GetComponent<Rigidbody2D> ().velocity.y< 5f&&soap.GetComponent<Rigidbody2D> ().velocity.y> -15f) {
			magBOn=(GameObject)Instantiate(magBPrefab);
			magROn=(GameObject)Instantiate(magRPrefab);

			if(soap.GetComponent<Rigidbody2D> ().velocity.y< -5f)
			{magROn.transform.position=soap.transform.position-magLongOff*direction.right
				-(-3f+Mathf.Abs( soap.GetComponent<Rigidbody2D> ().velocity.y))*direction.up;
			magBOn.transform.position=soap.transform.position+magLongOff*direction.right
				-(-3f+Mathf.Abs( soap.GetComponent<Rigidbody2D> ().velocity.y))*direction.up;
				magOutMan.MagPass(magBOn,magROn);}
			else{
				magROn.transform.position=soap.transform.position-magLongOff*direction.right
					-3*direction.up;
				magBOn.transform.position=soap.transform.position+magLongOff*direction.right
					-3*direction.up;
				magOutMan.MagPass(magBOn,magROn);
			}
		
		}



	
	}

	void OnCollisionEnter2D(Collision2D colled)
	{

		if (colled.gameObject.name == "platform"&&!onPlat&&!delaying) {
			if(this.GetComponent<Rigidbody2D>().velocity.sqrMagnitude>=10f)
			colled.gameObject.GetComponent<AudioSource>().Play ();
				StartCoroutine(DelayTime(1f));
			onPlat=true;
				
		

		}
	}
	bool onPlat=false;
	bool delaying=false;
	void OnCollisionExit2D(Collision2D colled){
		if (colled.gameObject.name == "platform" && onPlat) 
			onPlat = false;
		if (colled.gameObject.name == "end")
			StartCoroutine(DelayTime(15f));
	
	}

	float delayCounter=0f;
	IEnumerator DelayTime(float time){
		autoOn = false;
		delaying = true;
		delayCounter = 0f;
		while(delayCounter<=time){
			delayCounter+=Time.deltaTime;
			yield return 0;
		}
		delaying = false;
		delayCounter = 0f;
		autoOn = true;
		StopCoroutine (DelayTime (time));
	}



}