using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] float zoomScale = 1;
    [SerializeField] float minDistance = 5;
    Transform cameraTransform;
    Vector3 lastCameraPosition;
    public List<Transform> players;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }

    private void Update()
    {
        if (players.Count == 2)
        {
            CameraFollowsPlayers();
        }
    }

    private void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += deltaMovement;
        lastCameraPosition = cameraTransform.position;
    }

    public void CameraFollowsPlayers()
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
}
