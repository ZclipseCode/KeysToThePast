using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour{
    [SerializeField] int damage;
    [SerializeField] PlayerAttackStates pas1;
    private void OnTriggerEnter(Collider other) {
        //if (other.GetComponent<Player>()) { //if the other player is hit
        if (pas1.attackState == other.GetComponent<PlayerAttackStates>().attackState) {
            other.GetComponent<Health>().Block();
        }
        else {
            other.GetComponent<Health>().TakeDamage(damage);
        }
       // }
    }
}
