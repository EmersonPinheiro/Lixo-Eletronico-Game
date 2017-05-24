﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	public Vector3 spawnValues;
	public int pickupCount;
	public Text scoreText;

	public float spawnWait;
	public float startWait;
	public float waveWait;

	private int score;

	List<GameObject> pickupList = new List<GameObject>();
	public GameObject Pickup1;
	public GameObject Pickup2;
	public GameObject Pickup3;

	void Start()
	{
		pickupList.Add(Pickup1);
		pickupList.Add(Pickup2);
		pickupList.Add(Pickup3);

		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}

	IEnumerator SpawnWaves(){

		yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i = 0; i < pickupCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, 0);
				Quaternion spawnRotation = Quaternion.identity;
				int pickupIndex = UnityEngine.Random.Range(0,3);
				Instantiate (pickupList[pickupIndex], spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

		}
	}

	public void AddScore(int scoreValue){
		score += scoreValue;
		UpdateScore ();
	}

	void UpdateScore(){
		scoreText.text = "Pontos: " + score;
	}
}