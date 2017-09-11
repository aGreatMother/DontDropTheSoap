using UnityEngine;
using System.Collections;

public class camreaMoveByMouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 mouseOffset = new Vector2 (Input.mousePosition.x-(Screen.width/2f), Input.mousePosition.y-(Screen.height/2f));
		this.transform.position +=(Vector3)(mouseOffset)*Time.deltaTime;
	}
}
