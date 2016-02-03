using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject[] spawnObjects;
	public Vector3 spawnValues;
	public float waveCount;
	public float spawnWait;
	public float waveWait;
	public float startWait;

	public Text scoreText;
	public Text gameOverText;
//	public Text restartText;
	public Button restartButton;
	private int score;
	private bool gameOver;
	private bool restart;

	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnWaves());
		score = 0;
		UpdateScore();
		gameOver = false;
		restart = false;
		gameOverText.text = "";
		restartButton.gameObject.SetActive(false);
//		restartText.text = "";
	}

	void Update(){
//		if(restart){
//			if(Input.GetKeyDown(KeyCode.R)){
//				Application.LoadLevel(Application.loadedLevel);
//			}
//		}
	}

	public void Restart(){
		if(restart){
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds(startWait);
		while(true){
			for(int i=0;i<waveCount;i++){
				Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x,spawnValues.x),spawnValues.y,spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate(spawnObjects[Random.Range(0,spawnObjects.Length)],spawnPosition,spawnRotation);
				yield return new WaitForSeconds(spawnWait);
			}
			if(gameOver){
				restart = true;
//				restartText.text = "Press 'R' to restart!";
				restartButton.gameObject.SetActive(true);
				break;
			}
			yield return new WaitForSeconds(waveWait);
		}
	}

	public void AddScore(int addScore){
		this.score += addScore;
		UpdateScore();
	}

	void UpdateScore(){
		scoreText.text = "Score: " + score;
	}

	public void GameOver(){
		this.gameOver = true;
		this.gameOverText.text = "Game Over!";
	}
}
