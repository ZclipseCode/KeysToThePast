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

    // last second
    public delegate void SetTextureDelegate(Texture2D texture);
    public static SetTextureDelegate setTexture;
    public delegate void SetColorDelegate(Color color);
    public static SetColorDelegate setColor;
    [SerializeField] SkinnedMeshRenderer mesh;
    bool meshRgbMode = true;

    [SerializeField] MeshRenderer head;
    public delegate void SetHeadTextureDelegate(Texture2D texture);
    public static SetHeadTextureDelegate setHeadTexture;

    private void Awake()
    {
        setHat += SetHat;
        setShirtColor += SetShirtColor;
        setPantsColor += SetPantsColor;
        setShirtTexture += SetShirtTexture;
        setPantsTexture += SetPantsTexture;

        setTexture += SetTexture;
        setColor += SetMeshColor;

        setHeadTexture += SetHeadTexture;
    }

    private void Start()
    {
        hat.transform.position = hatPosition.position;
    }

    public void SetHat(GameObject h)
    {
        Destroy(hat);
        hat = Instantiate(h, hatPosition);
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

    public void SetTexture(Texture2D texture)
    {
        mesh.material.mainTexture = texture;

        mesh.material.color = Color.white;
        meshRgbMode = false;
    }

    public void SetMeshColor(Color color)
    {
        if (meshRgbMode)
        {
            mesh.material.color = color;
        }
    }

    public void SetHeadTexture(Texture2D texture)
    {
        head.material.mainTexture = texture;

        //mesh.material.color = Color.white;
        //meshRgbMode = false;
    }

    private void OnDestroy()
    {
        setHat -= SetHat;
        setShirtColor -= SetShirtColor;
        setPantsColor -= SetPantsColor;
        setShirtTexture -= SetShirtTexture;
        setPantsTexture -= SetPantsTexture;

        setTexture -= SetTexture;
        setColor -= SetMeshColor;

        setHeadTexture -= SetHeadTexture;
    }
}
