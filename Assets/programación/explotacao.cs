using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explotacao : MonoBehaviour
{
    public GameObject explotasion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject objeto = collision.gameObject;
        if (collision.gameObject.CompareTag("objeto"))
        {
            Instantiate(explotasion, transform.position, transform.rotation);
        }
    }
}
