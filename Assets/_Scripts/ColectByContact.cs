using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColectByContact : MonoBehaviour {

	public int scoreValue;
	private GameController gameController;

	void Start(){
		GameObject gameControllerObjetc = GameObject.FindGameObjectWithTag ("GameController");
		if(gameControllerObjetc != null){
			gameController = gameControllerObjetc.GetComponent<GameController> ();
		}
		if(gameController == null){
			Debug.Log("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "PickUp") {
			Destroy (other.gameObject);
			gameController.AddScore (scoreValue);
		}
	}
}
