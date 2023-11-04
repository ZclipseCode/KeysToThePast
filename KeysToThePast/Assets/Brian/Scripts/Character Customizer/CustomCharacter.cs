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
    public delegate void SetShirtTextureDelegate(Texture2D texture);
    public static SetShirtTextureDelegate setShirtTexture;
    public delegate void SetPantsTextureDelegate(Texture2D texture);
    public static SetPantsTextureDelegate setPantsTexture;

    [SerializeField] GameObject hat;

    [SerializeField] Transform hatPosition;
    [SerializeField] MeshRenderer shirtMesh;
    [SerializeField] MeshRenderer pantsMesh;

    bool shirtRgbMode = true;
    bool pantsRgbMode = true;

    private void Awake()
    {
        setHat += SetHat;
        setShirtColor += SetShirtColor;
        setPantsColor += SetPantsColor;
        setShirtTexture += SetShirtTexture;
        setPantsTexture += SetPantsTexture;
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
        if (shirtRgbMode)
        {
            shirtMesh.material.color = color;
        }
    }

    public void SetPantsColor(Color color)
    {
        if (pantsRgbMode)
        {
            pantsMesh.material.color = color;
        }
    }

    public void SetShirtTexture(Texture2D texture)
    {
        shirtMesh.material.mainTexture = texture;

        shirtMesh.material.color = Color.white;
        shirtRgbMode = false;
    }

    public void SetPantsTexture(Texture2D texture)
    {
        pantsMesh.material.mainTexture = texture;

        pantsMesh.material.color = Color.white;
        pantsRgbMode = false;
    }

    private void OnDestroy()
    {
        setHat -= SetHat;
        setShirtColor -= SetShirtColor;
        setPantsColor -= SetPantsColor;
        setShirtTexture -= SetShirtTexture;
        setPantsTexture -= SetPantsTexture;
    }
}
