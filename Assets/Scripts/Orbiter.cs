using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbiter : MonoBehaviour
{
    private Transform orbitParent;
    public float speed;
    public bool turnRight = true;
    void Start()
    {
        orbitParent = transform.parent;
        if(!turnRight)
        {
            speed = -System.Math.Abs(speed);
        }
        else
        {
            speed = System.Math.Abs(speed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vec = orbitParent.position - transform.position;
        Vector3 dir = Vector3.Cross(vec, transform.up);
        dir.Normalize();
        transform.Translate(dir * Time.deltaTime * speed, Space.Self);
    }
}
