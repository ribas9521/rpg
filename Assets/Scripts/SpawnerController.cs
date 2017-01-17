using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnerController : MonoBehaviour {

    public int quantity;
    public List<GameObject> monsters;
   
	// Use this for initialization
	void Start () {
        StartCoroutine(Spawn());
	}
	IEnumerator Spawn()
    {
        int i = 0;
        while (i < quantity)
        {
            
            GameObject monsterClone = (GameObject)Instantiate(monsters[0], transform.position, Quaternion.identity);
            i++;
            yield return new WaitForSeconds(1f);
        }
    }

}
