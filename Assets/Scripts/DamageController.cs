using UnityEngine;
using System.Collections;

public class DamageController : MonoBehaviour {

	public void TakeDamage(GameObject enemie, float damage)
    {
        Destroy(enemie);
    }
}
