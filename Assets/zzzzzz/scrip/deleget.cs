using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleget : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

       playerMove. attack += PrimaryAttack;
       playerMove. attack += SecondaryAttack;
        playerMove.attack();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void PrimaryAttack()
    {
        Debug.Log("Primary Attack");
    }

    void SecondaryAttack()
    {
        Debug.Log("Secondary attack");
        // 
    }
}
