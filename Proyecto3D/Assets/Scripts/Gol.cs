
using UnityEngine;

public class Gol : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Gol")
        {
            Debug.Log("¡Gol!");
        }
    }
}
