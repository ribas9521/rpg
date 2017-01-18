using UnityEngine;
using System.Collections;

public class ArrowController : MonoBehaviour {
    Pathfinding pathfinding;
    DamageController damageController;
    public float moveSpeed;
    public float viewRange;
    Quaternion lookRotation;
    Vector3 direction;

    // Use this for initialization
    void Start () {
        pathfinding = GetComponent<Pathfinding>();
        damageController = GetComponent<DamageController>();
        pathfinding.Find(viewRange);
	}
	void Rotate()
    {
        direction = (pathfinding.targetObject.transform.position - transform.position).normalized;        
        float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
    }
	
	void Update () {

        if (pathfinding.targetObject != null)
        {
            Rotate();
            GoTo(pathfinding.targetObject.transform);
            
            Harm();
            
        }
        else
            SelfDestruction();

	}

    void GoTo(Transform target)
    {
       
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    public void Harm()
    {
        if (pathfinding.distance <= 0.5f)
        {
            damageController.TakeDamage(pathfinding.targetObject, 0);
            SelfDestruction();
        }
       
    }

    public void SelfDestruction()
    {
        Destroy(gameObject);
    }
}
