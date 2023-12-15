using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public Color targetColor;
    private MeshRenderer targetRenderer;
    public Renderer[] renderers;
    private bool gameover = false;

    private void Awake()
    {
        targetRenderer = GetComponent<MeshRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        renderers = FindObjectsOfType<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            if(Random.value < 0.5)
            {
                renderer.material.color = Color.yellow;
            }
        }
        gameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameover) return;

        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out RaycastHit hitInfo);
            if(hitInfo.collider != null)
            {
                Material material = hitInfo.collider.GetComponent<Renderer>().material;
                if(material.color == Color.white || material.color == targetColor)
                {
                    gameover = true;
                    Debug.Log("졌습니다..");
                    material.color = Color.red;
                    return;
                }
                else
                {
                    material.color = targetColor;
                }
            }
        }

        gameover = true;
        foreach (Renderer renderer in renderers)
        {
            if(renderer.material.color == Color.yellow)
            {
                gameover = false;
            }
        }

        if (gameover)
        {
            Debug.Log($"{Time.time}초만에 승리했습니다!");
        }
    }
}
    