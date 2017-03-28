using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

    public float speed;
    public float jumpheight;
    bool isGrounded;
    float dashperiod = 1f;
    bool isDashing = false;
    float dashtime;
    Vector3 jump;
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }
	
	// Update is called once per frame
	void Update () {
        bool isDashing = false;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(speed, 0.0f);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-speed, 0.0f);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            rb.AddForce(jump * jumpheight, ForceMode.Impulse);
        }


        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            isDashing = true;
        }
        if (Input.GetKey(KeyCode.RightArrow) && isDashing)
        {
            transform.position += new Vector3(1f, 0f);
        }
        if (isDashing)
        {
            dashtime += Time.deltaTime;
            if (dashtime > dashperiod) {
                isDashing = false;
            }
        }



    }
    void OnCollisionEnter(Collision collider)
    {
        isGrounded = true;
    }
}
