using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HurtBox : MonoBehaviour{
    [SerializeField] int damage;
    [SerializeField] PlayerAttackStates pas1;
    [SerializeField] LayerMask enemyLayer;

    private void OnTriggerEnter(Collider other) {
        //if (other.GetComponentInParent<Player>().playerId != gameObject.GetComponentInParent<Player>().playerId) //if the other player is hit
        //{
        //    if (other.GetComponentInParent<PlayerAttackStates>().attackState == CombatState.LOWBLOCK && (pas1.attackState == CombatState.MIDDLEATTACK || pas1.attackState == CombatState.LOWATTACK))
        //    {
        //        other.GetComponentInParent<Health>().Block();
        //    }
        //    else if (other.GetComponentInParent<PlayerAttackStates>().attackState == CombatState.STANDINGBLOCK && (pas1.attackState == CombatState.OVERHEAD || pas1.attackState == CombatState.MIDDLEATTACK))
        //    {
        //        other.GetComponentInParent<Health>().Block();
        //    }
        //    else
        //    {
        //        other.GetComponentInParent<Health>().TakeDamage(damage);
        //    }
        //}

        if (other.GetComponentInParent<PlayerInformation>() != null)
        {
            if (other.GetComponentInParent<PlayerInformation>().info.playerId != gameObject.GetComponentInParent<PlayerInformation>().info.playerId) //if the other player is hit
            {
                if (other.GetComponentInParent<PlayerAttackStates>().attackState == CombatState.LOWBLOCK && (pas1.attackState == CombatState.MIDDLEATTACK || pas1.attackState == CombatState.LOWATTACK))
                {
                    other.GetComponentInParent<Health>().Block();
                }
                else if (other.GetComponentInParent<PlayerAttackStates>().attackState == CombatState.STANDINGBLOCK && (pas1.attackState == CombatState.OVERHEAD || pas1.attackState == CombatState.MIDDLEATTACK))
                {
                    other.GetComponentInParent<Health>().Block();
                }
                else
                {
                    other.GetComponentInParent<Health>().TakeDamage(damage);
                }
            }
        }
    }
}
