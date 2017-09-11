using UnityEngine;
using System.Collections;

public class Guide : MonoBehaviour {

	public GameObject guideNote;
	public Collider2D[] points; 
	// Use this for initialization
	private MakeMagnetOut makeMag;
	void Start () {
		makeMag = GameObject.FindObjectOfType<MakeMagnetOut> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount == 2) {
			Vector3 touchPoint1 = Camera.main.ScreenToWorldPoint ((Vector3)Input.GetTouch (0).position + 10f * Vector3.forward);		
			Vector3 touchPoint2 = Camera.main.ScreenToWorldPoint ((Vector3)Input.GetTouch (1).position + 10f * Vector3.forward);	
			if ((points [0].OverlapPoint (touchPoint1) && points [1].OverlapPoint (touchPoint2))
				|| (points [0].OverlapPoint (touchPoint2) && points [1].OverlapPoint (touchPoint1))) {
				Destroy (guideNote);
				Destroy(this.gameObject);
				GameManager.start = true;
				makeMag.enabled=true;
				makeMag.MakeMagByPoints(touchPoint1,touchPoint2);
		
			}
		}
	}
}
