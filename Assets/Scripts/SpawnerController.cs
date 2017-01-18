using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnerController : MonoBehaviour {

    
	public IEnumerator Spawn(List<GameObject> spawnables, float timer, int quantity, Vector3 position)
    {
        int i = 0;
        while (i < quantity)
        {
            
            GameObject monsterClone = (GameObject)Instantiate(spawnables[0], position, Quaternion.identity);
            i++;
            yield return new WaitForSeconds(timer);
        }
    }

    public GameObject Spawn(GameObject spawnable, Vector3 position)
    {
       GameObject spawned = (GameObject)Instantiate(spawnable, position, Quaternion.identity);
       return spawned;
    }
}
