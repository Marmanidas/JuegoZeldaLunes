using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Personaje : MonoBehaviour
{
    public float velocidad;
    public int vidas;
    public Slider sliderVidas;

    private Rigidbody2D rig;
    private Animator anim;
    private SpriteRenderer spritePersonaje;

    private int cantidadMonedas;
    public TextMeshProUGUI textoMonedas;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        spritePersonaje = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        sliderVidas.maxValue = vidas;
        sliderVidas.value = vidas;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            vidas--;
            sliderVidas.value = vidas;
        }
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rig.velocity = new Vector2(horizontal, vertical) * velocidad;
        anim.SetFloat("Camina", Mathf.Abs(rig.velocity.magnitude));

        if (horizontal > 0)
        {
            spritePersonaje.flipX = false;
        }
        else if  (horizontal < 0)
        {
            spritePersonaje.flipX = true;
        }

    }

    public void SumarMonedas(int valorMoneda)
    {     
        cantidadMonedas += valorMoneda;
        textoMonedas.text = cantidadMonedas.ToString();
    }
}
