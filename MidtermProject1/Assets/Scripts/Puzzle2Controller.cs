using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puzzle2Controller : MonoBehaviour
{
    public static bool isPuzzle2Completed = false;
    public int basicPuzzleCounter = 0;
    private int basicPuzzle2ACounter = 0;
    private int basicPuzzle2BCounter = 0;
    private int basicPuzzle2CCounter = 0;
    public bool is2Acompleted = false;
    public bool is2Bcompleted = false;
    public bool is2Ccompleted = false;

    public GameObject puzzle2a;
    public GameObject puzzle2b;
    public GameObject puzzle2c;
    public GameObject puzzle2d;
    public GameObject puzzle2e;
    public GameObject puzzle2f;
    public GameObject puzzle2g;
    public GameObject puzzle2h;
    public GameObject puzzle2i;

    public TextMeshProUGUI textMesh;
    public Animator dialogAnimator;
    public Animator puzzleLightAnimator;
    public Animator puzzle2ALightAnimator;
    public Animator puzzle2BLightAnimator;
    public Animator puzzle2CLightAnimator;
    public GameObject higherJumpPU;

    Puzzle2Script pz2a;
    Puzzle2Script pz2b;
    Puzzle2Script pz2c;
    Puzzle2Script pz2d;
    Puzzle2Script pz2e;
    Puzzle2Script pz2f;
    Puzzle2Script pz2g;
    Puzzle2Script pz2h;
    Puzzle2Script pz2i;

    void Start()
    {
        pz2a = puzzle2a.GetComponent<Puzzle2Script>();
        pz2b = puzzle2b.GetComponent<Puzzle2Script>();
        pz2c = puzzle2c.GetComponent<Puzzle2Script>();
        pz2d = puzzle2d.GetComponent<Puzzle2Script>();
        pz2e = puzzle2e.GetComponent<Puzzle2Script>();
        pz2f = puzzle2f.GetComponent<Puzzle2Script>();
        pz2g = puzzle2g.GetComponent<Puzzle2Script>();
        pz2h = puzzle2h.GetComponent<Puzzle2Script>();
        pz2i = puzzle2i.GetComponent<Puzzle2Script>();
    }


    void Update()
    {
        if(pz2a.isPuzzlePieceTrue && pz2b.isPuzzlePieceTrue && pz2c.isPuzzlePieceTrue && basicPuzzle2ACounter == 0)
        {
            puzzle2ALightAnimator.SetTrigger("OpenLight");
            is2Acompleted = true;
            basicPuzzle2ACounter++;
        }
        if (pz2d.isPuzzlePieceTrue && pz2e.isPuzzlePieceTrue && pz2f.isPuzzlePieceTrue && basicPuzzle2BCounter == 0)
        {
            puzzle2BLightAnimator.SetTrigger("OpenLight");
            is2Bcompleted = true;
            basicPuzzle2BCounter++;
        }
        if (pz2g.isPuzzlePieceTrue && pz2h.isPuzzlePieceTrue && pz2i.isPuzzlePieceTrue && basicPuzzle2CCounter == 0)
        {
            puzzle2CLightAnimator.SetTrigger("OpenLight");
            is2Ccompleted = true;
            basicPuzzle2CCounter++;
        }
        if (is2Acompleted && is2Bcompleted && is2Ccompleted && basicPuzzleCounter == 0)
        {
            PuzzleIsCompleted();
            basicPuzzleCounter++;
        }
    }

    public void PuzzleIsCompleted()
    {
        FindObjectOfType<AudioManager>().Play("PuzzleComplete");
        isPuzzle2Completed = true;
        higherJumpPU.SetActive(true);
        puzzleLightAnimator.SetTrigger("PuzzleLightOpen");
        StartCoroutine(DialogOpen());
    }

    IEnumerator DialogOpen()
    {
        textMesh.text = "You've Made It!\nLook there is a Power Up";
        dialogAnimator.SetTrigger("PanelOpen");
        yield return new WaitForSeconds(3.5f);
        dialogAnimator.SetTrigger("TextClose");
        yield return new WaitForSeconds(0.8f);
        textMesh.text = "Do you love basketball? Just asking for a friend";
        yield return new WaitForSeconds(3.5f);
        dialogAnimator.SetTrigger("PanelClose");
    }

}
