using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class PowerUp : MonoBehaviour
{
    private float timeTillPUStart = 0;
    private bool startTime = false;
    public Animator sliderAnimator;
    public Slider timerSlider;
    public Text timerText;
    private bool stopTimer;
    public GameObject pickupEffect;
    PlayerStats stats;
    public float puDuration = 10;    //Power up ýn saniye cinsinden ne kadar sürüceði
    public float jumpingMultiplier = 1.4f;
    public float speedMultiplier = 2.2f;
    public float smallerSizeMultiplier = 1.7f;
    public float biggerSizeMultiplier = 1.4f;
    MeshRenderer[] allChildrenMesh;

    private GameObject insEffect;

    void Start()
    {
        allChildrenMesh = gameObject.GetComponentsInChildren<MeshRenderer>();//bunu yapmamýn sebebi kristalin parentta deðil
    }                                                                        //childlarýnda mesh renderer componenti olmasý                                                               

    void Update()
    {
        if (startTime == true)
        {
            Debug.Log("if içi stop timer " + stopTimer);
            timeTillPUStart += Time.deltaTime;
            double time = puDuration - timeTillPUStart;
            Debug.Log("if içi time " + time);
            if (time <= 0)
            {
                stopTimer = true;

            }
            if (!stopTimer)
            {
                timerText.text = "Power Up Time Left: " + time.ToString("F2");
                timerSlider.value = System.Convert.ToSingle(time);
            }
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
        }
    }

    //Kodu sadeleþtirmeyi denedim ama maalesef kod özelliðini yitirdi, þimdilik mecbur çalýþmasý için bu þekilde býraktým

    IEnumerator Pickup(Collider player)
    {
        if (!gameObject.CompareTag("HealthPU"))
        {
            stopTimer = false;
            startTime = true;
            timerSlider.maxValue = puDuration;
            timerSlider.value = puDuration;

            sliderAnimator.SetTrigger("Open");
        }

        stats = player.GetComponent<PlayerStats>();

        insEffect = Instantiate(pickupEffect, transform.position + new Vector3(0f, 1f, 0f), transform.rotation) as GameObject;//efekti baþlatýyor

        FindObjectOfType<AudioManager>().Play("PowerUp");


        if (gameObject.CompareTag("HealthPU"))
        {
            if(stats.playerHealth < 3)
            {
                stats.playerHealth++;
            }    
            for (int i = 0; i < allChildrenMesh.Length; i++)
            {
                allChildrenMesh[i].enabled = false;
            }
            GetComponent<Collider>().enabled = false;
            yield return new WaitForSeconds(1.5f);
        }
        if (gameObject.CompareTag("HigherJumpPU"))//alýnan power up ýn tagýna bakýp ona göre kod bloðunu uyguluyor
        {
            stats.jumpingSpeed *= jumpingMultiplier;//güçlendirme uygulandý
            for (int i = 0; i < allChildrenMesh.Length; i++)
            {
                allChildrenMesh[i].enabled = false;//kristalin meshRenderer ý kapatýldý, childlarda olduðu için böyle yapýldý
            }  //bunlarýn sebebi objeyi destroy edersek güçlendirmeleri saniyesinde kaybederiz. o yüzden görünürlüðü gidiyor.
            GetComponent<Collider>().enabled = false;   //kristalin colliderý kapatýldý
            yield return new WaitForSeconds(puDuration);
            stats.jumpingSpeed /= jumpingMultiplier; //saniye bittikten sonra eski haline çevrildi
        }
        if (gameObject.CompareTag("SpeedPU"))
        {
            stats.maxSpeed = 55f;
            stats.speed *= speedMultiplier;
            for (int i = 0; i < allChildrenMesh.Length; i++)
            {
                allChildrenMesh[i].enabled = false;
            } 
            GetComponent<Collider>().enabled = false; 
            yield return new WaitForSeconds(puDuration);
            stats.speed /= speedMultiplier;
            stats.maxSpeed = 25f;
        }
        if (gameObject.CompareTag("SmallerSizePU"))
        {
            player.transform.localScale /= smallerSizeMultiplier;
            for (int i = 0; i < allChildrenMesh.Length; i++)
            {
                allChildrenMesh[i].enabled = false;
            }
            GetComponent<Collider>().enabled = false;
            yield return new WaitForSeconds(puDuration);
            player.transform.localScale *= smallerSizeMultiplier;
        }
        if (gameObject.CompareTag("BiggerSizePU"))
        {
            stats.haveBiggerPU = true; //spikelar öldürmesin diye bir bool
            player.transform.localScale *= biggerSizeMultiplier;
            for (int i = 0; i < allChildrenMesh.Length; i++)
            {
                allChildrenMesh[i].enabled = false;
            }
            GetComponent<Collider>().enabled = false;
            yield return new WaitForSeconds(puDuration);
            player.transform.localScale /= biggerSizeMultiplier;
            stats.haveBiggerPU = false;

        }

        if (!gameObject.CompareTag("HealthPU"))
        {
            startTime = false;
            sliderAnimator.SetTrigger("Close");
            StartCoroutine(RespawnPU());
        }
        
        Destroy(insEffect);
    }

    IEnumerator RespawnPU()
    {
        timeTillPUStart = 0;

        for (int i = 0; i < allChildrenMesh.Length; i++)
        {
            allChildrenMesh[i].enabled = false;
        }
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(4f);
        for (int i = 0; i < allChildrenMesh.Length; i++)
        {
            allChildrenMesh[i].enabled = true;
        }
        GetComponent<Collider>().enabled = true;
    }

}
