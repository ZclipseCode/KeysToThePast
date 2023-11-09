using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxView : MonoBehaviour
{
    float startPosition;
    Camera cam;
    Transform camTransform;
    [SerializeField] float parallaxEffect;

    void Start()
    {
        cam = Camera.main;
        camTransform = cam.transform;
        startPosition = transform.position.x;
    }

    void FixedUpdate()
    {
        float distance = camTransform.transform.position.x * parallaxEffect;

        transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z);
    }
}
