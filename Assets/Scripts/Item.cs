using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{   
    public Text currentText;
    void Awake()
    {
    }
    void Update()
    {
        transform.Rotate(30 * Time.deltaTime, 30 * Time.deltaTime, 30 * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Player player = other.GetComponent<Player>();
            player.itemCount++;
            currentText.text = player.itemCount.ToString();
            gameObject.SetActive(false);
        }
    }
}
