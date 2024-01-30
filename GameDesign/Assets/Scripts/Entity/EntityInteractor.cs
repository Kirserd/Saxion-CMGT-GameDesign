using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityInteractor : MonoBehaviour
{
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Explosion"))
        {
            Vector2 explosionDirection = ((transform.position + Vector3.up * 0.075f) - other.transform.position).normalized;
            float explosionForce = Mathf.Clamp(1 - Vector2.Distance(transform.position, other.transform.position), 0, 10) * 3.4f;
            GetComponent<Rigidbody2D>().AddForce(explosionDirection * explosionForce, ForceMode2D.Impulse);
            Destroy(other.gameObject);
        }
    }
}
