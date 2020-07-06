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
            float distance = Vector3.Distance( player.position, transform.position);
            if (distance <= radius)
            {
                Debug.Log("Interacting with " + transform.name);
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
        //cada objecto interactual de manera especifica.
        Debug.Log("Interacting with " + transform.name);
    }
}
