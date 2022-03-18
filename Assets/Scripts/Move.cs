using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using static System.Console;

public class Move : MonoBehaviour
{
    float speed = 10;
    private Rigidbody2D rb;

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 tempVect = new Vector3(h, v, 0);
        tempVect = tempVect.normalized * speed * Time.deltaTime;
        rb.MovePosition(rb.transform.position + tempVect);
    }
}