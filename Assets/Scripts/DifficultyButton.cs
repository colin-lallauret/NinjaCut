using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DifficultyButton : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject titleScreen;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Quand le bouton est cliqué, on démarre le jeu
    public void OnButtonClick(int level)
    {
        // Lance le jeu avec le niveau choisi
        gameManager.StartGame(level);

        // Désactive le titre
        titleScreen.gameObject.SetActive(false);
    }
}
