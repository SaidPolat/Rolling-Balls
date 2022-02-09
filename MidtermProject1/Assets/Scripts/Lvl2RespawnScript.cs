using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lvl2RespawnScript : MonoBehaviour
{

    [SerializeField] GameObject player;

    [SerializeField] Transform respawnPoint;

    public Animator transition;

    Rigidbody rigid;
    PlayerStats stats;
    

    void Start()
    {
        rigid = player.GetComponent<Rigidbody>();
        stats = player.GetComponent<PlayerStats>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Level2Trigger")) //yani level1
        {
            PlayerControl.onGoingTotalScore += PlayerControl.endGameScore;
            PlayerStats.isInLevel1 = false;
            PlayerStats.isInLevel2 = true;
            Cursor.lockState = CursorLockMode.None;
            StartCoroutine(LoadLevel1());
        }
        else
        {
            rigid.velocity = new Vector3(0f, 0f, 0f);//addforce kodundan dolayý spawn olduðunda top hala hareket etmesin diye
                                                     //hýzýný sýfýrlýyoruz
            stats.playerHealth--;
            player.transform.position = respawnPoint.transform.position;
        }
    }

    IEnumerator LoadLevel1()
    {
        transition.SetTrigger("LevelClosing");
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadSceneAsync(2);
    }
}
