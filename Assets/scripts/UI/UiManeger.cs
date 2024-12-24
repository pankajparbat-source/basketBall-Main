using System.Collections.Generic;
using UnityEngine;
public enum GameScreens
{
    Home,
    Play,
    GameLose,
    GameOver
}
public enum GamePopUp
{
    SoundSetting,
}
public class UiManager : MonoBehaviour
{
    [SerializeField] BaseScreen _currentScreen;
    public static UiManager instance;
    [SerializeField] List<BaseScreen> _screens;
    private void Start()
    {
        instance = this;
        _currentScreen.ActivateScreen();
    }
    public void SwitchScreen(GameScreens screen)
    {
        foreach (BaseScreen baseScreen in _screens)
        {
            if (baseScreen.screen == screen)
            {    baseScreen.ActivateScreen();
                _currentScreen.DeactivateScreen();
                _currentScreen = baseScreen;
            }
        }
    }
}