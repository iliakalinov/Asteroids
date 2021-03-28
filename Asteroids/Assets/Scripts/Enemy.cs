using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject explosion;
    private Action<bool> scoreGame;

    public void StartMove(Vector2 direction, float speed)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(direction * speed, ForceMode2D.Impulse);
    }

    public void SetCallback(Action<bool> action)
    {
        scoreGame = action;
    }

    /// <summary>
    /// описание удара
    /// </summary>
    /// <param name="collision"> объект удара</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fire")
        {
            Destroy(collision.gameObject);

            Instantiate(explosion, this.transform.position, Quaternion.identity);
            scoreGame?.Invoke(true);
            Destroy(this.gameObject);
        }
        else
        {
            if (collision.gameObject.tag == "ship")
            {
                scoreGame?.Invoke(false);
                EndGame();
            }
        }

    }
    private void EndGame()
    {
        Instantiate(explosion, this.transform.position, Quaternion.identity);

        var controllerGame = GameObject.FindGameObjectWithTag("ControllerGame");
        controllerGame.GetComponent<ControllerGame>().EndGame();
    }


}
