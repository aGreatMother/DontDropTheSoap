using UnityEngine;
using System.Collections;

public enum drainType{
	str,
	arc,
	four
	
	
}

public class SingleDrain : MonoBehaviour {

	public drainType type;
	public int dir ;
	//	public int order;
	public bool visible=false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnBecameVisible()
	{


		visible = true;
	}
	void OnBecameInvisible ()
	{

		visible = false;
		
	}




}
