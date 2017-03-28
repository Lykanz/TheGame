using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

    public float speed;
    public float jumpheight;
    public GameObject player_attack;
    public bool attacking = false;
    bool isGrounded;
    float dashperiodRight = 0.2f;
    int dashCounterRight = 0;
    float dashperiodLeft = 0.2f;
    int dashCounterLeft = 0;
    Vector3 jump;
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }
	
	// Update is called once per frame
	void Update () {
        
        // Movement
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(speed, 0.0f);
            transform.localScale = new Vector3(1f, 1f, 1f);

        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-speed, 0.0f);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            rb.AddForce(jump * jumpheight, ForceMode.Impulse);
        }


        //Dashing
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            if (dashperiodRight > 0 && dashCounterRight == 1)
            {
                rb.AddForce(Vector3.right * 10, ForceMode.VelocityChange);
                Invoke("StopDash",0.1f);
            }
            else {
                dashperiodRight = 0.2f;
                dashCounterRight = 1;
            }
        }

        if (dashperiodRight > 0) {
            dashperiodRight -= 1 * Time.deltaTime;
        }
        else {
            dashCounterRight = 0;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (dashperiodLeft > 0 && dashCounterLeft == 1)
            {
                rb.AddForce(Vector3.left * 10, ForceMode.VelocityChange);
                Invoke("StopDash", 0.1f);
            }
            else
            {
                dashperiodLeft = 0.2f;
                dashCounterLeft = 1;
            }
        }

        if (dashperiodLeft > 0)
        {
            dashperiodLeft -= 1 * Time.deltaTime;
        }
        else
        {
            dashCounterLeft = 0;
        }




        //Attack key
        if (Input.GetKeyDown("c") && attacking == false ){
            attacking = true;
            player_attack.SetActive(true);
            Invoke("StopAttack", 0.2f);
        }

    }

    //Stop attack
    public void StopAttack() {
        attacking = false;
        player_attack.SetActive(false);
    }

    //Stop dash
    public void StopDash()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    //Checking if on the ground for jump
    void OnCollisionEnter(Collision collider)
    {
        isGrounded = true;
    }
}
