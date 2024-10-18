using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float launchForce = 12f;
    private Vector2 launchOriginRange = new Vector2(-5f, 5f);
    private GameManager gameManager;
    public bool isBad;
    public ParticleSystem explosionParticle;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        MoveUp();
    }

    // Permet de jetter les objets en l'air
    void MoveUp()
    {
        float randomSpawnX = Random.Range(launchOriginRange.x, launchOriginRange.y);
        transform.position = new Vector3(randomSpawnX, transform.position.y, transform.position.z);

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 launchDirection = new Vector3(Random.Range(-0.5f, 0.5f), 1f, 0f).normalized;
            rb.AddForce(launchDirection * launchForce, ForceMode.Impulse);
            rb.AddTorque(new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0) * Random.Range(1, 5), ForceMode.Impulse);
        }
    }

    // Lorsque l'objet est cliqué, sois on ajoute des points, sois on en retire en fonction de l'objet
    // Et une particule d'explosion est créée, puis l'objet est détruit
    void OnMouseDown()
    {
        if (isBad)
        {
            gameManager.DecrementScore();

        }
        else
        {
            gameManager.IncrementScore();
        }

        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        Destroy(gameObject);
    }

    // Lorsque les objects touchent le "Sensor" ils sont détruits
    // Et si c'est un bon object, le jeu passe en game over
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sensor"))
        {
            Destroy(gameObject);

            if (!isBad)
            {
                gameManager.GameOver();
            }
        }
    }
}
