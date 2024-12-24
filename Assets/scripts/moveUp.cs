using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class moveUp : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public static moveUp Instance;
    [SerializeField] private Rigidbody rd;
    [SerializeField] private GameObject ballPrefab;
    private float delay = 10f;
    GameObject ball;
    private List<GameObject> balls = new List<GameObject>();
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        moveCamera.Instance.player = gameObject;
    }

    void Update()
    {
        if (HomeScreen.Playball)
        {
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                scaleObject();
            }
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "firstBounceGround" || collision.gameObject.tag == "BounceGround")
        {
            rd.AddForce(Vector3.up * 750);
            ballBecomMove();
            if (collision.gameObject.tag == "BounceGround")
            {
                moveCamera.Instance.move = false;
                moveCamera.Instance.goal = true;
            }
        }
    }
    public void scaleObject()
    {
        if (balls.Count > 0)
        {
            GameObject ballPrefab = balls[0];
            ballPrefab.transform.SetParent(null);
            balls.RemoveAt(0);
            Destroy(ballPrefab, delay);
        }
        else
        {
            Debug.LogWarning("No child with tag 'ball' found.");
        }
    }
    public void ballBecomMove()
    {
        if (balls.Count == 0)
        {
            ball = Instantiate(ballPrefab, transform.position + new Vector3(0f, 1.35f, 0.6f), Quaternion.identity);
            ball.transform.SetParent(transform);
            ball.transform.localScale = new Vector3(70f, 70f, 70f);
            balls.Add(ball);
        }
    }
    public void animationofplayer()
    {
        animator.SetTrigger("fire");
    }
   
}
