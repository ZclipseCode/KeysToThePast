using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashTrans : MonoBehaviour
{

    public float displayTime;
    public float fadeSpeed;
    public Image logo;
    public string menus = "ElijahMenus";

    private void Start()
    {
        StartCoroutine(LoadSplash());
    }
    IEnumerator LoadSplash()
    {
        float increment = fadeSpeed * Time.deltaTime;

        while (logo.color.a < 255)
        {
            logo.color = new Color(255, 255, 255, logo.color.a + increment);
            yield return null;
        }

        Debug.Log("a");
        logo.color = new Color(255, 255, 255, 255);
        yield return new WaitForSeconds(displayTime);

        SceneManager.LoadScene(menus);
    }
}
