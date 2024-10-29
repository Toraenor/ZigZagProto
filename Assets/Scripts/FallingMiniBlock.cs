using System.Collections;
using UnityEngine;

public class FallingMiniBlock : MonoBehaviour
{
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.isKinematic = false;
            Destroy(gameObject, 5f);
        }
    }
}
