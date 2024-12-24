using System;
using UnityEngine;
using UnityEngine.UI;

public class HomeScreen : BaseScreen
{
    [SerializeField] Button _playButton;
    public static bool Playball { get; set; } = false;

    private void Start()
    {
        _playButton.onClick.AddListener(OnPlay);
       
    }
     public override void ActivateScreen()
    {
        //AudioManager.instance.PlayInBackGround(SoundName.HomeScreenSound);
        base.ActivateScreen();
    }
    void OnPlay()
    {
        //AudioManager.instance.Play(SoundName.ButtonSound);
        UiManager.instance.SwitchScreen(GameScreens.Play);
        Playball = true;
    }
    //void OnExit()
    //{
    //    //AudioManager.instance.Play(SoundName.ButtonSound);

    //    Application.Quit();
    //}
    //void OnSetting(){
    //    UiManager.instance.OpenPopUp(GamePopUp.SoundSetting);
    //}
    public static void SetPlayball(bool value)
    {
        Playball = value;
    }
}
