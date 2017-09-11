using UnityEngine;
using System.Collections;

public class menuSoap : MonoBehaviour {

	Animator anim;
	// Use this for initialization
	void Start () {


	}
	public void AdjustAnim()
	{
		anim = this.GetComponent<Animator> ();
		anim.SetBool ("on", GameManager.soundOn);
	}
	// Update is called once per frame
	void Update () {
	
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


}
