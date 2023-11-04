using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizerUI : MonoBehaviour
{
    [SerializeField] List<GameObject> hats;
    int currentHatIndex;

    public void NextHat()
    {
        if (currentHatIndex + 1 > hats.Count)
        {
            currentHatIndex = 0;
        }
        else
        {
            currentHatIndex++;
        }

        CustomCharacter.setHat(hats[currentHatIndex]);
    }

    public void PreviousHat()
    {
        if (currentHatIndex - 1 < 0)
        {
            currentHatIndex = hats.Count;
        }
        else
        {
            currentHatIndex--;
        }

        CustomCharacter.setHat(hats[currentHatIndex]);
    }

    // choose colors
}
