using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] private GameObject gObj;
    [SerializeField] private LoseController contr;
    [SerializeField] private Vector2 pos;
    [SerializeField] private float seconds;
    private GameObject gameObj;
    private BoxCollider2D boxCollider;
    private int posX = 0, posY = 0;
    private bool isEnd = false;
    

    private void Start()
    {
        boxCollider = gObj.GetComponent<BoxCollider2D>();
        gObj.GetComponent<SpriteRenderer>().color = Color.grey;
        StartCoroutine(GenerateTower());
    }

    private IEnumerator GenerateTower()
    {
        while (!isEnd)
        {
            gameObj = Instantiate(gObj);
            gameObj.transform.SetParent(transform,false);
            gameObj.transform.position = new Vector2(transform.position.x + 
                + posX * boxCollider.size.x * gObj.transform.localScale.x, 
                transform.position.y + posY * boxCollider.size.y * gObj.transform.localScale.y);
            posX++;
            if (posX >= pos.x)
            {
                posX = 0;
                posY++;
            }
            if (posY >= pos.y)
            {
                SetEnd();
            }
            yield return new WaitForSeconds(seconds);
        }
        yield return new WaitForSeconds(2);
        contr.TurnOn();
    }


    public Vector2 GetMaxPos()
    {
        return pos;
    }

    public void SetEnd()
    {
        isEnd = true;
    }
}
