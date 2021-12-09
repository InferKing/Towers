using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderController : MonoBehaviour
{
    [SerializeField] private GameObject leftBorder;
    [SerializeField] private GameObject rightBorder;
    [SerializeField] private Generator gen;
    public float speedX;
    private bool isRight = true;
    private void Start()
    {
        StartCoroutine(StartMove());
    }
    private IEnumerator StartMove()
    {
        Debug.Log("StartMove");
        while (true)
        {
            if (isRight && rightBorder.transform.position.x > transform.position.x)
            {
                transform.Translate(Time.deltaTime * speedX, 0, 0);
            }
            else if (isRight && rightBorder.transform.position.x <= transform.position.x)
            {
                isRight = false;
                yield return new WaitForSeconds(1f);
            }
            else if (!isRight && leftBorder.transform.position.x < transform.position.x)
            {
                transform.Translate(-Time.deltaTime * speedX, 0, 0);
            }
            else if (!isRight && leftBorder.transform.position.x >= transform.position.x)
            {
                isRight = true;
                yield return StartCoroutine(gen.GenerateTower());
            }
            yield return null;
        }
    }
}
