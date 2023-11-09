using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Windows.Forms;
using UnityEditor;
using System.IO;

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

    // last second
    [SerializeField] Slider meshRedSlider;
    [SerializeField] Slider meshGreenSlider;
    [SerializeField] Slider meshBlueSlider;
    Color meshColor;

    [SerializeField] GameObject timeTravelerInScene;
    Texture2D texture;
    Color color = Color.white;

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

    public void SetMeshColors()
    {
        meshColor = new Color(meshRedSlider.value, meshGreenSlider.value, meshBlueSlider.value);

        color = meshColor;

        CustomCharacter.setColor(meshColor);
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

    public void UploadMesh()
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Image Files|*.jpg;*.png;*.jpeg;*.bmp|All Files|*.*";

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            string selectedFilePath = openFileDialog.FileName;

            Texture2D selectedTexture = LoadTexture(selectedFilePath);

            CustomCharacter.setTexture(selectedTexture);
        }
    }

    public void UploadHead()
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Image Files|*.jpg;*.png;*.jpeg;*.bmp|All Files|*.*";

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            string selectedFilePath = openFileDialog.FileName;

            Texture2D selectedTexture = LoadTexture(selectedFilePath);

            texture = selectedTexture;

            CustomCharacter.setHeadTexture(selectedTexture);
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

    public void SaveCharacter()
    {
        //GameManager.timeTraveler = timeTravelerInScene;

        if (!Directory.Exists("Assets/Prefabs"))
            AssetDatabase.CreateFolder("Assets", "Custom");
        string localPath = "Assets/Custom/" + timeTravelerInScene.name + ".prefab";

        // Make sure the file name is unique, in case an existing Prefab has the same name.
        //localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);

        // Create the new Prefab and log whether Prefab was saved successfully.
        bool prefabSuccess;
        GameObject newTimeTraveler = PrefabUtility.SaveAsPrefabAsset(timeTravelerInScene, localPath, out prefabSuccess);
        if (prefabSuccess == true)
            Debug.Log("Prefab was saved successfully");
        else
            Debug.Log("Prefab failed to save" + prefabSuccess);

        GameManager.timeTraveler = newTimeTraveler;
        GameManager.head = texture;
        GameManager.color = color;
    }
}
