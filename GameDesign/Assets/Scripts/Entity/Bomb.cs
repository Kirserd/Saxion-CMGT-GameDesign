using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float timeToExplode = 3f;
    public GameObject explosionPrefab;
    private void Start() => StartCoroutine(nameof(WaitTillExploded));
    private IEnumerator WaitTillExploded()
    {
        yield return new WaitForSeconds(timeToExplode);
        
        var explosion = Instantiate(explosionPrefab, transform.parent);
        explosion.transform.position = transform.position;

        CameraMovement.Current.Shake(time: 0.2f, amount: Mathf.Clamp(0.8f - Vector2.Distance(PlayerLinks.instance.transform.position, transform.position), 0f, 10f) * 0.2f);
        yield return new WaitForSeconds(0.5f);

        if(explosion != null)
            Destroy(explosion);

        Destroy(gameObject);
    }
}