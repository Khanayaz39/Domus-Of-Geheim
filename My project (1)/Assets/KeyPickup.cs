using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KeyPickup : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(OnGrab);
    }

    private void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrab);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        PlayerInventory inventory = args.interactorObject.transform.GetComponentInParent<PlayerInventory>();
        if (inventory != null)
        {
            inventory.hasKey = true;

            // Optionally destroy or disable key
            Destroy(gameObject);
        }
    }
}

