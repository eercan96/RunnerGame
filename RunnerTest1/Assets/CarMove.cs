using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarMove : MonoBehaviour
{
    bool gameFinish = false;
    public int puan = 0;

    // Start is called before the first frame update
    void Start()
    {
        puan = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameFinish==false)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.left * 2.5f, ForceMode.Force);
        }
        else if (gameFinish==true)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        

        if (Input.GetKey("d"))
        {
            GetComponent<Rigidbody>().AddForce(0,0,10,ForceMode.Force);
        }
        if (Input.GetKey("a"))
        {
            GetComponent<Rigidbody>().AddForce(0, 0, -10, ForceMode.Force);
        }
        if (GetComponent<Rigidbody>().position.x <= -415 || GetComponent<Rigidbody>().position.y <= -2)
        {
            gameFinish = true;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            Invoke("Restart", 2f);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag== "Barrier")
        {
            Invoke("Restart", 4f);
            gameFinish = true;
        }
        if (collision.collider.tag=="Coin")
        {
            puan ++;
            Destroy(collision.gameObject);
        }
    }
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameFinish = false;
    }
}
