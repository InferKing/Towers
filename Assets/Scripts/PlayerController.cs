using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private float power;
    [SerializeField] private float mass;
    private GameObject gameObj;
    private Rigidbody2D rb2D;
    private Vector2 mouseVect, sumVect = Vector2.zero;
    private bool imp = false, isStarted = false;

    private void Start()
    {
        ball.GetComponent<Rigidbody2D>().mass = mass;
        
    }
    private void Update()
    {
        if (isStarted)
        {
            if (Input.GetMouseButton(0))
            {
                mouseVect = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
                sumVect += mouseVect;
                // Debug.Log($"{mouseVect.x} and {mouseVect.y}");
            }
            if (Input.GetMouseButtonUp(0))
            {
                imp = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (imp)
        {
            gameObj = Instantiate(ball);
            Destroy(gameObj, 3);
            gameObj.transform.localScale = new Vector2(mass, mass);
            gameObj.transform.position = transform.position;
            rb2D = gameObj.GetComponent<Rigidbody2D>();
            rb2D.AddForce(-sumVect * rb2D.mass * power,ForceMode2D.Impulse);
            sumVect = Vector2.zero;
            imp = false;
        }
    }

    public void StartGame()
    {
        isStarted = true;
    }

    

}
