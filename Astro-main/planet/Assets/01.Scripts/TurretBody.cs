using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBody : MonoBehaviour
{

    private Rigidbody2D turret;

    // Start is called before the first frame update
    void Start()
    {
        turret = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
