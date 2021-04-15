using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaiEVolta : MonoBehaviour
{
    [Range(0.1f,10f)]
    public float speed;
    public float xmax;

    private float xmin;

    // Start is called before the first frame update
    void Start()
    {
        xmin = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        if(pos.x >= xmax || pos.x <= xmin)
            speed = -speed;
        transform.position = pos;         
    }
}
