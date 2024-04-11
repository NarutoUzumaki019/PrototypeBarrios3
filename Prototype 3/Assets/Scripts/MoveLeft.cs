using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private float speed = 30;
    
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
