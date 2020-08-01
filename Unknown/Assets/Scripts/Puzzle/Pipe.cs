using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Directions
{
    up,
    down,
    left,
    right
}
public class Pipe : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] public Directions startingDirection;
    public Directions currentDirection;
    [SerializeField] public Directions correctDirection;


    private void Start()
    {
        currentDirection = startingDirection;
    }
    public void PipeClicked()
    {
        button.image.transform.Rotate(Vector3.forward * -90f);
        ChangeDirection();
    }

    public void ChangeDirection()
    {
        switch (currentDirection)
        {
            
            case Directions.up:                
                    currentDirection = Directions.right;
                    break;                                      
            case Directions.down:                               
                    currentDirection = Directions.left;
                    break;               
            case Directions.left:
                    currentDirection = Directions.up;
                    break;               
            case Directions.right:           
                    currentDirection = Directions.down;
                    break;
        }
       
    }
}
