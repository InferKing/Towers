using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextController : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private Text startText;
    [SerializeField] private LoseController loseController;
    [SerializeField] private PlayerController playerController;
    private BoxCollider2D box;
    private int count = 3;

    private void Start()
    {
        box = loseController.GetComponent<BoxCollider2D>();
        StartCoroutine(StartText());
    }
    private void Update()
    {
        StartCoroutine(ShowFinishText());
        
    }
    private IEnumerator StartText()
    {
        while (count >= 0)
        {
            startText.text = $"You will start in {count}!";
            count--;
            yield return new WaitForSeconds(0.9f);
        }
        startText.text = "Let's play!";
        playerController.StartGame();
        yield return new WaitForSeconds(1f);
        startText.text = null;

    }

    private IEnumerator ShowFinishText()
    {
        if (box.enabled)
        {
            text.text = loseController.GetWin() ? "You win!" : "You lose!";
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene("Restart");
        }
    }

}
