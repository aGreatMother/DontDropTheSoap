using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TwoFingerMakePower : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		GetTwoFingerPower ();
	}

	//public TextMesh tex;
	public float PowerRate=10f;
	float maxSpeed;
	Vector2 fingerMidPoint;
	//Vector2 fingerDir;
	//float maxDis;
//	public Text txt;
	public FaceTo handPrefab;
	private FaceTo handInstance;
	void GetTwoFingerPower()
	{    

		if (Input.touchCount == 2) {		
						//txt.text=(Input.GetTouch(0).position-Input.GetTouch(1).position).sqrMagnitude.ToString();
						if (Input.GetTouch (0).phase == TouchPhase.Began || Input.GetTouch (1).phase == TouchPhase.Began) {
								Vector3 midPointOnscreen = (Input.GetTouch (0).position + Input.GetTouch (1).position) / 2;
				midPointOnscreen.z=10;
				fingerMidPoint=Camera.main.ScreenToWorldPoint(midPointOnscreen);
				if (handInstance == null)
									handInstance = (FaceTo)Instantiate (handPrefab);
							handInstance.transform.position = fingerMidPoint;
							handInstance.FaceToTarget (this.transform.position);
				//txt.text=((Vector2)this.transform.position-fingerMidPoint).sqrMagnitude.ToString();	
				              //txt.text=(Input.GetTouch(0).position-Input.GetTouch(1).position).sqrMagnitude.ToString();
								//fingerDir=Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position-Input.GetTouch(1).position);

						}
						if (Input.GetTouch (0).phase == TouchPhase.Moved || Input.GetTouch (1).phase == TouchPhase.Moved) {
								float speed = (Input.GetTouch (0).deltaPosition.magnitude + Input.GetTouch (1).deltaPosition.magnitude) / 2 / Time.deltaTime;
								if (speed > maxSpeed)
										maxSpeed = speed;
						}
						if (Input.GetTouch (0).phase == TouchPhase.Stationary && Input.GetTouch (1).phase == TouchPhase.Stationary|| 
			         Input.GetTouch (0).phase == TouchPhase.Ended || Input.GetTouch (1).phase == TouchPhase.Ended) {
								if (maxSpeed >= 3500f)
										maxSpeed = 3500f;
								this.GetComponent<Rigidbody2D> ().AddForce (maxSpeed * PowerRate * ((Vector2)this.transform.position - fingerMidPoint).normalized);
								
								//txt.text+=(Input.GetTouch(0).position-Input.GetTouch(1).position).sqrMagnitude.ToString();
								//this.GetComponent<Rigidbody2D>().AddForce(maxSpeed*PowerRate* (Vector2)Vector3.Cross(fingerDir,Vector3.forward).normalized); 
								// tex.text=maxSpeed.ToString();
								maxSpeed = 0;

						}
			if( (Input.GetTouch (0).phase == TouchPhase.Ended || Input.GetTouch (1).phase == TouchPhase.Ended)&&handInstance!=null)
				if(handInstance!=null)
					Destroy(handInstance.gameObject);
		} else {
			if(handInstance!=null)
				Destroy(handInstance.gameObject);

			maxSpeed = 0;
				}
	
	}


}