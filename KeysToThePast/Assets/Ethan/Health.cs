using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour{
    [SerializeField] int maxHP = 100;
    [SerializeField] int HP;
    [SerializeField] Player pl;
    [SerializeField] PlayerAttackStates pas;
    [SerializeField] Rigidbody rb;
    //public int tension;
    //[SerializeField] int maxTension;

    private void Start() {
        HP = maxHP;
    }

    public void TakeDamage(int damage) {
        HP -= damage;
        if(HP < 0) {
            Death();
        }
        else {
            pas.attackState = CombatState.INCOMBO;
            rb.AddForce(0,damage,0, ForceMode.Impulse);
        }
    }

    public void Block() {
        HP -= 1;
    }

    private void Death() {
        Destroy(gameObject);
    }
}
