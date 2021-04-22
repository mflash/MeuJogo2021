using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVehicle : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 90f;

    void Update()
    {
        // Troque para GetAxisRaw para obter -1, 0 ou 1
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(vertical * Vector3.forward * moveSpeed * Time.deltaTime);
        transform.Rotate(horizontal * Vector3.up, turnSpeed * Time.deltaTime);
    }
}
