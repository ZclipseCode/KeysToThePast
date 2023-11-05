using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour{
    [SerializeField] GameObject titleScreen;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject credits;
    [SerializeField] GameObject controls;
    [SerializeField] GameObject chracterSelect;

    private void Start() {
        titleScreen.SetActive(true);
        menu.SetActive(false);
        credits.SetActive(false);
        controls.SetActive(false);
        chracterSelect.SetActive(false);
    }

    public void Menu() {
        titleScreen.SetActive(false);
        menu.SetActive(true);
    }

    public void Fight() {
        Invoke("FightSwap", 1);
    }
    
    private void FightSwap() {
        chracterSelect.SetActive(true);
        menu.SetActive(false);
    }

    public void Controls() {
        menu.SetActive(false);
        controls.SetActive(true);
    }

    public void Credits() {
        menu.SetActive(false);
        credits.SetActive(true);
    }

    public void Title() {
        menu.SetActive(false);
        titleScreen.SetActive(true);
    }

    public void Back() {
        menu.SetActive(true);
        credits.SetActive(false);
        controls.SetActive(false);
        chracterSelect.SetActive(false);
    }

    public void Custom() {
        SceneManager.LoadScene("CharacterCustomizer");
    }
}
