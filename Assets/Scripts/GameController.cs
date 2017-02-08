using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    
    // Use this for initialization
    void Awake () {
       
    }
	
	// Update is called once per frame
	void Update () {

        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
        if (hit)
        {
            hit.transform.gameObject.GetComponent<MonsterMovement>().isTouched = true;
        }


    }
}
