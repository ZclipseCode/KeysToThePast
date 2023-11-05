using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour{
    [SerializeField] int damage;
    private void OnTriggerEnter(Collider other) {
        //if (other.GetComponent<Player>()) { //if the other player is hit
            other.GetComponent<Health>().TakeDamage(damage);
       // }
    }
}
