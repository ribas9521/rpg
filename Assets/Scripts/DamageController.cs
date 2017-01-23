using UnityEngine;
using System.Collections;

public class DamageController : MonoBehaviour {

	public void TakeDamage(GameObject enemie, float pAttack, float mAttack, float pDefense, float mDefense, float hPoints,
        float mPoints, float criticalChance, float criticalMultiplier, float evasionChance, float accuracy,
        float blockChance)
    {
        StatusController enemieStatus = enemie.GetComponent<StatusController>();
        enemieStatus.hPoints -= (pAttack - pDefense);
        Debug.Log(enemieStatus.hPoints);
    }
}
