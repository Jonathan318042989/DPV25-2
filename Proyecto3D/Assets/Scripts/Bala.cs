using UnityEngine;

public class Bala : MonoBehaviour
{

    public float velocidad;
    public Rigidbody rb;
    public float tiempoVida = 2.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.AddForce(transform.forward*velocidad);
        Destroy(this.gameObject, tiempoVida);
    }
}
