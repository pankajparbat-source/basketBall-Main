using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loseScrean : BaseScreen
{
    [SerializeField] Button _restartButton;
    //[SerializeField] Button _homeButton;
  

    private void Start()
    {
        _restartButton.onClick.AddListener(OnRestart);
        //_homeButton.onClick.AddListener(OnHome);
       
    }
    public override void ActivateScreen()
    {
        //AudioManager.instance.PlayInBackGround(SoundName.GameOverSound);
        base.ActivateScreen();
    }
    public override void DeactivateScreen()
    {
        base.DeactivateScreen();
    }
    void OnRestart()
    {
        //AudioManager.instance.Play(SoundName.ButtonSound);
        UiManager.instance.SwitchScreen(GameScreens.Play);
        levelManeger.Instance.ResetLevel();
        HomeScreen.Playball = true;
    }
    void OnHome()
    {
        //AudioManager.instance.Play(SoundName.ButtonSound);
        UiManager.instance.SwitchScreen(GameScreens.Home);

    }

  
}
