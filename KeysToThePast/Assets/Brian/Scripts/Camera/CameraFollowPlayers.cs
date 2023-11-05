using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayers : MonoBehaviour
{
    [SerializeField] float zoomScale = 1;
    [SerializeField] float minDistance = 5;
    //[SerializeField] float parallaxEffectMultiplier = 0.5f;
    Transform cameraTransform;
    //Vector3 lastCameraPosition;
    List<Transform> players;

    public delegate void AddPlayerToCameraDelegate(Transform player);
    public static AddPlayerToCameraDelegate addPlayerToCamera;

    private void Awake()
    {
        addPlayerToCamera += AddPlayer;
    }

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        //lastCameraPosition = cameraTransform.position;

        players = new List<Transform>(2);
    }

    private void Update()
    {
        if (players.Count == 2)
        {
            CameraFollow();
        }
    }

    //private void LateUpdate()
    //{
    //    Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
    //    transform.position += deltaMovement * parallaxEffectMultiplier;
    //    lastCameraPosition = cameraTransform.position;
    //}

    public void CameraFollow()
    {
        float minX = Mathf.Min(players[0].position.x, players[1].position.x);
        float maxX = Mathf.Max(players[0].position.x, players[1].position.x);
        float midX = (minX + maxX) / 2;
        float distanceBetweenPlayers = maxX - minX;

        float cameraX = midX;
        float cameraZ = -zoomScale * Mathf.Max(distanceBetweenPlayers, minDistance);
        Vector3 desiredCameraPos = new Vector3(cameraX, cameraTransform.position.y, cameraZ);

        cameraTransform.position = desiredCameraPos;
    }

    public void AddPlayer(Transform player)
    {
        players.Add(player);
    }

    private void OnDestroy()
    {
        addPlayerToCamera -= AddPlayer;
    }
}
