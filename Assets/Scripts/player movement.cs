using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playermovement : MonoBehaviour
{
    [SerializeField] float basespeed = 5.0f;
    float speed;
    [SerializeField] float speedMultiplier = 2.0f;



    public Monster monster;

    public bool hasKey = false;
    public REAL_GATE realGate;

   
    // Start is called before the first frame update

    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
    }


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
    public void FixedUpdate()
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



            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                Debug.Log("Scene is " + SceneManager.GetActiveScene().buildIndex);
                transform.position = new Vector3(-5, 1, 0);
            }
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                Debug.Log("Scene is " + SceneManager.GetActiveScene().buildIndex);
                transform.position = new Vector3(0, 3, 0);

            }
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                Debug.Log("Scene is " + SceneManager.GetActiveScene().buildIndex);
                transform.position = new Vector3(-7, -0.5f, 0);
            }
            if (SceneManager.GetActiveScene().buildIndex == 4)
            {
                Debug.Log("Scene is " + SceneManager.GetActiveScene().buildIndex);
                transform.position = new Vector3(21.5f, 7f, 0);
            }



        }




        if (collider.gameObject.CompareTag("boat"))
        {
            Debug.Log("win");
            SceneManager.LoadScene(6);

        }

        if (collider.gameObject.CompareTag("monster"))
        {
            Debug.Log("die");
            SceneManager.LoadScene(5);

        }

        if (collider.gameObject.CompareTag("corpse"))
        {
            Debug.Log("dead");
            StartCoroutine(wait(1, collider.gameObject)); // Wait for 2 seconds before disabling the Counciler GameObject
            
            
        }

        if (collider.gameObject.CompareTag("deadmate"))
        {
            Debug.Log("dead");
            StartCoroutine(wait(1, collider.gameObject)); // Wait for 2 seconds before disabling the Counciler GameObject


        }

        if (collider.gameObject.CompareTag("Counciler"))
        {
            Debug.Log("dead2");
            monster.ActivateMonster();
            StartCoroutine(wait(2, collider.gameObject)); // Wait for 2 seconds before disabling the Counciler GameObject

        }

        if (collider.gameObject.CompareTag("key"))
        {
            Debug.Log("get key");
            hasKey = true;
            Destroy(collider.gameObject); // Destroy the key GameObject

        }
        
        if (collider.gameObject.CompareTag("gate") && hasKey)
        {
            Debug.Log("open gate");
            Destroy(collider.gameObject); // Destroy the key GameObject
            realGate.openGate(); // Call the openGate method on the REAL_GATE script

        }
        else if (collider.gameObject.CompareTag("gate") && !hasKey)
        {
            Debug.Log("need key to open gate");
            
        }

    }

    IEnumerator wait(int time, GameObject obj)
    {
        yield return new WaitForSeconds(time);
        obj.SetActive(false); // Disable the Counciler GameObject
    }



    /*
    void OnTriggerStay2D(Collider2D collider)
    {
        Debug.Log("Player is in trigger with: " + collider.gameObject.name);

        

        
    }
    */
}
