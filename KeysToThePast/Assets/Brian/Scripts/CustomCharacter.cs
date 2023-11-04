using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCharacter : MonoBehaviour
{
    // include custom moveset

    public delegate void SetHatDelegate(GameObject hat);
    public static SetHatDelegate setHat;

    [SerializeField] GameObject hat;
    [SerializeField] Color shirtColor;
    [SerializeField] Color pantsColor;

    [SerializeField] Transform hatPosition;
    // shirt object
    // pants object

    private void Awake()
    {
        setHat += SetHat;
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

    public void SetShirtColor(Color color) => shirtColor = color;

    public void SetPantsColor(Color color) => pantsColor = color;

    private void OnDestroy()
    {
        setHat -= SetHat;
    }
}
