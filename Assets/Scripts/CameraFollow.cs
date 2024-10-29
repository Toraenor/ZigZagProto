using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    GameObject player;
    private float yBaseOffset;
    private float speed = 10f;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        yBaseOffset = transform.position.y;
    }

    void Update()
    {
        Vector3 pos = transform.position;
        //pos.y += speed * Time.deltaTime;
        transform.position = pos;
    }
}
