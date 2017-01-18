using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterSpawner : MonoBehaviour {
    public List<GameObject> spawnables;
    public float timer;
    public int quantity;
    SpawnerController spawnerController;
	
	void Awake () {
        spawnerController = GetComponent<SpawnerController>();
        StartCoroutine(spawnerController.Spawn(spawnables,timer,quantity, transform.position));
	}
	
}
