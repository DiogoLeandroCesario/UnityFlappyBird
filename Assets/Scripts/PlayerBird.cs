using System.Collections;
using System.Collections.Generic;
using System.Security;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class PlayerBird : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    private Rigidbody2D _rb2d;
    [SerializeField] private Transform originOrbit;
    [SerializeField] private Transform projectileOrigin;
    [SerializeField] private float tempoCooldown = 2;
    [SerializeField] private float tempoCooldownAtual;
    [SerializeField] private float moveSpeed = 4;
    [SerializeField] private float jumpSpeed = 8;
    private float ConverterVeloAngulo()
    {
        var radtodeg = 180/Mathf.PI;
        return Mathf.Clamp(radtodeg * Mathf.Atan(_rb2d.velocity.y * 0.08f), -25f, +25f);
    }

    private void Atirar()
    {
        if (tempoCooldownAtual > 0) return;

        var p = Instantiate(projectilePrefab);
        p.transform.position = originOrbit.position;
        p.transform.rotation = projectileOrigin.rotation;
        tempoCooldownAtual = tempoCooldown;



    }

    private void Pular()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb2d.velocity = new Vector2(_rb2d.velocity.x, jumpSpeed);

        }
    }

    private void Mover()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            _rb2d.velocity = new Vector2(-moveSpeed, _rb2d.velocity.y);

        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            _rb2d.velocity = new Vector2(moveSpeed, _rb2d.velocity.y);


        }
    }

    private void Mirar()
    {
        var mp = Input.mousePosition;
        mp = Camera.main.ScreenToWorldPoint(mp);

        var vetorAlvo = mp - transform.position;

        var anguloAlvo = Vector2.SignedAngle(Vector2.right, vetorAlvo);

        originOrbit.rotation = Quaternion.Euler(0, 0, anguloAlvo);
    }

    void Start()
    {
        _rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0)) Atirar();
        if (tempoCooldownAtual > 0) tempoCooldownAtual -= Time.deltaTime;

        Mover();
        Pular();
        Mirar();
        transform.rotation = Quaternion.Euler(0f, 0f, ConverterVeloAngulo());

    }


}
