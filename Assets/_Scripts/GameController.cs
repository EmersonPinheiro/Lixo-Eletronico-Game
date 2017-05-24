using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public Vector3 spawnValues;
	public int pickupCount;

	public float spawnWait;
	public float startWait;
	public float waveWait;


	List<GameObject> pickupList = new List<GameObject>();
	public GameObject Pickup1;
	public GameObject Pickup2;
	public GameObject Pickup3;
    public GameObject Pickup4;

    void Start()
	{
		pickupList.Add(Pickup1);
		pickupList.Add(Pickup2);
		pickupList.Add(Pickup3);
        pickupList.Add(Pickup4);

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
}