using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scoreToAdd = 5;
    [SerializeField] int hits = 10;

    Score scoreBoard;

    void Start()
    {
        scoreBoard = FindObjectOfType<Score>();
        AddNonTrigerCollader();  
    }

    // Update is called once per frame
   public void AddNonTrigerCollader()
    {
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }
    public void OnParticleCollision(GameObject other)
    {
        scoreBoard.ScoreHit(scoreToAdd);
        hits--;
        if (hits <= 0)
        {
            Death();

        }

    }

    void Death()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity); //add prefab explosion
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
