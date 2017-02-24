using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour
{
    Animator anim;
    public float moveSpeed;
    public float attackRange;
    public float attackSpeed;
    public float viewRange;
    float attackTimer;


    GameObject nearEnemie;
    float h;
    float v;
    int direction = 0;
    Pathfinding pathfinding;
    DamageController damageController;
    StatusController status;
    ParticleSystem particles;
    TouchController touchController;
 

    float oldX, oldY;
    
 
    void Awake()
    {

        oldX = (float)System.Math.Round(transform.position.x, 0);
        oldY = (float)System.Math.Round(transform.position.y, 0);
        anim = GetComponent<Animator>();
        pathfinding = GetComponent<Pathfinding>();
        damageController = GetComponent<DamageController>();
        status = GetComponent<StatusController>();
        particles = transform.FindChild("Sparks").GetComponent<ParticleSystem>();
        touchController = GetComponent<TouchController>();

    }

    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime;
        
        MoveDetection();
        manualWalking();

        if (pathfinding.targetObject != null)
        {
            if (pathfinding.distance >= attackRange)
                GoTo(pathfinding.targetObject.transform);
            else
                Attack();
        }
        else
            pathfinding.Find(viewRange);        
        ClampPosition();

    }

    void ClampPosition()
    {
        transform.position = new Vector3(
                                        Mathf.Clamp(transform.position.x, -4f, 8f),
                                        Mathf.Clamp(transform.position.y, -3f, 3f),
                                        0);
    }

    void MoveDetection()
    {
        float curX, curY;
        curX = (float)System.Math.Round(transform.position.x, 1);
        curY = (float)System.Math.Round(transform.position.y, 1);
        if (curX != oldX)
        {
            h = (float)System.Math.Round(oldX - curX, 1);
            
        }        
        else if (curY != oldY)
        {
            v = (float)System.Math.Round(oldY - curY, 1);
            
        }
        oldX = curX;
        oldY = curY;
        
        Animate(h, v);

    }
    void manualWalking()
    {
        GameObject touched = touchController.TouchedObject();
        if (touched != null)
        {
            if (touched.tag == "Monster")
            {
                touched.GetComponent<ColorController>().selected = true;
                if (touched.GetComponent<StatusController>().hPoints > 0)
                {
                    pathfinding.targetObject = touched;
                }
                
            }
        }
      
    }

    void GoTo(Transform target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    void Animate(float h, float v)
    {
        anim.SetFloat("h", h);
        anim.SetFloat("v", v);
    }
   

    void Attack()
    {
        if (attackTimer >= attackSpeed)
        {
            attackTimer = 0;

            anim.SetTrigger("Attack");
            
        }
    }


    public void Harm()
    {        if (pathfinding.targetObject != null)
        {
            particles.Play();
            damageController.TakeDamage(pathfinding.targetObject, status.pAttack, status.mAttack, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
    }
}