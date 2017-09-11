using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ScoreBoard : MonoBehaviour {

	Text text;
	Text hint;
	// Use this for initialization
	void Start () {
		hint = GameObject.Find ("hint").GetComponent<Text> ();
		text = this.GetComponent<Text> ();
		text.text = "your score: " + GameManager.score.ToString ()+"\n highest score: "
			+PlayerPrefs.GetInt("highestScore")+"\n";
		if (GameManager.score > PlayerPrefs.GetInt ("highestScore")) {
			PlayerPrefs.SetInt("highestScore",GameManager.score);
			text.text+="new record!";
		}
		if(GameManager.score<30&&PlayerPrefs.GetInt("highestScore")<30)
			hint.text="if you still don't know how to play,go back to menu and figure out!";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
