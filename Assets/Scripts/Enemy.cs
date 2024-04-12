using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D _body;
    
    void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        transform.Translate((Vector3.zero - transform.position).normalized * Time.deltaTime);
    }
}
