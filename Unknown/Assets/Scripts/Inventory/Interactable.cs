using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] public float radius = 2f;

    private bool isFocus = false;
    private bool hasInteracted = false;
    
    public Transform player;

    private void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, transform.position);

            //Debug.Log("distance>> " + distance + " / radius>> " + radius);            
            if (distance <= radius)
            {
                //Debug.Log("Interacting with " + transform.name);
                Interact();

                hasInteracted = true;
            }
        }

    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDeFocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,radius);        
    }

    public virtual void Interact()
    {
        //vacio
    }
        
    public void PickUpItem()
    {
        gameObject.GetComponent<ItemPickup>().PickUp();
        this.GetComponent<MeshRenderer>().enabled = false;
        Destroy(gameObject, 1);
    }

    public void OpenDoor()
    {
        gameObject.GetComponent<ItemOpen>().Open();
    }

    public void UseNow()
    {
        gameObject.GetComponent<ItemUse>().Use();
    }

    public void ActivateNow()
    {
        gameObject.GetComponent<FireAlarm>().Activate();
    }

    public void ActivatePuzzleNow()
    {
        gameObject.GetComponent<PuzzleItem>().ActivatePuzzle();
    }          
}
