using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    public float speed;
    private int count;
    public Text CountText;
    public Text WinText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        CountText.text = "Count: " + count.ToString();
        WinText.text = "";
    }

    // Update is called once per frame
    void FixedUpdate () {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        rb.AddForce(movement * speed);


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            CountText.text = "Count: " + count.ToString();

            if (count >= 5)
        {
                WinText.text = "You Win!";
            }
        }
    }


}
