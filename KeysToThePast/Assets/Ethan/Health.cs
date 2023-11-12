using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour{
    [SerializeField] int maxHP = 100;
    [SerializeField] int HP;
    [SerializeField] Player pl;
    [SerializeField] PlayerAttackStates pas;
    [SerializeField] Rigidbody rb;
    private bool canBeDamaged;
    private int damage;
    //public int tension;
    //[SerializeField] int maxTension;

    Slider healthBar;

    private void Start() {
        HP = maxHP;
        canBeDamaged = true;
        damage = 0;
    }

    public void TakeDamage(int dmg) {
        if (canBeDamaged) {
            canBeDamaged = false;
            damage = dmg;
            Invoke("SendDamage", 1);
        }
    }
    private void SendDamage() {
        ChangeHealthBar();

        HP -= damage;
        if (HP < 0) {
            Death();
        }
        else {
            pas.attackState = CombatState.INCOMBO;
            rb.AddForce(0, damage, 0, ForceMode.Impulse);
        }

        canBeDamaged = true;
    }

    public void Block() {
        HP -= 1;
    }

    private void Death() {
        Destroy(gameObject);

        Application.Quit();
    }

    public void SetHealthBar(Slider bar)
    {
        healthBar = bar;
    }

    public void ChangeHealthBar()
    {
        healthBar.value = HP;
    }
}
