using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasManeger : MonoBehaviour
{
    public static canvasManeger Instance; 
    [SerializeField] private Canvas homeScrean;
    [SerializeField] private Canvas WinScrean;
    // Start is called before the first frame update
    public bool playball = false;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        homeScrean.enabled = true;
        WinScrean.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void playGame()
    {
        homeScrean.enabled = false;
        playball = true;
      
    }
    public void winGame()
    {
        WinScrean.enabled = true;       

    }

}
