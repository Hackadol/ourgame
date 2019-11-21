using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class VirusScript : MonoBehaviour
{
    // Start is called before the first frame update
    bool stop = false;
    public string typeclass = "Enemy";
    Vector3 stopPos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stop == true)
        {
            this.transform.position = stopPos;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BoyScript enemy = collision.gameObject.GetComponent<BoyScript>();
        if (enemy != null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "VirusStopper")
        {
            stop = true;
            stopPos = this.transform.position;
        }
        DrugScript dr = collision.transform.GetComponent<DrugScript>();
        if (dr != null)
        {
            Destroy(this.gameObject);
        }
    }
}
