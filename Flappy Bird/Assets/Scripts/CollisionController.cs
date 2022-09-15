using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag.Equals("Bound"))
        {
            switch (gameObject.name)
            {
                case "Up":
                    collision.gameObject.GetComponent<Bird>().Jump(new Vector2(0, -1));
                    break;
                case "Down":
                    collision.gameObject.GetComponent<Bird>().Jump(new Vector2(0, 1));
                    break;
                case "Left":
                    collision.gameObject.GetComponent<Bird>().currX = 2;
                    collision.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                    break;
                case "Right":
                    collision.gameObject.GetComponent<Bird>().currX = -2;
                    collision.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                    break;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag.Equals("Obstacle"))
        {
            Debug.Log("Hit");
            GameManager.instance.ChangeState(GameState.Death);
        }
        if (gameObject.tag.Equals("Star"))
        {
            gameObject.SetActive(false);
            Spawner.instance.RandomSpawn();
            UIManager.instance.AddScore();
        }
    }
}
