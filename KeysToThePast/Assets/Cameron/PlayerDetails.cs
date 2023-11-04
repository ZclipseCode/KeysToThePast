using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerDetails : MonoBehaviour
{
    public int playerNumber;

    public TMP_Text playerTag;

    public GameObject otherPlayer = null;

    public bool playerOnRightSide;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerTag.text = "Player: " + playerNumber;
        gameObject.name = "Player " + playerNumber;

        if (otherPlayer == null)
        {
            if(playerNumber == 1)
            {
                otherPlayer = GameObject.Find("Player " + 2);
            }
            else if(playerNumber == 2)
            {
                otherPlayer = GameObject.Find("Player " + 1);
            }
        }
        else if (otherPlayer != null)
        {
            if(transform.position.x > otherPlayer.transform.position.x && !playerOnRightSide)
            {
                Flip();
                playerOnRightSide = true;
            }
            else if(transform.position.x < otherPlayer.transform.position.x && playerOnRightSide)
            {
                Flip();
                playerOnRightSide = false;
            }
        }
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}
