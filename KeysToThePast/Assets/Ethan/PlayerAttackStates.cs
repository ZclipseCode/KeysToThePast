using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackStates : MonoBehaviour{
    [SerializeField]
    public CombatState attackState;

    [SerializeField]
    public MovementStates moveState;

    public PlayerMovement movementScript;

    private bool attacked = false;
    private bool specialed = false;
    private bool block = false;
    private bool grabbed = false;

    public void OnAttack(InputAction.CallbackContext context)
    {
        attacked = context.action.triggered;
    }
    public void OnSpecial(InputAction.CallbackContext context)
    {
        specialed = context.action.triggered;
    }
    public void OnBlock(InputAction.CallbackContext context)
    {
        block = context.action.triggered;
    }
    public void OnGrab(InputAction.CallbackContext context)
    {
        grabbed = context.action.triggered;
    }

    void Start()
    {
        movementScript = this.gameObject.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        moveState = movementScript.mState;

        if (attacked)
        {
            if(moveState == MovementStates.STANDING || moveState == MovementStates.WALKINGLEFT || moveState == MovementStates.WALKINGRIGHT)
            {
                attackState = CombatState.MIDDLEATTACK;
                //Play Punch Animation
            }
        }
        else
        {
            attackState = CombatState.NOATTACK;
        }
    }


    //if player inputs jab button and not locked in any other animation nor INCOMBO
    //check for airborne, crouching, or standing
    //if walking slow movement and jab animation CombatState = MIDDLEATTACK
    //else if airborne do the overhead attack animation CombatState = OVERHEAD
    //else if crouching do crouching attack animation CombatState = LOWATTACK
    //else not walking just do jab animation CombatState = MIDDLEATTACK

    //if special button is pressed and not locked in any other animation nor INCOMBO
    //check for airborne, crouching, or standing
    //if walking slow movement and do normal special attack CombatState = MIDDLEATTACK
    //else if airborne do the overhead special attack animation CombatState = OVERHEAD
    //else if crouching do crouching special attack animation CombatState = LOWATTACK
    //else not walking just do normal special attack animation CombatState = MIDDLEATTACK

    //IF ATTACK BUTTON IS PRESSED WHILE BLOCKING IT CANCELS THE BLOCK
    //IF PROPERLY BLOCKING ATTACK TAKE CHIP DAMAGE (Like 1 dmg or something)

    //if holding block and not attacking nor airborne
    //check for standing/crouching
    //if standing standing block animation CombatState = STANDINGBLOCK
    //else crouching do crouching block animation CombatState = LOWBLOCK

    //WHEN TAKING DAMAGE IT CANCELS WHAT THE PLAYER TAKING DAMAGE IS DOING
    //THIS ONLY DOESN'T CANCEL WHEN PROPERLY BLOCKED

    //TakeDamage(int damage, CombatState atackerState, CombatState defenderState)
    //attackerState is the state of the player that is dealing damage
    //defenderState is the state of the player that is recieving damage
    //damage is the amount of damage a fully connecting damage does
    //if attackerState is OVERHEAD or MIDDLEATTACK and defenderState is STANDINGBLOCK
    //defender takes only chip damage
    //else if attackerState is LOWATTACK or MIDDLEATTACK and defenderState is LOWBLOCK
    //defender only takes chip damage
    //else defender didn't block incoming damage
    //defender takes full damage
    //gets hit up proportional to damage taken (maybe using addforce() with some equation to determine upward velocity)
    //CombatState = INCOMBO
    //if defender HP is <= 0 Death()

    //DEATH IS FOR IS ONE PLAYER REACHES 0 HP
    //Death()
    //check to see which player is dying
    //do something to indicate the other player winning

    //THE COMBO METHOD IS FOR CHECKING TO SEE IF A PLAYER HAS TOUCHED THE GROUND
    //CALLED IN Update() ONLY IF CombatState == INCOMBO
    //Combo()
    //if player that is INCOMBO isGrounded
    //give player short invunrability (for get-up animation)
    //CombatState = NOATTACK
}

public enum CombatState {
    INCOMBO,
    NOATTACK,
    MIDDLEATTACK,
    LOWATTACK,
    OVERHEAD,
    STANDINGBLOCK,
    LOWBLOCK,
}
