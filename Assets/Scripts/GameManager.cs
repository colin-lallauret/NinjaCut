using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> gameObjects = new List<GameObject>();
    public TextMeshProUGUI scoreText;
    private int score;
    public TextMeshProUGUI gameOverText;
    private bool isGameActive;
    public GameObject titleScreen;
    public TextMeshProUGUI startText;


    private bool runGame;

    void Start()
    {
        isGameActive = false;
    }

    // Faire spawn les objets aléatoirement (depuis la liste)
    // Et gestion de la difficulté
    IEnumerator SpawnTarget(int level)
    {
        while (isGameActive)
        {
            if (isGameActive && gameObjects.Count > 0)
            {
                GameObject prefab = gameObjects[Random.Range(0, gameObjects.Count)];
                Instantiate(prefab, Vector3.zero, Quaternion.identity);
                yield return new WaitForSeconds(Random.Range(1f / level, 3f / level));
            }
            else
            {
                yield return null;
            }
        }
    }

    void Update()
    {

    }

    // Met à jour le score
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    // Ajoute 5 points au score
    public void IncrementScore()
    {
        score = score + 5;
        UpdateScore();
    }

    // Enlève 5 points au score
    public void DecrementScore()
    {
        score = score - 5;
        UpdateScore();
    }

    // Affiche le Game over
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        titleScreen.gameObject.SetActive(true);
        startText.gameObject.SetActive(false);
        isGameActive = false;
    }

    public void StartGame(int level)
    {
        score = 0;
        UpdateScore();
        isGameActive = true;
        gameOverText.gameObject.SetActive(false);
        StartCoroutine(SpawnTarget(level));
    }
}
