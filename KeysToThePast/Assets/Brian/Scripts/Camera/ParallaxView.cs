using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxView : MonoBehaviour
{
    float startPosition;
    [SerializeField] Transform cam;
    [SerializeField] float parallaxEffect;

    void Start()
    {
        startPosition = transform.position.x;
    }

    void FixedUpdate()
    {
        float distance = cam.transform.position.x * parallaxEffect;

        transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z);
    }
}
