using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector2(player.position.x + offset.x, player.position.y + offset.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DrugScript dr = collision.transform.GetComponent<DrugScript>();
        if (dr != null)
        {
            Destroy(this.gameObject);
        }
    }

}
