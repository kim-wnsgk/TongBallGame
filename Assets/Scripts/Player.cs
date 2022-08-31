using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    AudioSource audio;
    public float jumpPower = 10;
    bool jump;
    public int itemCount;

    public GameManagerLogic manager;

    Rigidbody rigidbody;
    void Awake()
    {
        audio = GetComponent<AudioSource>();
        jump = false;
        rigidbody = GetComponent<Rigidbody>(); 
    }
    void Update()
    {
        if (!jump && Input.GetButtonDown("Jump"))
        {   
            jump = true;
            rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
        
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("Stage" + manager.stage);
        }
    }
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        rigidbody.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            jump = false;
        }
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            audio.Play();
        }
        else if(other.tag == "Finish")
        {
            if (itemCount == manager.totalItemCount)
            {
                manager.stage++;
            }
            SceneManager.LoadScene("Stage" + manager.stage);
        }
    }
}
