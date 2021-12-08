using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseController : MonoBehaviour
{
    [SerializeField] private Generator gen;
    [SerializeField] private GameObject ball;
    private BoxCollider2D box;
    private Vector2 vect;
    private bool isWin = true;
    private void Awake()
    {
        vect = gen.GetMaxPos();
        transform.position = new Vector3(-5,gen.transform.position.y + 
            + vect.y * ball.GetComponent<BoxCollider2D>().size.y * ball.transform.localScale.y, -3);
        box = gameObject.AddComponent<BoxCollider2D>();
        box.isTrigger = true;
        box.enabled = false;
        transform.localScale = new Vector2(20, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Block")
        {
            isWin = false;
        }
    }

    public void TurnOn()
    {
        box.enabled = true;
    }

    public bool GetWin()
    {
        return isWin;
    }
}
