using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ButtonFunctions : MonoBehaviour {

	Image soundImage;
	menuSoap soap;
	// Use this for initialization
	void Start () {
		GameManager.soundOn = PlayerPrefs.GetInt ("sound") == 0 ? true : false;
	AudioListener.volume = GameManager.soundOn ? 1 : 0;
		if (Application.loadedLevel == 0) {
			soundImage = GameObject.Find ("sound").GetComponent<Image> ();
			soundImage.sprite = soundPicture [GameManager.soundOn ? 0 : 1];
			soap = GameObject.FindObjectOfType<menuSoap> ().GetComponent<menuSoap> ();
			soap.AdjustAnim ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("escape"))
			Application.Quit() ;
	}
	public void Restart()
	{
		GameManager.score = 0;
		GameManager.difficulty = 0;
		GameManager.gameOver = false;
		GameManager.start = false;
		Application.LoadLevel (1);
	}
	public Sprite[] soundPicture;
	public void SoundChange(){
	
		GameManager.soundOn = !GameManager.soundOn;
		AudioListener.volume = GameManager.soundOn ? 1 : 0;
		PlayerPrefs.SetInt("sound",GameManager.soundOn?0:1);
		soundImage.sprite=soundPicture[GameManager.soundOn?0:1];
		soap.AdjustAnim ();
	}
  public void BackToMenu()
	{
		GameManager.score = 0;
		GameManager.difficulty = 0;
		GameManager.gameOver = false;
		Application.LoadLevel (0);
	}


}
