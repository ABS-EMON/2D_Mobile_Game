using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{

    public Animator anim;

    public bool run = false;
    public bool runLeft = false;
    public bool runRight = true;
    public bool jump = false;
    public bool isGrounded = true;
    public Rigidbody2D rbody;
    public float score = 0;
    public TextMeshProUGUI scoreText;
    public AudioSource myAudio;
    public AudioClip coinCollectionSound;
    public Image levelCompleteImage;
    public Image pauseImage;
    public bool pause;







// Start is called before the first frame update
void Start()
    {
        anim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        /* if (Input.GetKey(KeyCode.Space))
         {
             jump = true;
         }
         else
         {
             jump = false;
         }*/

        if (Input.GetKeyDown(KeyCode.Escape)
)
        {
            pause = !pause;

            if (pause == true)
            {
                pauseImage.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
            else if (pause == false)
            {
                pauseImage.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
        }


        if (jump == true && isGrounded==true)
        {
            rbody.AddForce(new Vector2(0, 150f));

        }




        if (run == true && runRight==true)
        {
            transform.Translate(0.03f, 0, 0);
        }
        else if (run == true && runLeft==true)
        {
            transform.Translate(-0.03f, 0, 0);

        }



        /*if (Input.GetKey(KeyCode.A))
        {
            run = true;
            Vector3 Scale= transform.localScale;
            Scale.x = -0.038f;
            transform.localScale = Scale;
            transform.Translate(-0.03f, 0, 0);

        }
       

        else if (Input.GetKey(KeyCode.D))
        {
            run = true;
            Vector3 Scale = transform.localScale;
            Scale.x = 0.038f;
            transform.localScale = Scale;
            transform.Translate(0.03f, 0, 0);

        }
        else
        {
            run = false;
        }*/

        scoreText.text = score.ToString();

        anim.SetBool("Run", run);
        anim.SetBool("Jump", jump);

    }

    public void RunLeft()
    {
        run = true;
        runLeft = true;
        runRight = false;
        Vector3 Scale = transform.localScale;
        Scale.x = -0.038f;
        transform.localScale = Scale;
        transform.Translate(-0.03f, 0, 0);

    }

    public void RunRight()
    {

        run = true;
        runLeft = false;
        runRight = true;
        Vector3 Scale = transform.localScale;
        Scale.x = 0.038f;
        transform.localScale = Scale;
        transform.Translate(0.03f, 0, 0);
    }
    public void ButtonReless()
    {
        run = false;
        jump = false;

    }
    public void PlayerJump()
    {

        jump = true;

    }


    public void PlayAgain()
    {

        SceneManager.LoadScene(1);

    }

    public void GoToMenu()
    {

        SceneManager.LoadScene(0);
        Time.timeScale = 1;

    }



    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        if (other.gameObject.tag == "Coin")
        {

            Destroy(other.gameObject);
            score++;
            myAudio.PlayOneShot(coinCollectionSound, 1f);
        }
        if (other.gameObject.tag == "Killer")
        {

            SceneManager.LoadScene(1);
        }

        if (other.gameObject.tag == "LevelComplete")
        {

            levelCompleteImage.gameObject.SetActive(true);
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
