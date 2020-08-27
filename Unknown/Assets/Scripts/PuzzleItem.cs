using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleItem : Interactable
{
    [SerializeField] GameObject stoppingZone = null;
    [SerializeField] GameObject puzzleUI = null ;
    [SerializeField] GameObject zombieObstacle = null;
    public Vector3 stoppingZonePos;

    private void Start()
    {
        stoppingZonePos = stoppingZone.transform.position;
    }

    public override void Interact()
    {
        base.Interact();

        ActivatePuzzle();
    }

    public void ActivatePuzzle()
    {
        if (zombieObstacle.GetComponent<ZombieObstacle>().hasArrived)
        {
            puzzleUI.SetActive(true);
        }
    }

}
