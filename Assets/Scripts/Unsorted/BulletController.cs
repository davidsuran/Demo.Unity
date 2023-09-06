using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private float _movementSpeed = 5f;

    void Start()
    {
    }

    void Update()
    {
        //transform.position += Vector3.up * Time.deltaTime * _movementSpeed;

        transform.Translate(Vector3.up * Time.deltaTime * _movementSpeed);
    }
}
