using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleItem : Interactable
{
    [SerializeField] GameObject stoppingZone;
    [SerializeField] GameObject puzzleUI;
    [SerializeField] GameObject zombieObstacle;
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
