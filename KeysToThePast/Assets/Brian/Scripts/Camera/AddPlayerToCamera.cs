using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPlayerToCamera : MonoBehaviour
{
    private void Start()
    {
        CameraFollowPlayers.addPlayerToCamera(transform);
    }
}
