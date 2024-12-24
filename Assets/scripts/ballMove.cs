using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ballMove : MonoBehaviour
{

    [SerializeField] private GameObject parent;
    [SerializeField] private float forwardForce = 800f;
    private bool[] triggers = new bool[4];

    private void Update()
    {
        if (HomeScreen.Playball && Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
               

                if (transform.GetComponent<Rigidbody>() == null)
                {
                    Rigidbody rd = gameObject.AddComponent<Rigidbody>();
                    rd.mass = 5f;
                    rd.angularDrag = 0.01f;
                    rd.collisionDetectionMode = CollisionDetectionMode.Continuous;
                    rd.AddForce(new Vector3(0, 3, 2) * forwardForce);
                }
                Destroy(gameObject, 4f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "UpperCollider":

                triggers[0] = true;
                break;
            case "lowerCollider":

                triggers[1] = true;
                break;
            case "UpperGoalCollider":

                triggers[2] = true;
                break;
            case "lowerGoalCollider":

                triggers[3] = true;
                break;
        }
        CheckTriggers();
    }

    private void CheckTriggers()
    {
        if (triggers[0] && triggers[1])
        {
            movePlayer.Instance.move();
            moveCamera.Instance.move = true;
            ResetTriggers(0, 1);
        }
        if (triggers[2] && triggers[3])
        {
            // canvasManeger.Instance.winGame();
            HomeScreen.Playball = false;
            UiManager.instance.SwitchScreen(GameScreens.GameOver);
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
