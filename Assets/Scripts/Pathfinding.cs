using UnityEngine;
using System.Collections;

public class Pathfinding : MonoBehaviour {
    public GameObject target;
    public float moveSpeed;
    public float distance = 999f;
    public GameObject targetObject;
   
    

    // Use this for initialization
    void Start () {
        Find();
    }
    
    // Update is called once per frame
    void FixedUpdate () {

        if (targetObject != null)
        {
            GoTo(targetObject.transform);
        }
        else
            Find();       
        
    }
    
    void GoTo(Transform target)
    {
        distance = Vector3.Distance(transform.position, target.position);
        
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        
    }
    public void Find()
    {
        targetObject = null;
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, 5f);
        Collider2D nearest = cols[0];
        float Idistance, Ndistance;
        foreach(Collider2D Icol in cols)
        {
            if (Icol.gameObject.tag == target.tag)
            {
                            
                Idistance = Vector3.Distance(transform.position, Icol.transform.position);
                Ndistance = Vector3.Distance(transform.position, nearest.transform.position);
                if(Idistance < Ndistance)
                {
                    nearest = Icol; 
                }

                if (nearest.tag == target.tag)
                {
                    targetObject = nearest.gameObject;
                    Debug.Log(targetObject.name);
                }

            }
        }

        
       
    }

   
}
