using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	public Vector3 spawnValues;
	public int pickupCount;
	public Text scoreText;

	public float maxSpawnWait;
	public float minSpawnWait;
	public float startWait;
	public float waveWait;

	private int score;
	public Text lifeText;
	private int lifePoints;

	private bool gameOver;
	private bool restart;
	public Text gameOverText;
	public Text restartText;



	public GameObject player;

	List<GameObject> pickupList = new List<GameObject>();
	public GameObject Pickup1;
	public GameObject Pickup2;
	public GameObject Pickup3;
	public GameObject Pickup4;
	public GameObject Pickup5;
	public GameObject Pickup6;

	List<GameObject> hazardList = new List<GameObject>();
	public GameObject Hazard1;
	public GameObject Hazard2;
	public GameObject Hazard3;
	public GameObject Hazard4;

	void Start()
	{
		pickupList.Add(Pickup1);
		pickupList.Add(Pickup2);
		pickupList.Add(Pickup3);
		pickupList.Add(Pickup4);
		pickupList.Add(Pickup5);
		pickupList.Add(Pickup6);

		hazardList.Add(Hazard1);
		hazardList.Add(Hazard2);
		hazardList.Add(Hazard3);
		hazardList.Add(Hazard4);

		score = 0;
		lifePoints = 3;
		UpdateLife ();
		UpdateScore ();
		gameOver = false;
		restart = false;
		gameOverText.text = "";
		restartText.text = "";

		StartCoroutine (SpawnWaves ());
	}

	void Update(){
		if (gameOver) {
			gameOverText.text = "Fim de jogo!";
			restartText.text = "Pressione R para recomeçar!";
			restart = true;
			player.SetActive (false);
		}
		if (restart) {
			if (Input.GetKey (KeyCode.R)) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			}
		}
		if (Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}
	}

	IEnumerator SpawnWaves(){

		yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i = 0; i < pickupCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, 0);
				Quaternion spawnRotation = Quaternion.identity;
				int pickupIndex = UnityEngine.Random.Range(1, 6);
				Instantiate (pickupList[pickupIndex], spawnPosition, spawnRotation);
				yield return new WaitForSeconds (maxSpawnWait);

			}

			//Alterar posteriormente (verificar uma maneira melhor de implementar)
			int hazardIndex = UnityEngine.Random.Range(1, 4);
			Instantiate (hazardList [hazardIndex], new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, 0), Quaternion.identity);

			yield return new WaitForSeconds (waveWait);

			if (maxSpawnWait > minSpawnWait) {
				IncreaseDifficulty ();
			}
		}
	}

	public void IncreaseDifficulty(){
		maxSpawnWait -= 0.5f;
	}

	public void AddScore(int scoreValue){
		score += scoreValue;
		UpdateScore ();
	}

	public void UpdateLifePoints(){
        lifePoints -= 1;
        if (lifePoints == 0) {
			gameOver = true;
		}	
		UpdateLife ();
	}

	void UpdateLife(){
		lifeText.text = "Vidas: " + lifePoints;
	}

	void UpdateScore(){
		scoreText.text = "Pontos: " + score;
	}
		


}