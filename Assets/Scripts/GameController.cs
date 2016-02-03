using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject[] spawnObjects;
	public Vector3 spawnValues;
	public float waveCount;
	public float spawnWait;
	public float waveWait;
	public float startWait;

	public GUIText scoreText;
	public GUIText gameOverText;
	public GUIText restartText;
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
		restartText.text = "";
	}

	void Update(){
		if(restart){
			if(Input.GetKeyDown(KeyCode.R)){
				Application.LoadLevel(Application.loadedLevel);
			}
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
				restartText.text = "Press 'R' to restart!";
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
