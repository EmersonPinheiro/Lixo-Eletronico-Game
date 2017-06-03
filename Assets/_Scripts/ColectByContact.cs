using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColectByContact : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "PickUp") {
			Destroy (other.gameObject);
<<<<<<< HEAD
			gameController.AddScore (scoreValue);
		} 
		if (other.gameObject.tag == "Hazard") {
			Destroy (other.gameObject);
			gameController.UpdateLifePoints ();
=======
>>>>>>> origin/junior
		}
	}
}
