//Adrian Proano Bernal A01752615

using System;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.ComponentModel;

public class MenuScript : MonoBehaviour
{
    private UIDocument menu;

    private Button startButton;

    private Button helpButton;

    private Button creditsButton;

    private Button exitButton;

    private Button returnButton;

    private VisualElement buttonContainer;
    
    private VisualElement helpContainer;

    void OnEnable()
    {
        menu = GetComponent<UIDocument>();
        var root = menu.rootVisualElement;
        startButton = root.Q<Button>("Playbutton");
        helpButton = root.Q<Button>("Helpbutton");
        creditsButton = root.Q<Button>("Creditsbutton");
        exitButton = root.Q<Button>("Exitbutton");
        buttonContainer = root.Q<VisualElement>("Buttoncontainer");
        helpContainer = root.Q<VisualElement>("Helpcontainer");

        helpContainer.style.display = DisplayStyle.None;

        returnButton = root.Q<Button>("Returnbutton");


        //Callbacks
        startButton.RegisterCallback<ClickEvent>(StartGame);
        helpButton.RegisterCallback<ClickEvent>(Helptext);
        creditsButton.RegisterCallback<ClickEvent>(Creditsscreen);
        exitButton.RegisterCallback<ClickEvent>(ExitGame);
        returnButton.RegisterCallback<ClickEvent>(ReturnMenu);
        
    }

    private void ReturnMenu(ClickEvent evt)
    {
        buttonContainer.style.display = DisplayStyle.Flex;
        helpContainer.style.display = DisplayStyle.None;
    }

    private void ExitGame(ClickEvent evt)
    {
        print("Game is exiting");
        Application.Quit();
    }

    private void Creditsscreen(ClickEvent evt)
    {
        SceneManager.LoadScene("CreditsScene");
    }

    private void Helptext(ClickEvent evt)
    {
        buttonContainer.style.display = DisplayStyle.None;
        helpContainer.style.display = DisplayStyle.Flex;
    }

    private void StartGame(ClickEvent evt)
    {
        SceneManager.LoadScene("EscenaMario");
    }
}
