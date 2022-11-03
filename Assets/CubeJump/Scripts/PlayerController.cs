using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    #region "Variables"
    public float walkSpeed;
    public GameObject panelDied;
    public GameObject shielded;
    public GameObject pauseScreen;
    public static int pill;
    public static int ability;
    public bool powerJump = false;
    public bool SpeedJump = false;
    public bool shield = false;
    //public Animator anim;

    //private variables
    private bool JumpRight = true;
    private bool JumpLeft = false;
    private bool touchingWall = false;//to se if it touches enemies while touching the wall
    private Rigidbody rb;
    private ScoreManager scoremanager;
    private DestroyPlayer destroy;
    #endregion

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        shielded.SetActive(false);
        scoremanager = FindObjectOfType<ScoreManager>();
        destroy = FindObjectOfType<DestroyPlayer>();
        ability = 0;
        pill = 0;
        // anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SpeedJump)
        {
            rb.velocity = new Vector3(0, 20, 0);
        }
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
        if(pill >= 3)
        {
            //el jugador conigue un escudo
            shielded.SetActive(true);
            shield = true;
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
                if (shield)
                {
                    Debug.Log("You lost shield");
                    //el jugador pierde el escudo
                    shielded.SetActive(false);
                    shield = false;
                    pill = 0;
                }
                else
                {
                    //muere el jugador
                    panelDied.SetActive(true);
                    scoremanager.keepadding = false;
                    ability = 0;
                    pill = 0;
                    Destroy(gameObject);
                    destroy.callReset();
                }
            }
            Destroy(other.gameObject);
        }
        if (other.tag == "Obstacle")
        {
            if (shield)
            {
                //el jugador pierde el escudo
                Debug.Log("You lost shield");
                shielded.SetActive(false);
                pill = 0;
                shield = false;
            }
            else
            {
                //muere el jugador
                panelDied.SetActive(true);
                scoremanager.keepadding = false;
                ability = 0;
                pill = 0;
                Destroy(gameObject);
            }
        }
        if (other.tag == "Lava")
        {
            //muere el jugador
            panelDied.SetActive(true);
            scoremanager.keepadding = false;
            pill = 0;
            ability = 0;
            Destroy(gameObject);
        }
        if(other.tag == "Pill")
        {
            pill += 1;
            ability = 0;
        }
    }

    IEnumerator waitSecondsCo()
    {
        //antes de 3 segundos
        ability = 0;
        //bc.enabled = false;
        //llama nomas una vexz lo del vector y despues de 3 ya se regresa a la normalidad poreso hace el brinco raro
        //rb.velocity = new Vector3(0, 20, 0);
        powerJump = true;
        SpeedJump = true;
        yield return new WaitForSeconds(2f);
        
        SpeedJump = false;
        yield return new WaitForSeconds(1f);

        //bc.enabled = true;
        powerJump = false;
        //despues de 3 segundos
    }   

}
