using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomInstantiation : MonoBehaviour
{
    [SerializeField] SkinnedMeshRenderer body;
    [SerializeField] MeshRenderer head;

    private void Start()
    {
        if (GameManager.head != null)
        {
            head.material.mainTexture = GameManager.head;
        }

        if (GameManager.color != null)
        {
            body.material.color = GameManager.color;
        }
    }
}
