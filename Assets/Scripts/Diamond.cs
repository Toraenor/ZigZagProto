using UnityEngine;

public class Diamond : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.Score += 2;
            FloatingTextGenerator.CreateText(transform.position + Vector3.up, "+2", new Color(199/255f, 153 / 255f, 233 / 255f, 1));
            Destroy(gameObject);
        }
    }
}
