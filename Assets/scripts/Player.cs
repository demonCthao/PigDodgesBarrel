using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public float moveSpeed;

    private Rigidbody2D rd;
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (touchPos.x <0)
            {
                rd.AddForce(Vector2.left * moveSpeed);
            }
            else
            {
                rd.AddForce(Vector2.right* moveSpeed);
            }
        }
        else
        {
            rd.velocity = Vector2.zero;
        }   
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "block")
        {
            SceneManager.LoadScene(0);
        }
    }
}
