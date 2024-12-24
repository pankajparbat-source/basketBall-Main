using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour
{
    public float smoothTime = 0.1f;
    public bool move=false;
    Vector3 currentVelocity;
    public static moveCamera Instance;
    [SerializeField] private Rigidbody rd;
    [SerializeField] private GameObject enviroment;
    float offseY=0.1f; 
    public GameObject player;   
    private Vector3 gap;
    public bool goal = false;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }

    void Start()
    {   
        gap = player.transform.position - transform.position;
    } 
 
    private void LateUpdate()
    {
        if(player)
        {
            if (move)
            {         
                offseY = player.transform.position.y;
            }
            else  if (goal)
            {
                offseY = 0.1f;               
            }
            parabolicmovementCamera(offseY);
        }
    }
   void  parabolicmovementCamera(float offseY)
    {
        transform.position = Vector3.SmoothDamp(
                           transform.position,
                          new Vector3(player.transform.position.x, offseY, player.transform.position.z) - gap,
                           ref currentVelocity,
                           smoothTime
                           );
    }
   
}
