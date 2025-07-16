using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Monster : MonoBehaviour
{
    public playermovement player;
    [SerializeField] public float speed = 2.0f;

    void Start()
    {
        transform.position = new Vector3(0, -2, 0);

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            Debug.Log("Scene is " + SceneManager.GetActiveScene().buildIndex);
            transform.position = new Vector3(0, -3, 0);
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            Debug.Log("Scene is " + SceneManager.GetActiveScene().buildIndex);
            transform.position = new Vector3(-9, -0.5f, 0);
        }
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            Debug.Log("Scene is " + SceneManager.GetActiveScene().buildIndex);
            transform.position = new Vector3(-21.5f, 5f, 0);
        }
    }

    void Update()
    {
        Vector3 Monpos = transform.position;
        float Mx = Monpos.x;
        float My = Monpos.y;

        if (player.GetX() > Mx)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (player.GetX() < Mx)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (player.GetY() > My)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
        if (player.GetY() < My)
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player touched by monster!");
            GameManager.instance.LoseLife();

            // Optional: move monster away for 1 second delay (or handle respawn)
            transform.position = new Vector3(-100, -100, 0);
        }
    }
}

