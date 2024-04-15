using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUiHp : MonoBehaviour
{
    public void ChangeText(int value)
    {
        GetComponent<Text>().text = value.ToString();
    }
}
