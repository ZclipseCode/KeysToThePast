using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CustomizerUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hatText;
    [SerializeField] List<GameObject> hats;
    int currentHatIndex;

    [SerializeField] Slider shirtRedSlider;
    [SerializeField] Slider shirtGreenSlider;
    [SerializeField] Slider shirtBlueSlider;
    Color shirtColor;

    private void Start()
    {
        hatText.text = $"Hat {currentHatIndex + 1}/{hats.Count}";

        SetShirtColors();
    }

    public void NextHat()
    {
        if (currentHatIndex + 1 >= hats.Count)
        {
            currentHatIndex = 0;
        }
        else
        {
            currentHatIndex++;
        }

        hatText.text = $"Hat {currentHatIndex + 1}/{hats.Count}";

        CustomCharacter.setHat(hats[currentHatIndex]);
    }

    public void PreviousHat()
    {
        if (currentHatIndex - 1 < 0)
        {
            currentHatIndex = hats.Count - 1;
        }
        else
        {
            currentHatIndex--;
        }

        hatText.text = $"Hat {currentHatIndex + 1}/{hats.Count}";

        CustomCharacter.setHat(hats[currentHatIndex]);
    }

    public void SetShirtColors()
    {
        shirtColor = new Color(shirtRedSlider.value, shirtGreenSlider.value, shirtBlueSlider.value);
        CustomCharacter.setShirtColor(shirtColor);
    }
}
