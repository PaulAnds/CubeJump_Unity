using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed;
    public float forceMult = 200f;
    public GameObject panelDied;
    public GameObject pauseScreen;
    public static int ability;
    //public Animator anim;

    //private variables
    public bool JumpRight = true;
    public bool JumpLeft = false;
    public bool touchingWall = false;//to se if it touches enemies while touching the wall
    public bool powerJump = false;
    private Rigidbody rb;
    DestroyPlayer destroy;
    private BoxCollider bc;

    // Use this for initialization
    void Start()
    {
        bc = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        destroy = FindObjectOfType<DestroyPlayer>();
        ability = 0;
       // anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && JumpLeft && !powerJump)
        {
            //Debug.Log("Jumping Left");
            //anim.SetBool("Right", true);
            //anim.SetBool("Stay", false);
            rb.velocity = new Vector3(-walkSpeed, 10, 0);
            JumpLeft = false;
            touchingWall = false;
        }
        if(Input.GetMouseButtonDown(0) && JumpRight && !powerJump)
        {
            //Debug.Log("Jumping Right");
            //anim.SetBool("Right", false);
            //anim.SetBool("Stay", false);
            rb.velocity = new Vector3(walkSpeed,10,0);
            JumpRight = false;
            touchingWall = false;
        }
        if(ability >= 3 && touchingWall)
        {
            bc.enabled = false;
            rb.velocity = new Vector3(0, 20, 0);
            powerJump = true;
            Invoke("waitSeconds", 2f);
        }
        //anim.SetBool("Stay", true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Left")
        {
            //Debug.Log("Touching Left");
            JumpRight = true;
            touchingWall = true;
        }
        if (collision.gameObject.tag == "Right")
        {
            //Debug.Log("Touching Right");
            JumpLeft = true;
            touchingWall = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            //cuando choca con el enemigo
            if (touchingWall)
            {
                //muere el jugador
                panelDied.SetActive(true);
                ability = 0;
                Destroy(gameObject);
                destroy.callReset();
            }
            Destroy(other.gameObject);
        }
        if (other.tag == "Obstacle")
        {
            //muere el jugador
            panelDied.SetActive(true);
            ability = 0;
            Destroy(gameObject);
        }
        if (other.tag == "Lava")
        {
            //muere el jugador
            panelDied.SetActive(true);
            ability = 0;
            Destroy(gameObject);
        }
    }
    void waitSeconds()
    {
        bc.enabled = true;
        powerJump = false;
        touchingWall = true;
        ability = 0;
        rb.velocity = new Vector3(walkSpeed, 0, 0);
    }
}
