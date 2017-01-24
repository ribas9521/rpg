using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour
{
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
    StatusController status;
    ParticleSystem particles;


    float oldX, oldY;
    //front  = 0
    //back   = 1
    //right  = 2
    //left   = 3

    // Use this for initialization
    void Awake()
    {
        anim = GetComponent<Animator>();
        pathfinding = GetComponent<Pathfinding>();
        damageController = GetComponent<DamageController>();
        status = GetComponent<StatusController>();
        particles = transform.FindChild("Sparks").GetComponent<ParticleSystem>();

    }

    // Update is called once per frame
    void Update()
    {
        //Walking();
        Direction();
        MoveDetection();
       

        if (pathfinding.targetObject != null)
        {
            if (pathfinding.distance >= attackRange)
                GoTo(pathfinding.targetObject.transform);
            else
                Attack();
        }
        else
            pathfinding.Find(viewRange);
        Animate();
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
        curX = transform.position.x;
        curY = transform.position.y;
        if (curX != oldX)
        {
            h = (oldX - curX) * -10;
            h = Mathf.Round(h * 10) / 10;

        }
        if (curY != oldY)
        {
            v = (oldY - curY) * -10;
            v = Mathf.Round(v * 10) / 10;
        }
        oldX = curX;
        oldY = curY;
       
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
        if (v <= -0.1f)
        {
            direction = 0;
        }
        if (v >= 0.1f)
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
    {        if (pathfinding.targetObject != null)
        {
            particles.Play();
            damageController.TakeDamage(pathfinding.targetObject, status.pAttack, status.mAttack, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
    }


}