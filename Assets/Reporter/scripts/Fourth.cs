using UnityEngine;
using System.Collections;

public class Fourth : MonoBehaviour {


	void Start () {
		sprite = this.GetComponent<SpriteRenderer> ();
		ChangeStage ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public Sprite[] pictures;
	private SpriteRenderer sprite;
public void ChangeStage()
	{
		this.transform.localEulerAngles=Random.Range(0,4)*90*Vector3.forward;
		if(sprite!=null)
		sprite.sprite = pictures[Random.Range (0, 6)];

	}

}
