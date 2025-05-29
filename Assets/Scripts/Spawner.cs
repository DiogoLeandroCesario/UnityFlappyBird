using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform P0;
    [SerializeField] private Transform PF;

    [SerializeField] private GameObject CanosPrefab;

    // Update is called once per frame
    void Spawn()
    {
        var posY = Random.Range(P0.position.y, PF.position.y);
        Instantiate(CanosPrefab).transform.position = new Vector3(P0.position.x, posY, 0);
    }

    private float tempoCooldown = 3;
    private float tempoCooldownAtual = 0;


    void Update()
    {
        if (tempoCooldownAtual <= 0)
        {
            Spawn();
            tempoCooldownAtual = tempoCooldown;
        }
        else
        {
            tempoCooldownAtual -= Time.deltaTime;
        }
    
        


        
    }
}
