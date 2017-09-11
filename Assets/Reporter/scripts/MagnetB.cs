using UnityEngine;
using System.Collections;

public class MagnetB : MonoBehaviour {

	// Use this for initialization
	Transform source;

	// Use this for initialization
	Vector3 targetVector;
	void Start () {
		this.name="MagnetB";



	
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if(source==null)
			source=GameObject.Find ("MagnetR").transform;
		if (source != null) {
			targetVector = source.position-this.transform.position;			

			this.GetComponent<Rigidbody2D>().AddForce (5f*Vector3.Normalize( targetVector)*(1f/Vector3.Magnitude(targetVector)));
						transform.right = -targetVector;
				}
	}
}
