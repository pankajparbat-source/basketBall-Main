using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class levelManeger : MonoBehaviour
{
    public static levelManeger Instance;
    // Start is called before the first frame update
    public List<GameObject> levelPrefabs;
    private int currentLevelIndex = 0;
    private GameObject currentLevel;
    public GameObject environmentParent;
    [SerializeField] private TMP_Text uiText;

    void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }
    void Start()
    {
        LoadNextLevel();
    }
    private void LoadNextLevel()
    {
        if (currentLevelIndex < levelPrefabs.Count)
        {
           NextLevel();
        }
        else
        {
            currentLevelIndex=0;
            NextLevel();
        }
    }
    public void NextLevel()
    {
        int indeLevel = currentLevelIndex+1;
        uiText.text = indeLevel.ToString();
        currentLevel = Instantiate(levelPrefabs[currentLevelIndex], Vector3.zero, Quaternion.identity, environmentParent.transform);
        movePlayer.Instance.indexValueReset();
        movePlayer.Instance.resetplayer();
        currentLevelIndex++;
    }
    public void OnLevelCleared()
    {
        if (currentLevel != null)
        {
            Destroy(currentLevel);
        }
        StartCoroutine(ShowLevelClearedMessage());
    }

    private IEnumerator ShowLevelClearedMessage()
    {
        yield return new WaitForSeconds(0.0000001f);
        LoadNextLevel();
    }
    public void ResetLevel()
    {
        movePlayer.index = 0;

        if (currentLevel != null)
        {
            Destroy(currentLevel);
        }
        StartCoroutine(ShowLevelClearedMessage1());
    }
    private IEnumerator ShowLevelClearedMessage1()
    {
        yield return new WaitForSeconds(0.0000001f);
        Debug.Log("ShowLevelClearedMessage inside ");
        currentLevel = Instantiate(levelPrefabs[currentLevelIndex - 1], Vector3.zero, Quaternion.identity, environmentParent.transform);
    }
}
