using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    [SerializeField] private float tempo = 5f;

    void Start()
    {
        Destroy(gameObject, tempo);
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += transform.right * (speed * Time.deltaTime);
        
    }
}
