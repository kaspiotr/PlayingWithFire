﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public int bombs;
    public int firePower;
    public int speed;


    GameController gameController;
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        gameController.level[(int)transform.position.x, (int)transform.position.y] = gameObject;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // See if we have collided with the player
        if (collision.gameObject.tag == "Player")
        {
            // Gather references to components
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            BombSpawner BombSpawner = collision.gameObject.GetComponent<BombSpawner>();

            // Adjust the values
            playerController.speed += speed;
            BombSpawner.numberOfBombs += bombs;
            BombSpawner.firePower += firePower;

            // Remove the powerup
            Destroy(gameObject);
        }
    }
}
