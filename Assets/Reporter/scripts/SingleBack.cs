using UnityEngine;
using System.Collections;

public class SingleBack : MonoBehaviour {

	public bool visible=false;
	private Fourth[] fourths;
 	// Use this for initialization
	void Start () {
		fourths = new Fourth[12];
//		ornaments = new Ornament[3];
//		ornaments = this.GetComponentsInChildren<Ornament> ();
		fourths= this.GetComponentsInChildren< Fourth> ();
		ChangeToOtherPlace (this.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
//	Ornament[] ornaments;
	public void ChangeToOtherPlace(Vector3 To )
	{
		 
		this.transform.position = To;
	    

//			float yPos=this.transform.position.y-400f+Random.Range(10f,190f);
//			float xPos=this.transform.position.x+Random.Range(-270f,270f);
//		ornaments [0].transform.position = new Vector3 (xPos, yPos, this.transform.position.z);
//
//		yPos=this.transform.position.y-400f+Random.Range(210f,390f);
//		 xPos=this.transform.position.x+Random.Range(-270f,270f);
//		ornaments [1].transform.position = new Vector3 (xPos, yPos, this.transform.position.z);
//			
//	 yPos=this.transform.position.y-400f+Random.Range(410f,590f);
//		 xPos=this.transform.position.x+Random.Range(-270f,270f);
//		ornaments [2].transform.position = new Vector3 (xPos, yPos, this.transform.position.z);

		for (int i=0; i<=fourths.Length-1; i++) {
			if(fourths[i]!=null)
				fourths[i].ChangeStage ();
		
		
		}

	}
	void OnBecameVisible()
	{
		if (visible)
						return;

		visible = true;
	}
	void OnBecameInvisible ()
	{
		if (!visible)
						return;

		visible = false;

	}
}
