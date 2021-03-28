using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControllerGame : MonoBehaviour
{
    [SerializeField] public GameObject uiGameStart;
    [SerializeField] public GameObject spawnerEnemy;

    [SerializeField] public GameObject objectTextEndGame;
    [SerializeField] public TextMeshProUGUI textScoreGame;

    private int score = 0;
    private const string stringScore = "  score :";
    private const string textEnd = "game over, you got blown";

    [SerializeField] public TextMeshProUGUI textEndGame;

    private void Start()
    {
        spawnerEnemy.GetComponent<EnemySpawner>().SetCallback(NewScore);
    }

    private void NewScore(bool newScore)
    {
        if (newScore)
        {
            score++;
            writeNewScore(score);
        }
    }

    public void ClickStartGame()
    {
        score = 0;
        writeNewScore(score);

        ChangeVisible(uiGameStart, false);
        ChangeVisible(spawnerEnemy, true);
    }

    public void EndGame()
    {
        writeNewScore(score--);

        ChangeVisible(uiGameStart, true);
        ChangeVisible(spawnerEnemy, false);
        ChangeVisible(objectTextEndGame, true);
        textEndGame.text = textEnd + stringScore + score;
        score = 0;
    }
    private void ChangeVisible(GameObject gameObject, bool status)
    {
        gameObject.SetActive(status);
    }

    private void writeNewScore(int newScore)
    {
        textScoreGame.text = stringScore + newScore.ToString();
    }
}
