using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeManager : MonoBehaviour
{
    public static PipeManager instance;
    [SerializeField] GameObject puzzleUI;
    [SerializeField] GameObject gate;
    [SerializeField] Pipe[] pipes;

    public static PipeManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PipeManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        CheckPuzle();
    }
    public void CheckPuzle()
    {
        if (pipes[0].currentDirection == pipes[0].correctDirection && pipes[1].currentDirection == pipes[1].correctDirection &&
            pipes[2].currentDirection == pipes[2].correctDirection && pipes[3].currentDirection == pipes[3].correctDirection &&
            pipes[4].currentDirection == pipes[4].correctDirection && pipes[5].currentDirection == pipes[5].correctDirection &&
            pipes[6].currentDirection == pipes[6].correctDirection && pipes[7].currentDirection == pipes[7].correctDirection &&
            pipes[8].currentDirection == pipes[8].correctDirection && pipes[9].currentDirection == pipes[9].correctDirection &&
            pipes[10].currentDirection == pipes[10].correctDirection)
            
        {
            Debug.Log("GANASTE");
            puzzleUI.SetActive(false);
            gate.GetComponent<Animator>().SetTrigger("OpenGate");
            AudioManager.instance.Play("GateOpen",false);

        }

    }
}
