using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour{
    [SerializeField] int damage;
    [SerializeField] PlayerAttackStates pas1;
    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<Player>().playerId != gameObject.GetComponent<Player>().playerId) { //if the other player is hit
            if (other.GetComponent<PlayerAttackStates>().attackState == CombatState.LOWBLOCK && (pas1.attackState == CombatState.MIDDLEATTACK || pas1.attackState == CombatState.LOWATTACK)) {
                other.GetComponent<Health>().Block();
            }
            else if (other.GetComponent<PlayerAttackStates>().attackState == CombatState.STANDINGBLOCK && (pas1.attackState == CombatState.OVERHEAD || pas1.attackState == CombatState.MIDDLEATTACK)) {
                other.GetComponent<Health>().Block();
            }
            else {
                other.GetComponent<Health>().TakeDamage(damage);
            }
        }
    }
}
