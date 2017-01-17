using UnityEngine;
using System.Collections;

public class ArrowController : MonoBehaviour {
    Pathfinding pathfinding;
    DamageController damageController;
	// Use this for initialization
	void Start () {
        pathfinding = GetComponent<Pathfinding>();
        damageController = GetComponent<DamageController>();
         
	}
	
	
	void Update () {
        Harm();

	}

    public void Harm()
    {
        if (pathfinding.distance <= 0.2f)
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
