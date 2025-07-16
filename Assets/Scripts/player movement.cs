using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playermovement : MonoBehaviour
{
    [SerializeField] float basespeed = 5.0f;
    float speed;
    [SerializeField] float speedMultiplier = 2.0f;

    

    // Start is called before the first frame update
    void Start()
    {
        
       
    }

    public float GetX()
    {
        Vector3 pos = transform.position;
        return pos.x;
    }

    public float GetY()
    {
        Vector3 pos = transform.position;
        return pos.y;
    }

    // Update is called once per frame
    void Update()
    {


        


        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = basespeed * speedMultiplier;
        }
        else 
        {
            speed = basespeed;
        }


    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("door"))
        {
            Debug.Log("next scene");
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);

        }
        
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Debug.Log("Scene is " + SceneManager.GetActiveScene().buildIndex);
            transform.position = new Vector3(-5, 1, 0);
        }
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Debug.Log("Scene is " + SceneManager.GetActiveScene().buildIndex);
            transform.position = new Vector3(0, 3, 0);
            
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            Debug.Log("Scene is " + SceneManager.GetActiveScene().buildIndex);
            transform.position = new Vector3(-7, -0.5f, 0);
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            Debug.Log("Scene is " + SceneManager.GetActiveScene().buildIndex);
            transform.position = new Vector3(-4.5f, 0.5f, 0);
        }



    }
}
