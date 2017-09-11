using UnityEngine;
using System.Collections;

public class Ornament : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void KillSelf()
	{
		if(Mathf.Abs(transform.position.y-Camera.main.transform.position.y)>90f)
		Destroy (this.gameObject);
	}

}
