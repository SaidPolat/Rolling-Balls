using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    public Animator transition;
    [SerializeField] Transform respawnPoint;

    Rigidbody rigid;
    PlayerStats stats;

    void Start()
    {
        rigid = player.GetComponent<Rigidbody>();
        stats = player.GetComponent<PlayerStats>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (gameObject.name == "RespawnTrigger6")
        {
            PlayerStats.isInTutorial = false;
            PlayerStats.isInLevel1 = true;
            PlayerStats.isInLevel2 = false;
            StartCoroutine(LoadLevel1());
        }
        else
        {
            rigid.velocity = new Vector3(0f, 0f, 0f);//addforce kodundan dolayý spawn olduðunda top hala hareket etmesin diye
                                                     //hýzýný sýfýrlýyoruz
            stats.playerHealth--;
            player.transform.position = respawnPoint.transform.position; //playerýn positionýný respawn point positionýna
        }
    }

    IEnumerator LoadLevel1()
    {  
        transition.SetTrigger("LevelClosing");
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadSceneAsync(4);
    }



}
