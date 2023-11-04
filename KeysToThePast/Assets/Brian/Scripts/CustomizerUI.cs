using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Windows.Forms;

public class CustomizerUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hatText;
    [SerializeField] List<GameObject> hats;
    int currentHatIndex;

    [SerializeField] Slider shirtRedSlider;
    [SerializeField] Slider shirtGreenSlider;
    [SerializeField] Slider shirtBlueSlider;
    Color shirtColor;

    [SerializeField] Slider pantsRedSlider;
    [SerializeField] Slider pantsGreenSlider;
    [SerializeField] Slider pantsBlueSlider;
    Color pantsColor;

    private void Start()
    {
        hatText.text = $"Hat {currentHatIndex + 1}/{hats.Count}";

        SetShirtColors();

        SetPantsColors();
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

    public void SetPantsColors()
    {
        pantsColor = new Color(pantsRedSlider.value, pantsGreenSlider.value, pantsBlueSlider.value);
        CustomCharacter.setPantsColor(pantsColor);
    }

    public void UploadShirt()
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Image Files|*.jpg;*.png;*.jpeg;*.bmp|All Files|*.*";

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            string selectedFilePath = openFileDialog.FileName;

            Texture2D selectedTexture = LoadTexture(selectedFilePath);

            CustomCharacter.setShirtTexture(selectedTexture);
        }
    }

    public void UploadPants()
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Image Files|*.jpg;*.png;*.jpeg;*.bmp|All Files|*.*";

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            string selectedFilePath = openFileDialog.FileName;

            Texture2D selectedTexture = LoadTexture(selectedFilePath);

            CustomCharacter.setPantsTexture(selectedTexture);
        }
    }

    private Texture2D LoadTexture(string filePath)
    {
        byte[] fileData = System.IO.File.ReadAllBytes(filePath);
        Texture2D texture = new Texture2D(2, 2);

        if (texture.LoadImage(fileData))
        {
            return texture;
        }

        return null;
    }
}
