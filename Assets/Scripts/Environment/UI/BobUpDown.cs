using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobUpDown : MonoBehaviour
{
    public float bobSpeed = 1f;

    public float originalY;
    public float amplitude;
    void Awake()
    {
        originalY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, originalY+Mathf.Sin(Time.time * bobSpeed)*amplitude, transform.position.z);
    }
}
