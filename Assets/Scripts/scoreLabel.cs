using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private void Start()
    {
        PlayerScore.UpdateScore(100);
    }

    public void Delete()
    {
        Destroy(gameObject);
    } 
}
