using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCharacter : MonoBehaviour
{
    // include custom moveset

    public delegate void SetHatDelegate(GameObject hat);
    public static SetHatDelegate setHat;
    public delegate void SetShirtColorDelegate(Color color);
    public static SetShirtColorDelegate setShirtColor;
    public delegate void SetPantsColorDelegate(Color color);
    public static SetPantsColorDelegate setPantsColor;

    [SerializeField] GameObject hat;

    [SerializeField] Transform hatPosition;
    [SerializeField] MeshRenderer shirtMesh;
    [SerializeField] MeshRenderer pantsMesh;

    private void Awake()
    {
        setHat += SetHat;
        setShirtColor += SetShirtColor;
        setPantsColor += SetPantsColor;
    }

    private void Start()
    {
        hat.transform.position = hatPosition.position;
    }

    public void SetHat(GameObject h)
    {
        Destroy(hat);
        hat = Instantiate(h, transform);
        hat.transform.position = hatPosition.position;
    }

    public void SetShirtColor(Color color)
    {
        shirtMesh.material.color = color;
    }

    public void SetPantsColor(Color color)
    {
        pantsMesh.material.color = color;
    }

    private void OnDestroy()
    {
        setHat -= SetHat;
        setShirtColor -= SetShirtColor;
        setPantsColor -= SetPantsColor;
    }
}
