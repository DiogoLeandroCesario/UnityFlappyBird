using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cano : MonoBehaviour
{
    private float speed => ((450f) / (5 * Time.time + 100f) + 1.5f);


    void Update()
    {
        transform.position += (Vector3)Vector2.left * speed * Time.deltaTime;

    }
    
}
