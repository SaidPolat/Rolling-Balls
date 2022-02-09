using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lvl1RespawnScript : MonoBehaviour
{
    [SerializeField] GameObject player;

    [SerializeField] Transform respawnPoint;

    public Animator transition;

    Rigidbody rigid;
    PlayerStats stats;
    PlayerControl playerScore;

    void Start()
    {
        rigid = player.GetComponent<Rigidbody>();
        stats = player.GetComponent<PlayerStats>();
        playerScore = player.GetComponent<PlayerControl>();
    }

    void OnTriggerEnter(Collider other)
    {

        if (gameObject.tag == "BasketRT")
        {
            if (IsBasketCheckScript.isBasket == true)
            {
                if (stats.playerHealth < 3)
                    stats.playerHealth++;

                playerScore.score += 3;
            }
            else
            {
                rigid.velocity = new Vector3(0f, 0f, 0f);
                player.transform.position = respawnPoint.transform.position;
            }
        }
        else if (gameObject.CompareTag("Level2Trigger"))
        {
            PlayerControl.onGoingTotalScore += PlayerControl.endGameScore;
            //PlayerStats.isInLevel1 = false;
            PlayerStats.isInLevel2 = false;
            PlayerStats.isInGameOver = true;
            Cursor.lockState = CursorLockMode.None;
            StartCoroutine(LoadLevel2());
        }
        else
        {
            rigid.velocity = new Vector3(0f, 0f, 0f);//addforce kodundan dolayý spawn olduðunda top hala hareket etmesin diye
                                                     //hýzýný sýfýrlýyoruz
            stats.playerHealth--;
            player.transform.position = respawnPoint.transform.position;
        }
   
    }

    IEnumerator LoadLevel2()
    {
        transition.SetTrigger("LevelClosing");
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadSceneAsync(3);
    }
}
