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

    //0 =north
    //1 =south
	void Awake () {
        status = GetComponent<StatusController>();
        healthBar = Instantiate(slider) as GameObject;
        
        
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
        if (other.name == "Point3")
            Destroy(gameObject);
        if (other.name == "Point4")
            reachedPoint = 4;
        if (other.name == "Point5")
            reachedPoint = 5;
        if (other.name == "Point6")
            Destroy(gameObject);
              
    }

    void Die()
    {
        if (status.hPoints <= 0)
        {
            Destroy(gameObject);            
        }
    }

    void OnDestroy()
    {
        Destroy(healthBar);
    }
}
