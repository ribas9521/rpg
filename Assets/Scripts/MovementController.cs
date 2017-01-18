using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {
    Animator anim;
    public float moveSpeed;
    public float attackRange;
    public float viewRange;
    
    GameObject nearEnemie;
    float h;
    float v;
    int direction = 0;
    Pathfinding pathfinding;
    DamageController damageController;
    
    
    float oldX, oldY;
    //front  = 0
    //back   = 1
    //right  = 2
    //left   = 3

    // Use this for initialization
    void Awake () {
        anim = GetComponent<Animator>();
        pathfinding = GetComponent<Pathfinding>();
        damageController = GetComponent<DamageController>();        
               
    }
	
	// Update is called once per frame
	void Update () {        
        //Walking();
        Direction();       
        MoveDetection();        
        if(pathfinding.distance <=0.7f)
        Attack();

        if (pathfinding.targetObject != null)
        {
            GoTo(pathfinding.targetObject.transform);
        }
        else
            pathfinding.Find(viewRange);

    }

	void Walking()
	{

        if (h > 0.1f || h < -0.1f)
        {
            transform.Translate(new Vector3(h * moveSpeed * Time.deltaTime, 0f, 0f));
        }
        if (v > 0.1f || v < -0.1f)
        {
            transform.Translate(new Vector3(0f, v * moveSpeed * Time.deltaTime, 0f));
        }
        Animate();
    }

    void MoveDetection()
    {
        float curX, curY;
        curX = transform.position.x;
        curY = transform.position.y;
        if (curX != oldX)
        {
            h = (oldX - curX) * - 10;
            h = Mathf.Round(h * 10) / 10;            

        }
        if (curY != oldY)
        {
            v = (oldY - curY) * - 10;
            v = Mathf.Round(v * 10) / 10;
        }
        oldX = curX;
        oldY = curY;
        Animate();       
    }

    void GoTo(Transform target)
    {        

        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    void Animate()
    {
        anim.SetFloat("MoveX", h);
        anim.SetFloat("MoveY", v);
    }

    void Direction()
    {
        if(v <= -0.1f)
        {
            direction = 0;
        }
        if(v >= 0.1f)
        {
            direction = 1;
        }
        if (h >= 0.1f)
        {
            direction = 3;
        }
        if (h <= -0.1f)
        {
            direction = 2;            
        }
        
    }

    void Attack()
    {        
            if (direction == 0)
            {
                anim.SetTrigger("AttackFront");

            }
            if (direction == 1)
            {

                anim.SetTrigger("AttackBack");
            }
            if (direction == 2)
            {

                anim.SetTrigger("AttackLeft");
            }
            if (direction == 3)
            {
                anim.SetTrigger("AttackRight");
            }        
    }    
    

    public void Harm()
    {
        if (pathfinding.distance <= attackRange)
            damageController.TakeDamage(pathfinding.targetObject,0);
    }
}
