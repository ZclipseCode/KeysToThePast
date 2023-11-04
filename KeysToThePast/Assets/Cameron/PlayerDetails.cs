using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerDetails : MonoBehaviour
{
    public int playerNumber;

    public TMP_Text playerTag;

    // Start is called before the first frame update
    void Start()
    {
        playerTag.text = "Player: " + playerNumber;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
