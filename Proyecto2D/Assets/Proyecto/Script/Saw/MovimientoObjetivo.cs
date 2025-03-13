using System;
using System.Collections;
using UnityEngine;

public class MovimientoObjetivo : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 posicionInicial;    // Posicion donde comienza la sierra
    [Header("Movimiento"), SerializeField, Tooltip("Duracion del movimiento en una direccion")]
    float tiempo = 1;
    [SerializeField, Tooltip("Posicion donde se va a mover la sierra")]
    Vector2 posicionFinal;
    Vector2 vectorDireccion;   //  La direccion donde se mueve la sierra
    bool direccion; //  Valor que nos dice a que direccion debe moverse el objeto
    Coroutine coroutine;
    Animator anim;
    public GameObject cadena;
    public GameObject sawPrefab;
    public int numeroDeCadenas;

    private void Start()
    {
        //  Movimiento
        rb = GetComponent<Rigidbody2D>();
        posicionInicial = transform.position;
        vectorDireccion = posicionFinal - posicionInicial;
        anim = gameObject.GetComponent<Animator>();
        //  Activar comportamiento
        GeneraCadenas();
        Activar();
    }

    private void FixedUpdate() => rb.linearVelocity = direccion ? -vectorDireccion / tiempo : vectorDireccion / tiempo;

    IEnumerator CambiarDireccion()
    {
        while (true)
        {
            yield return new WaitForSeconds(tiempo);
            direccion = !direccion;
        }
    }

    private void Activar()
    {
        anim.SetBool("Off", false);
        coroutine ??= StartCoroutine(nameof(CambiarDireccion));
    }

    private void Desactivar()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
            anim.SetBool("Off", true);
        }
    }

    private void GeneraCadenas()
    {
        if (cadena == null || numeroDeCadenas <= 0) return;

        for (int i = 0; i<numeroDeCadenas; i++)
        {
            float t = (float)i / (numeroDeCadenas-1);
            Vector2 posicionCadena = Vector2.Lerp(posicionInicial, posicionFinal, t);
            GameObject nuevaCadena = Instantiate(cadena, posicionCadena, Quaternion.identity);
            nuevaCadena.transform.SetParent(sawPrefab.transform);
            //nuevaCadena.transform.position = posicionCadena;
        }
    }
}
