using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MonsterMovement : MonoBehaviour {
    public GameObject point1, point2, point3, point4, point5, point6;
    int way;
    int reachedPoint =0;
    public float moveSpeed;
    StatusController status;
    public GameObject slider;
    GameObject healthBar;
    //ParticleSystem particles;
    public bool isTouched;
    bool wasKilled;
    float halfMoveSpeed;
    ColorController colorController;
    GameController gameController;
    

    void Awake () {
        status = GetComponent<StatusController>();
        healthBar = Instantiate(slider) as GameObject;
        colorController = GetComponent<ColorController>();
        //particles = transform.FindChild("DeathParticles").GetComponent<ParticleSystem>();
        isTouched = false;
        wasKilled = true;
        halfMoveSpeed = moveSpeed / 2;
        gameController = GameObject.Find("GameMananger").GetComponent<GameController>();


        if (transform.position.y > 0)

            way = 0;

        else if (transform.position.y < 0)
            way = 1;
        else
            Debug.Log("Caminho não encontrado! Spawner no lugar errado");

        
	}
	
	// Update is called once per frame
	void Update () {

       if(way == 0)
        {
            if (reachedPoint == 0)
                Move(point1);
            else if (reachedPoint == 1)
                Move(point2);
            else if (reachedPoint == 2)
                Move(point3);
                
        }
       else if(way == 1)
        {
            if (reachedPoint == 0)
                Move(point4);
            else if (reachedPoint == 4)
                Move(point5);
            else if (reachedPoint == 5)
                Move(point6);

        }
        
        Die();
        SliderControl();
        //particles.Play();
    }

    void SliderControl()
    {
        healthBar.transform.SetParent(GameObject.Find("Canvas").transform);
        healthBar.GetComponent<Slider>().value= status.hPoints;
        Vector3 wantedPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 newPos = new Vector3(wantedPos.x + 5, wantedPos.y + 35f, wantedPos.z);
        healthBar.transform.position = newPos;
    }

    void Move(GameObject point)
    {
        transform.position = Vector3.MoveTowards(transform.position, point.transform.position, moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {       
        if (other.name == "Point1")        
            reachedPoint = 1;       
        if (other.name == "Point2")
            reachedPoint = 2;       
        if (other.name == "Point4")
            reachedPoint = 4;
        if (other.name == "Point5")
            reachedPoint = 5;
        if (other.name == "Crystal")
        {
            wasKilled = false;
            Destroy(gameObject);
        }       
              
    }

    void Die()
    {
        if(status.hPoints <= status.maxHPoints * 0.3f)
        {
            colorController.injured = true;
            moveSpeed = halfMoveSpeed;
            gameObject.layer = 9;
        }
        if (status.hPoints <= 0 )
        {            
            Destroy(gameObject);           
        }       
        
    }

    public void touchKill()
    {
        if(status.hPoints <= status.maxHPoints * 0.3f)
        {            
            status.reward += status.reward * 0.5f;
            Destroy(gameObject);
        }
    }
    void OnDestroy()
    {
        if(wasKilled)
        gameController.UpdateScore((int)status.reward);     
        Destroy(healthBar);
    }
}
