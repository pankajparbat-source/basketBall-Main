using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ballMOvements : MonoBehaviour
{
    private float forwardForce = 120f;
   
    private bool isDetached = false;
    private bool[] triggers = new bool[4];
    private void Start()
    {
      
    }

    private void Update()
    {
        //if (isDetached)
        //{
           
        //    Debug.Log("Ball is moving with AI force.");
        //    isDetached = false; // Ensure force is applied only once
        //    Destroy(gameObject, 4f); // Destroy the ball after 4 seconds
        //}
    }

    public void Detach()
    {       
        transform.SetParent(null);
        Debug.Log("detach from parents");
        Rigidbody rd = gameObject.AddComponent<Rigidbody>();
        rd.AddForce(new Vector3(0, 3, 2) * forwardForce);
        isDetached = true;
        Destroy(gameObject, 4f);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "AIUpperColliderofBasket":

                triggers[0] = true;
                break;
            case "AIlowerColliderofBasket":

                triggers[1] = true;
                break;
            case "AIUpperGoalColliderofBasket":

                triggers[2] = true;
                break;
            case "AIlowerGoalColliderofBasket":

                triggers[3] = true;
                break;
        }
        CheckTriggers();
    }

    private void CheckTriggers()
    {
        if (triggers[0] && triggers[1])
        {
            playGame.Instance.MovePlayer();
            ResetTriggers(0, 1);
        }
        if (triggers[2] && triggers[3])
        {
            // canvasManeger.Instance.winGame();
            HomeScreen.Playball = false;
            UiManager.instance.SwitchScreen(GameScreens.GameLose);
            // levelManeger.Instance.OnLevelCleared();
            ResetTriggers(2, 3);
        }
    }

    private void ResetTriggers(params int[] indices)
    {
        foreach (int index in indices)
        {
            triggers[index] = false;
        }
    }
}
