using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerController : MonoBehaviour {
    public float viewRange;
    public float attackSpeed;
    float timer;
    Pathfinding pathfinding;
    public GameObject projectile;
    SpawnerController spawnerController;
    Transform cannon;
    Quaternion rotation;



    // Use this for initialization
    void Awake() { 
        pathfinding = GetComponent<Pathfinding>();
        spawnerController = GetComponent<SpawnerController>();
        cannon = transform.FindChild("Cannon");
    }
    
    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        if (pathfinding.targetObject != null)
        {
            if (timer >= attackSpeed)
            {
                timer = 0;
                GameObject arrow  = spawnerController.Spawn(projectile, cannon.position);
                
            }
        }
        else
            pathfinding.Find(viewRange);
    }
   

}
