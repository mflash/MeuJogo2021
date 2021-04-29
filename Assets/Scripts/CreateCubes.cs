using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCubes : MonoBehaviour
{
    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Instantiate(obj, Vector3.zero, Quaternion.identity);
            obj.tag = "cubos";
        }
        if (Input.GetKey(KeyCode.D))
        {
            foreach (GameObject o in GameObject.FindGameObjectsWithTag("cubos"))
                Destroy(o, 0.5f); // delay de 0,5 segundos
        }

    }
}
