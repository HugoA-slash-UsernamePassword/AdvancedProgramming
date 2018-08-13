using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public int damage = 55;
    public BoxCollider hitBox;
    public float hitDuration = 1f;
    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.DealDamage(damage);
        }
    }
    //IEnumerator Hit()
    //{
    //    hitBox.enabled = true;
    //    yield return new WaitForSeconds(hitDuration);
    //    hitBox.enabled = false;
    //}
    // This function is called when the object becomes enabled and active
    private void OnEnable()
    {

    }

}
