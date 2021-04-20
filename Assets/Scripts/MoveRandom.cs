using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRandom : MonoBehaviour
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
        if (Vector3.Distance(transform.position, target.position) < 0.1)
        {
            float x = Random.Range(-4.5f, 4.5f);
            float y = 0.5f;
            float z = Random.Range(-4.5f, 4.5f);
            target.position = new Vector3(x, y, z);
        }
    }

    void OnGUI()
    {
        float dist = Vector3.Distance(transform.position, target.position);
        GUI.Label(new Rect(10, 10, 100, 20), $"{dist:f2}"); // 2 casas decimais
    }
}
