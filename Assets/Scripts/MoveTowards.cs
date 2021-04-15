using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    public Transform target;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        // Move objeto na direção do target
        transform.position = Vector3.MoveTowards(transform.position,
            target.position, step);
    }

    void OnGUI()
    {
        float dist = Vector3.Distance(transform.position, target.position);
        GUI.Label(new Rect(10, 10, 100, 20), $"{dist:f2}"); // 2 casas decimais
    }
}
