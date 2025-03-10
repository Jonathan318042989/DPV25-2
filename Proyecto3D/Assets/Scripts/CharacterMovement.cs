using TMPro;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float horizontal;
    public float vertical;
    public float velocidad, velocidadOriginal;
    public float gravedad;
    public float salto;
    public Vector3 direccion;
    public CharacterController cc;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.cc = this.gameObject.GetComponent<CharacterController>();
        this.velocidadOriginal = velocidad;
        this.rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        direccion = Vector3.zero;
        direccion.y -= gravedad * Time.deltaTime;
        direccion.x = Input.GetAxisRaw("Horizontal");
        direccion.z = Input.GetAxisRaw("Vertical");
        
        this.transform.position += direccion * velocidad* Time.deltaTime;
        //cc.Move(direccion*Time.deltaTime*velocidad);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space");
            direccion.y += salto;
            rb.AddForce(direccion * salto, ForceMode.Impulse);
        }
    }

    public void setVelocity(float velocidad)
    {
        this.velocidad = velocidad;
    }

    public void resetVelocity()
    {
        this.velocidad = velocidadOriginal;
    }
}
