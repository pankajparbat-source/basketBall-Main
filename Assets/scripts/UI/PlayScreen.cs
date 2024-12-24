using UnityEngine;
using UnityEngine.UI;

public class PlayScreen : BaseScreen
{
    [SerializeField] Button _pauseButton;
    private void Start()
    {
        _pauseButton.onClick.AddListener(OnPause);
    }
    void OnPause()
    {
        //AudioManager.instance.Play(SoundName.ButtonSound);

        //UiManager.instance.SwitchScreen(GameScreens.Pause);
        Application.Quit();
    }
    //public override void ActivateScreen()
    //{
    //    //AudioManager.instance.PlayInBackGround(SoundName.PlayScreenSound);
    //    base.ActivateScreen();
    //}
}
