using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackControll : MonoBehaviour {
    float speed =30;
    Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = this.gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Marret")
        {
            
            rb.AddForce(collision.gameObject.GetComponent<MarretController>().acceleration *collision.gameObject.GetComponent<MarretController>().m_speed*speed);
            Debug.Log("Hit");
        }
    }
}
