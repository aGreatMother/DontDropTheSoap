using UnityEngine;
using System.Collections;

public class Golve : MonoBehaviour {

	public Sprite[] texture;

	// Use this for initialization
	void Start () {
		sprite = this.GetComponent<SpriteRenderer> ();
	   if (Input.touchCount == 2)
						unitDis = (Input.GetTouch (0).position - Input.GetTouch (1).position).sqrMagnitude / 16f;
				;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount == 2)
		AnimChangeWhileFingerMove ();
	}
	private SpriteRenderer sprite;
	private float unitDis;
	int frameCount;
	void AnimChangeWhileFingerMove()
	{
		frameCount =16- (int)((Input.GetTouch (0).position - Input.GetTouch (1).position).sqrMagnitude / unitDis);
        if (frameCount > 15)
						frameCount = 15;
		if (frameCount < 0)
						frameCount = 0;
		this.sprite.sprite = texture [frameCount];
	}

}
