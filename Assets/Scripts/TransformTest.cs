using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformTest : MonoBehaviour
{
    public GameObject target;
    private Renderer render;
    public float degree = 40;
    public float dist = 1;
    private void Awake()
    {
        render = GetComponent<Renderer>();
    }
    private void Start()
    {
        StartCoroutine(RandomCoroutine());
    }
    private IEnumerator RandomCoroutine()
    {
        while(true)
        {
            render.material.color = Random.ColorHSV();
            transform.up = Random.onUnitSphere;
            yield return new WaitForSeconds(1.0f);
        }
    }
    void Update()
    {
        transform.Translate(new Vector3(0, dist * Time.deltaTime, 0));
    }
}
