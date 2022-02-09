using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    Rigidbody rigid;

    public Text scoreText;
    public Text nameText;
    private bool onGround = true;
    private int maxJump = 2;
    private int currentJump = 0;
    public int score = 0;
    PlayerStats stats;
    public GameObject pickupEffectCyan;
    public GameObject pickupEffectBlue;
    private bool alreadyCollidedWithSpike = false;
    public static bool alreadyHitButton = false;
    public static bool onButton = false;
    public static bool doResetButton = false;
    private GameObject insEffect;
    public static List<int> scoreList = new List<int>();
    public static int onGoingTotalScore = 0;
    public static int playersMaxScore = 0;
    public static int endGameScore;
    public AudioManager audioManager;
    AudioSource audioSource;

    Puzzle1ButtonsScript puzzle1Button;
    Puzzle2ButtonScript puzzle2Button;

    public Transform cam;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rigid = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; 
        nameText.text = MainMenuScript.myName;
        stats = gameObject.GetComponent<PlayerStats>();
        
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        if (Input.GetButtonDown("Jump") && (onGround || maxJump > currentJump)) //Double jump için kod kýsmý
        {
            audioManager.Play("Jump");
            rigid.AddForce(Vector3.up * stats.jumpingSpeed, ForceMode.Impulse);
            currentJump++;
            onGround = false;
            if (rigid.velocity.magnitude > stats.maxSpeed)//max speed i geçmemesi için olan kod
            {
                rigid.velocity = rigid.velocity.normalized * stats.maxSpeed;
            }
        }

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y; // bu method kordinatta +y den, saat yönünde
                                                                                       // (x,y) vektörüne olan açýyý buluyor, rad2deg ile çarpma sebebimiz de
                                                                                       //bize sonucu radyant deðerinden veriyor, biz onu dereceye çeviriyoruz
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            //kameranýn baktýðý yöne doðru hareket edelim diye.

            rigid.AddForce(moveDir.normalized * stats.speed * Time.deltaTime);

            if(rigid.velocity.magnitude > stats.maxSpeed)//max speed i geçmemesi için olan kod
            {
                rigid.velocity = rigid.velocity.normalized * stats.maxSpeed;
            }
        }

        audioSource.pitch = (rigid.velocity.magnitude / stats.maxSpeed) + 0.4f;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Score"))    //skorlarý aldýðý yer
        {
            audioManager.Play("Score1");
            insEffect = Instantiate(pickupEffectBlue, transform.position, transform.rotation);
            score++;
            other.gameObject.SetActive(false);
            scoreText.text = "Score = " + (score + onGoingTotalScore);
            endGameScore = score;
            Destroy(insEffect, 2f);
        }
        if (other.gameObject.CompareTag("Score3"))
        {
            audioManager.Play("Score3");
            insEffect = Instantiate(pickupEffectCyan, transform.position, transform.rotation);
            score += 3;
            other.gameObject.SetActive(false);
            scoreText.text = "Score = " + (score + onGoingTotalScore);
            endGameScore = score;
            Destroy(insEffect, 2f);
        }
    }


    void OnCollisionEnter(Collision collision) 
    {
        audioManager.Play("HitSlow");

        if (collision.gameObject.CompareTag("Button1"))
        {
            if (alreadyHitButton == false)
            {
                onButton = true;
                alreadyHitButton = true;
                audioManager.Play("ButtonPress");
                puzzle1Button = collision.gameObject.GetComponent<Puzzle1ButtonsScript>();
                puzzle1Button.PressButon();

                if (doResetButton)
                {
                    ResetButton1(collision);
                }
            }
            
        }

        if (collision.gameObject.CompareTag("Button2"))
        {
            if (alreadyHitButton == false)
            {
                onButton = true;
                alreadyHitButton = true;
                audioManager.Play("ButtonPress");
                puzzle2Button = collision.gameObject.GetComponent<Puzzle2ButtonScript>();
                puzzle2Button.PressButon();

                if (doResetButton)
                {
                    ResetButton2(collision);
                }
            }

        }

        if (collision.gameObject.layer == 9)//double jump için currentJump sayýsýný yere deðince sýfýrlama
        {
            onGround = true;
            currentJump = 0;      
        }
        
        if (collision.gameObject.CompareTag("Spike"))
        {
            if (alreadyCollidedWithSpike == false)
            {
                onGround = true;
                currentJump = 0;
                audioManager.Play("Spike");
                alreadyCollidedWithSpike = true;

                if (!stats.haveBiggerPU)  //bigger size power up'ý alýnca true olan bir bool, alýnmýþ mý diye kontrol ediyoruz
                {
                    stats.playerHealth--;

                    rigid.velocity = new Vector3(0f, 0f, 0f);

                    SpikesScript spike = collision.gameObject.GetComponent<SpikesScript>();

                    spike.RespawnToTarget();
                }
            }
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Button1"))
        {
            onButton = true;
            puzzle1Button = collision.gameObject.GetComponent<Puzzle1ButtonsScript>();
            puzzle1Button.HoldButton();
        }

        if (collision.gameObject.CompareTag("Button2"))
        {
            onButton = true;
            puzzle2Button = collision.gameObject.GetComponent<Puzzle2ButtonScript>();
            puzzle2Button.HoldButton();
        }

        if (audioSource.isPlaying == false && rigid.velocity.magnitude >= 0.3f && collision.gameObject.layer == 9)   //top yerdeyse ve hýzý varsa vs. topun yerde gitme sesini
        {                                                                                                            //oynatýyor.(collision stay içi)
            audioSource.Play();           
        }
        else if(audioSource.isPlaying == true && rigid.velocity.magnitude < 0.3f && collision.gameObject.layer == 9)
        {
            audioSource.Pause();
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
            alreadyCollidedWithSpike = false;   

        if(audioSource.isPlaying == true && collision.gameObject.layer == 9)
            audioSource.Pause();

        if (collision.gameObject.CompareTag("Button1"))
        {
            puzzle1Button = collision.gameObject.GetComponent<Puzzle1ButtonsScript>();
            puzzle1Button.ExitButton();

        }
        if (collision.gameObject.CompareTag("Button2"))
        {        
            puzzle2Button = collision.gameObject.GetComponent<Puzzle2ButtonScript>();
            puzzle2Button.ExitButton();

        }
    }

    public void ResetButton1(Collision collision)
    {
        puzzle1Button = collision.gameObject.GetComponent<Puzzle1ButtonsScript>();
        puzzle1Button.HoldButton();
        puzzle1Button.ExitButton();
    }
    public void ResetButton2(Collision collision)
    {
        puzzle2Button = collision.gameObject.GetComponent<Puzzle2ButtonScript>();
        puzzle2Button.HoldButton();
        puzzle2Button.ExitButton();
    }
}
