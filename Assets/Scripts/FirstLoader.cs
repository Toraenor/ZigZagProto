using System.Collections.Generic;
using UnityEngine;

public class FirstLoader : MonoBehaviour
{
    [SerializeField] List<GameObject> BlockList;
    void Start()
    {
        GameObject.Instantiate(BlockList[UnityEngine.Random.Range(0, BlockList.Count)], transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
