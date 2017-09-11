using UnityEngine;
using System.Collections;

public class MakeMagnetOut : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		MakeTwoMagnetOut ();
		TwoMagBoomAndDestory ();
	
	}
	public GameObject magRPrefab;
	public GameObject magBPrefab;
	 GameObject magRins;
	 GameObject magBins;
	public static bool magRComeTooClose=false;
	public static bool magBComeTooClose=false;
	float closeReferSqr=80f;
	void MakeTwoMagnetOut()
	{
		if ((GameManager.start||Application.loadedLevel==0)&&!GameManager.gameOver
		    && Input.touchCount == 2&&magBins==null&&magRins==null
		    &&(Input.GetTouch(0).phase==TouchPhase.Began||Input.GetTouch(1).phase==TouchPhase.Began)) {
			Vector3 touchPoint1=Camera.main.ScreenToWorldPoint((Vector3)Input.GetTouch(0).position+10f*Vector3.forward);		
			Vector3 touchPoint2=Camera.main.ScreenToWorldPoint((Vector3)Input.GetTouch(1).position+10f*Vector3.forward);		
			magBins=(GameObject)Instantiate(magBPrefab);
			magRins=(GameObject)Instantiate(magRPrefab);
		magBins.transform.position=touchPoint1.x>touchPoint2.x?touchPoint1:touchPoint2;
		magRins.transform.position=touchPoint1.x<=touchPoint2.x?touchPoint1:touchPoint2;
		if((magRins.transform.position-this.transform.position).sqrMagnitude<=closeReferSqr)
				magRComeTooClose=true;
			if((magBins.transform.position-this.transform.position).sqrMagnitude<=closeReferSqr)
				magBComeTooClose=true;

		
		}


	}

//	public ParticleSystem spark;
	public GameObject sparkPrefab;
	GameObject sparkOn;
	public float magDisLong=13f;


	void TwoMagBoomAndDestory()
	{
		if (magRins != null && magBins != null&&(magRins.transform.position-magBins.transform.position).sqrMagnitude<=magDisLong
		    &&sparkOn==null) {
			sparkOn=(GameObject)Instantiate(sparkPrefab);
			sparkOn.transform.position=(magRins.transform.position+magBins.transform.position)/2f;
			sparkOn.transform.right=magRins.transform.position-magBins.transform.position;
			Destroy(magRins.gameObject,0.1f);
			Destroy(magBins.gameObject,0.1f);   
			magBComeTooClose=false;
			magRComeTooClose=false;

			Destroy(sparkOn.gameObject,0.25f);
		}
			
			
	}

  public void MagPass(GameObject magR,GameObject magB ){
		magRins = magR;
		magBins = magB;


	}

	public void MakeMagByPoints(Vector3 touchPoint1,Vector3 touchPoint2){
		magBins=(GameObject)Instantiate(magBPrefab);
		magRins=(GameObject)Instantiate(magRPrefab);
	magBins.transform.position=touchPoint1.x>touchPoint2.x?touchPoint1:touchPoint2;
	magRins.transform.position=touchPoint1.x<=touchPoint2.x?touchPoint1:touchPoint2;
	
	}


}
