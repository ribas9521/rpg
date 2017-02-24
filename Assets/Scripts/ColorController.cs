using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour {
    
    public bool selected, injured;

	void Awake () {
        selected = injured = false;
        
	}
	
	// Update is called once per frame
	void Update () {
        colorize();
	}
    void colorize()
    {
        if(injured == true)
        {
            foreach (Transform child in transform)
            {
                SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
                spriteRenderer.color = Color.red;
            }
        }
        //if(selected == true)
        //{
        //    foreach(Transform child in transform)
        //    {
        //        SpriteOutline spriteoutline = child.GetComponent<SpriteOutline>();
        //        spriteoutline.color = Color.white;
        //    }
        //}
        
        //if(selected == false )
        //{
        //    foreach (Transform child in transform)
        //    {
        //        SpriteOutline spriteoutline = child.GetComponent<SpriteOutline>();
        //        spriteoutline.color = Color.clear;
        //    }
        //}
    }
}
