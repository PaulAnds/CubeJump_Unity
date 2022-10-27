using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    #region "Variables"
    public float walkSpeed;
    public GameObject panelDied;
    public GameObject pauseScreen;
    public bool powerJump = false;
    public static int ability;
    //public Animator anim;

    //private variables
    private Vector3 oldrigid;
    private bool JumpRight = true;
    private bool JumpLeft = false;
    private bool touchingWall = false;//to se if it touches enemies while touching the wall
    private Rigidbody rb;
    private DestroyPlayer destroy;
    private BoxCollider bc;
    #endregion

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
            touchingWall = false;
        }
        if(Input.GetMouseButtonDown(0) && JumpRight && !powerJump)
        {
            //Debug.Log("Jumping Right");
            //anim.SetBool("Right", false);
            //anim.SetBool("Stay", false);
            rb.velocity = new Vector3(walkSpeed,10,0);
            touchingWall = false;
        }
        if(ability >= 3 && touchingWall)
        {
            StartCoroutine(waitSecondsCo());
        }
        //anim.SetBool("Stay", true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Left")
        {
            //Debug.Log("Touching Left");
            JumpRight = true;
            JumpLeft = false;
            touchingWall = true;
        }
        if (collision.gameObject.tag == "Right")
        {
            //Debug.Log("Touching Right");
            JumpLeft = true;
            JumpRight = false;
            touchingWall = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            //cuando choca con el enemigo
            if (touchingWall && destroy)
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

    IEnumerator waitSecondsCo()
    {
        //antes de 3 segundos
        ability = 0;
        oldrigid = rb.velocity;
        Debug.Log(oldrigid);
        bc.enabled = false;
        //llama nomas una vexz lo del vector y despues de 3 ya se regresa a la normalidad poreso hace el brinco raro
        rb.velocity = new Vector3(0, 20, 0);
        powerJump = true;
         
        yield return new WaitForSeconds(3f);

        bc.enabled = true;
        rb.velocity = new Vector3(0, 10, 0);
        powerJump = false;
        //despues de 3 segundos
    }

}
