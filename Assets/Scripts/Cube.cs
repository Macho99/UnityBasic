using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour
{
    public void OnClick()
    {
        ObjectPoolManager.Instance.RemoveCube(this);
    }

    private void OnEnable()
    {
        GetComponent<Renderer>().material.color = Random.ColorHSV();
    }
}