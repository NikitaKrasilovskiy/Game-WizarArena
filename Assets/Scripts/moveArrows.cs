using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveArrows : MonoBehaviour
{
    public float speed;
    public void Start()
    {
        GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().transform.forward * speed;
    }
}
