using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CageCon : MonoBehaviour {

    public Rigidbody2D rb;
    public GameObject DeathScreen;

    //how high you jump
    public float jumpForce, boost;
    public int Score = 0;

    public Text scoreUI;

    private float timer = 0, flapTimer = 0;
    
    //used to start game
    bool bIsStarted = false, isAlive;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();

        

        isAlive = true;

	}


    public bool shouldBoost;

	// Update is called once per frame
	void Update () {
         
        flapTimer += Time.deltaTime;

        scoreUI.text = "Score: " + Score;

        //Checks for input from user
        if(Input.GetKeyDown(KeyCode.Space) && isAlive)
        {
            print("Space");
            //Extra boost for repeated taps
            if (flapTimer < .6f)
                shouldBoost = true;

            else
                shouldBoost = false;

            flapTimer = 0;

            //Starts game if not started yet
            if(!bIsStarted)
            {
                timer = 0;

                bIsStarted = true;

                //makes character no longer stationary
                rb.isKinematic = false;

                //sets mass and gravity in code to avoid mistakes in editor
                rb.mass = 1;
                rb.gravityScale = 1.5f;

                //Starts spawning "pipes"
                FindObjectOfType<PopeGenerator>().bIsStarted = true;
                Pope.canMove = true;

                StartCoroutine( FindObjectOfType<PopeGenerator>().SpawnPopes());

            }

            //function call for moving upwards
            flap(shouldBoost);
        }

        else if(!isAlive)
        {
            DeathScreen.SetActive(true);

            PopeGenerator.singleton.StopAllCoroutines();

            PopeGenerator.singleton.bIsStarted = false;

            Pope.canMove = false;

            PopeMovement.canMove = false;

            timer += Time.deltaTime;

            if(timer >= 5.2f)
            {
                rb.angularVelocity = 0;

                rb.velocity = new Vector2(0, 0);

                rb.isKinematic = true;

                transform.position = new Vector3(0, 0, 0);

                transform.rotation = Quaternion.identity;

                PopeMovement.canMove = true;

                bIsStarted = false;

                isAlive = true;

                Score = 0;

                foreach(PopeMovement p in FindObjectsOfType<PopeMovement>())
                    {
                        Destroy(p.gameObject);
                    }

                DeathScreen.SetActive(false);
            }
            
        }

        //increases gravity around apex of jump for quicker fall
        else if(rb.velocity.y >= 0.75f)
        {
            rb.gravityScale += 0.12f;
        }

        //rotates character slightly according to upward velocity
        if(bIsStarted)
        {
            if (gameObject.transform.rotation.z <= 90 || gameObject.transform.rotation.z >= -90)
                gameObject.transform.eulerAngles = new Vector3(0, 0, rb.velocity.y);
        }
        
	}

    

    void flap(bool canBoost)
    {
        //resets gravity
        rb.gravityScale = 1.5f;

        print(rb.velocity.magnitude);
        //stops current velocity to ensure even jumps

        //jump
        if (canBoost)
        {
          
            rb.AddForce(new Vector2(0, jumpForce + boost));
           if (rb.velocity.magnitude >= 5 )
            {
                rb.velocity = rb.velocity.normalized * 5;
            }

        }
        else
        {
         
            rb.velocity += -rb.velocity;
            rb.AddForce(new Vector2(0, jumpForce));
            
        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        print(c.gameObject.name);

        //kills character on collision with a "pipe"
        if(c.gameObject.GetComponent<Pope>() || c.gameObject.name == "Ground")
        {
            print("Hit");
            isAlive = false;
          
        }
        //adds to score is player makes it through "pipe"
        
    }

    

}
