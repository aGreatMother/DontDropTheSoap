using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {

	public static GameObject soap;
	public static int score =0;
	public static int difficulty=0;
	public static bool gameOver=false;
	public static bool soundOn=true;
	public static bool start=false;
	private AudioSource backMusic;
	// Use this for initialization
	public AudioClip[] clips;
	void Start () {
		backMusic = this.GetComponent<AudioSource> ();
       
		GameManager.score = 0;
		GameManager.difficulty = 0;
		GameManager.gameOver = false;
		start = false;
		soap=GameObject.Find("soap");

	}
	void OnceStart(){
		if (start && backMusic.clip != clips [1]) {
			float part=backMusic.time;
			backMusic.clip = clips [1];
			backMusic.time=part;
			backMusic.Play ();
		}

			
	}
	// Update is called once per frame
	void Update () {
		ScoreShow ();
		ChangeDifficulty ();
		OnceStart ();
		OnceGameOver ();
		if (Input.GetKey ("escape"))
			Application.LoadLevel (0);

	}

	public Text scoreBroad;

	void ScoreShow()
	{
		int scoreRefer = (int)(soap.transform.position.y / 30f);
		if (scoreBroad!=null&&scoreRefer > score)
			score = scoreRefer;
		scoreBroad.text = score.ToString ();
	}

	void ChangeDifficulty()
	{
		difficulty=(int)(score/2);

	}
    
	public GameObject gameOverUIPrefabs;
	GameObject gameOverUIon;
	void OnceGameOver()
	{
		if (gameOver && backMusic.clip != clips [0]) {
			backMusic.Stop ();
		}

		if (gameOver && gameOverUIon == null) {

			Destroy(scoreBroad.transform.parent.gameObject);
			gameOverUIon = (GameObject)Instantiate (gameOverUIPrefabs);

			gameOverUIon.transform.SetParent(GameObject.FindObjectOfType<Canvas>().transform,false);
		}

	}
  
}
