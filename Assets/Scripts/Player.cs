using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Vector3 currentVec;
    private readonly float speed = 10f;
    public bool go = false;

    void Start()
    {
        currentVec = transform.forward;
        StartCoroutine(ScoreRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (!go)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            if(currentVec == transform.forward)
            {
                currentVec = transform.right;
            }
            else
            {
                currentVec = transform.forward;
            }
        }

        Vector3 pos = transform.position;
        pos += speed * Time.deltaTime * currentVec;
        transform.position = pos;

        if(transform.position.y <= -10f)
        {
            //game over logic
            GameManager.Instance.GameOver();
        }
    }

    private IEnumerator ScoreRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.Score += 1;
        StartCoroutine(ScoreRoutine());
    }
}
