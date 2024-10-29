using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] List<GameObject> nextToLoadList;
    [SerializeField] GameObject lastminiBlockInBlock;
    bool alreadyCollide = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !alreadyCollide)
        {
            Vector3 pos = new Vector3(lastminiBlockInBlock.transform.position.x, transform.position.y, lastminiBlockInBlock.transform.position.z);
            pos += lastminiBlockInBlock.transform.forward * lastminiBlockInBlock.transform.lossyScale.z;
            GameObject.Instantiate(nextToLoadList[UnityEngine.Random.Range(0, nextToLoadList.Count)], pos, Quaternion.identity);
            alreadyCollide = true;
        }
    }
}
