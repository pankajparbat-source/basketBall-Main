using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : BaseScreen
{
    [SerializeField] Button _restartButton;
    //[SerializeField] Button _homeButton;
    [SerializeField] Button _nextButton;

    private void Start()
    {
        _restartButton.onClick.AddListener(OnRestart);
        //_homeButton.onClick.AddListener(OnHome);
        _nextButton.onClick.AddListener(OnNext);
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

    void OnNext()
    {
        //AudioManager.instance.Play(SoundName.ButtonSound);
        levelManeger.Instance.OnLevelCleared();
        UiManager.instance.SwitchScreen(GameScreens.Play);
        HomeScreen.Playball = true;

    }

}
