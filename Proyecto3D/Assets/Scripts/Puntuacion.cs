using UnityEngine;

public class Puntuacion : MonoBehaviour
{

    private int puntuacion = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Calabaza")
        {
            Destroy(other.gameObject);
            this.puntuacion += 1;
            Debug.Log(this.puntuacion);
        }
    }


}
