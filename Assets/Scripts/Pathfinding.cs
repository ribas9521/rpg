using UnityEngine;
using System.Collections;

public class Pathfinding : MonoBehaviour {
    public GameObject target; 
    public GameObject targetObject;
    public float distance = 999;  
    


    void Update()
    {
        if(targetObject!= null)
        distance = Vector3.Distance(transform.position, targetObject.transform.position);
        
    }
   
    public void Find(float viewRange)
    {
        targetObject = null;
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, viewRange);
        if (cols != null)
        {
            Collider2D nearest = cols[0];
            float Idistance, Ndistance;
            foreach (Collider2D Icol in cols)
            {
                if (Icol.gameObject.tag == target.tag)
                {

                    Idistance = Vector3.Distance(transform.position, Icol.transform.position);
                    Ndistance = Vector3.Distance(transform.position, nearest.transform.position);
                    if (Idistance < Ndistance)
                    {
                        nearest = Icol;
                    }

                    if (nearest.tag == target.tag)
                    {
                        targetObject = nearest.gameObject;
                        

                    }

                }
            }
        }

        
       
    }

   

   
}
