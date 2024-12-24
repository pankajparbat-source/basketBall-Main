using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class movePlayerUP : MonoBehaviour
{
    public static movePlayerUP Instance { get; private set; }

    [SerializeField] private Animator animator;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Rigidbody rd;
    private List<GameObject> balls = new List<GameObject>();
    float _timeForTrow = 5f;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InstantiateBall();
    }

    private void Update()
    {
        _timeForTrow += Time.deltaTime;
        if (HomeScreen.Playball && balls.Count >= 0)
        {
            if (_timeForTrow >= 5)
            {_timeForTrow =0 ;
           
                DetachBall();
                Debug.Log("detach method is call");
                animator.SetTrigger("fire");
            }
        }
    }

    public void InstantiateBall()
    {
        if(balls.Count==0)
        {
            Debug.Log("Instantiating ball...");
            GameObject ball = Instantiate(ballPrefab, transform.position + new Vector3(0f, 1.35f, 0.6f), Quaternion.identity);
            ball.transform.SetParent(transform);
            ball.transform.localScale = new Vector3(70f, 70f, 70f);
            balls.Add(ball);
        }
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "firstBounceGround" || collision.gameObject.tag == "BounceGround")
        {
            rd.AddForce(Vector3.up * 750);
            InstantiateBall();
            if (collision.gameObject.tag == "BounceGround")
            {
                moveCamera.Instance.move = false;
                moveCamera.Instance.goal = true;
            }
        }
    }
    #region DetachBall
    private void DetachBall()
    {
        if (balls.Count > 0)
        {
            GameObject ball = balls[0];
            balls.RemoveAt(0);
            ball.GetComponent<ballMOvements>().Detach();
            Debug.Log("Ball detached and moving.");
        }
    }
    #endregion
}