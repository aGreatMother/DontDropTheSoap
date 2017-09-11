using UnityEngine;
using System.Collections;

public class FaceTo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//		Vector3 mousePos = Input.mousePosition;
//		mousePos.z = 10f;
//		this.transform.position = Camera.main.ScreenToWorldPoint (mousePos);
//		FaceToTarget (target.position);
	}
//public Transform target;


	public void FaceToTarget(Vector2 targetPos)
	{
		Vector2 dir = targetPos - (Vector2)this.transform.position;
		if (dir.y < 0f)
						dir.y = -dir.y;
		float angle = Vector2.Angle (Vector2.up, dir);
		if (dir.x > 0)
			this.transform.localEulerAngles =new Vector3(0,0, -angle);
		else
			this.transform.localEulerAngles =new Vector3(0,0, angle);

	}


}
