using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(superVel(other.gameObject));
        }
    }

    IEnumerator superVel (GameObject player)
    {
        this.gameObject.GetComponent<SphereCollider>().enabled = false;
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        player.GetComponent<CharacterMovement>().setVelocity(10.0f);
        yield return new WaitForSeconds(3.0f);
        player.GetComponent<CharacterMovement>().resetVelocity();
        Destroy(this.gameObject);
    }
}
