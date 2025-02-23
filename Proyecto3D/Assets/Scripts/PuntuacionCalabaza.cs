using System.Collections;
using UnityEngine;

public class PuntuacionCalabaza : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(puntua(other.gameObject));
        }
    }

    IEnumerator puntua(GameObject player)
    {
        player.GetComponent<Puntuacion>().incrementaPuntuacion();
        yield return new WaitForSeconds(0.0f);
        Destroy(this.gameObject);
    }

}
