using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleItem : Interactable
{
    [SerializeField] GameObject stoppingZone = null;
    [SerializeField] GameObject puzzleInstructionsUI = null;
    [SerializeField] GameObject puzzleUI = null ;
    [SerializeField] GameObject zombieObstacle = null;
    public Vector3 stoppingZonePos;
    PlayerAnimator playerAnimator;
    public bool isUsable = false;

    private void Start()
    {
        stoppingZonePos = stoppingZone.transform.position;
        playerAnimator = player.GetComponent<PlayerAnimator>();
    }

    public override void Interact()
    {
        base.Interact();      
    }

    public void ActivatePuzzle()
    {
        if (zombieObstacle.GetComponent<ZombieObstacle>().hasArrived)
        {
            puzzleInstructionsUI.SetActive(true);
            puzzleUI.SetActive(true);
            playerAnimator.Idle();
            InputManager.instance.UnlockMouse();
        }
    }
}
