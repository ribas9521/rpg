using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour {

	


    public GameObject TouchedObject()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = new RaycastHit2D();
        if (Input.GetMouseButtonDown(0))
        {
            hit = Physics2D.Raycast(pos, Vector2.zero);
            if (hit.collider != null)
            {
                return hit.transform.gameObject;
            }
            else
                return null;
        }
        else
            return null;
    }
}
