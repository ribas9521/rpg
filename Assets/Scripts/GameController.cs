using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    TouchController touchController;
    Canvas canvas;
    Text text;
    public static int gold;

    void Awake () {
        touchController = GetComponent<TouchController>();
        canvas = GameObject.FindObjectOfType<Canvas>();
        text = canvas.transform.FindChild("Gold").GetComponent<Text>();
        gold = 0;
    }
	
	// Update is called once per frame
	void Update () {

        LastHit();
    }

    public void UpdateScore(int amount)
    {
        if (text != null)
        {
            gold += amount;
            text.text = gold.ToString();
        }
    }

    void LastHit()
    {
        GameObject touched = touchController.TouchedObject();
        if (touched != null)
        {
            if (touched.CompareTag("Monster"))
            {
                touched.GetComponent<MonsterMovement>().touchKill();
            }
        }
    }

    public GameObject[] GetAllMonsters()
    {
        GameObject[] allMonsters = GameObject.FindGameObjectsWithTag("Monster");
        return allMonsters;
    }

    public void GameOver()
    {
        GameObject[] allMonsters = GetAllMonsters();
        foreach(GameObject monster in allMonsters)
        {
            Destroy(monster);
        }
        Destroy(GameObject.Find("Crystal"));
        Destroy(GameObject.Find("Spawners"));
        canvas.transform.FindChild("DeathScreen").gameObject.SetActive(true);        

    }
}
