using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    private static ObjectPoolManager _instance;
    public static ObjectPoolManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("ObjectPoolmanager").AddComponent<ObjectPoolManager>();
            }
            return _instance;
        }
    }

    public Cube cubePrefab;
    public Queue<Cube> cubePool;
    private GameObject cubeGrave;

    private void Awake()
    {
        if (_instance != null)
        {
            DestroyImmediate(this.gameObject);
        }
        else
        {
            _instance = this;
            cubePool = new Queue<Cube>();
        }
    }

    private void Start()
    {
        StartCoroutine(CubeGenerateCoroutine());
        cubeGrave = new GameObject("CubeGrave");
    }

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out RaycastHit hitInfo);

            if (hitInfo.collider == null) return;

            if(hitInfo.collider.TryGetComponent<Cube>(out Cube cube))
            {
                if(cube != null)
                {
                    cube.OnClick();
                }
            }
        }
    }

    IEnumerator CubeGenerateCoroutine()
    {
        while (true)
        {
            for(int i = 0; i < 10; i++)
            {
                Cube cube;
                if( cubePool.Count > 0 )
                {
                    cube = cubePool.Dequeue();
                    cube.gameObject.SetActive(true);
                    cube.transform.parent = null;
                }
                else
                {
                    cube = Instantiate(cubePrefab);
                }
                Vector3 randPos = Random.insideUnitSphere * 5f;
                cube.transform.position = randPos;
                cube.transform.rotation = Random.rotation;


                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(3f);
        }
    }

    public void RemoveCube(Cube cube)
    {
        cube.gameObject.SetActive(false);
        cube.transform.parent = cubeGrave.transform;
        cubePool.Enqueue(cube);
    }
}