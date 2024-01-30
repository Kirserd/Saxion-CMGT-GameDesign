using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : EntityInteractor
{
    private HashSet<Collider2D> _interactables = new();
    private Collider2D _closest;

    private void Update()
    {
        _closest = TakeClosest();

        #region INPUT HANDLER
        if (Input.GetKeyDown(Controls.Get(InputAction.Up)) || Input.GetKeyDown(Controls.GetAlt(InputAction.Up)))
            OnInteract();

        #endregion
    }

    private Collider2D TakeClosest()
    {
        if (_interactables.Count == 0)
            return null;

        if (_interactables.Count == 1)
        {
            foreach (Collider2D interactable in _interactables)
                return interactable;
        }

        Vector3 position = transform.position;
        Collider2D closest = null;
        float minDist = float.MaxValue;
        foreach (Collider2D interactable in _interactables)
        {
            float dist = Vector2.Distance(interactable.transform.position, position);
            if (dist < minDist)
            {
                minDist = dist;
                closest = interactable;
            }
        }
        return closest;
    }

    private void OnInteract()
    {
        if (_closest is null)
            return;
        _closest.GetComponent<Interactable>().Interact(this);
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);

        if (other.CompareTag("Interactable"))
            _interactables.Add(other);

        else if(other.CompareTag("InteractableImmediate"))
            other.GetComponent<Interactable>().Interact(this);

        else if (other.CompareTag("Teleport"))
            other.GetComponent<Teleport>().Invoke();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
            _interactables.Remove(other);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DamagingTiles"))
            StartCoroutine(nameof(ReturnToTheSafeSpot));
    }

    private IEnumerator ReturnToTheSafeSpot()
    {
        PlayerLinks.instance.PlayerMovement.Rigidbody.Sleep();
        PlayerLinks.instance.PlayerMovement.enabled = false;
        CameraMovement.Current.Shake(time: 0.2f, amount: 0.3f);
        yield return new WaitForSeconds(0.2f);
        transform.position = PlayerLinks.instance.PlayerMovement.LastSafeSpot;
        PlayerLinks.instance.PlayerMovement.enabled = true;
        PlayerLinks.instance.PlayerMovement.Rigidbody.WakeUp();
    }
}
