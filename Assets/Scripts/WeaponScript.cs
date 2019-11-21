using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform shotPrefab;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Attack(float angle, float force)
    {
        var shotTransform = Instantiate(shotPrefab) as Transform;

        // Assign position
        shotTransform.position = transform.position;
        float x = force * (90 - angle)/90;
        float y = force * angle/90;

        // The is enemy property
        DrugScript shot = shotTransform.gameObject.GetComponent<DrugScript>();
        Rigidbody2D rb = shot.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(new Vector2(x,y));
        }
    }
}
