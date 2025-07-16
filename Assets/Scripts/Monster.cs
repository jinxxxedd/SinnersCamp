using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public playermovement player;
    [SerializeField] public float speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -2, 0);
    }

    // Update is called once per frame
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
}
