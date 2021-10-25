using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eliminar : MonoBehaviour
{
    [SerializeField] float time;
    // Start is called before the first frame update
    void Start()
    {
        Tiempo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void Tiempo()
    {
        Destroy(gameObject, time);
    }
}
