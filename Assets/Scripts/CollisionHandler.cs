using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [Tooltip("В секундах")][SerializeField] float LoadLevelDelay;
    [Tooltip("Префаб эффекта взрыва")] [SerializeField] GameObject explosionFX;

    private void OnTriggerEnter(Collider other)
    {
        print("Hit Triger");
        StartGameOver();
        explosionFX.SetActive(true);
        Invoke("RestartLevel", 1);
    }

    void StartGameOver()
    {
        SendMessage("OnPlayerDeath");
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }

     
}
