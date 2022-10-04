using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPoint : MonoBehaviour
{
    public float gravityScale, planetRadius;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D obj)
    {
        Vector3 dir = (transform.position - obj.transform.position) * gravityScale;
        obj.GetComponent<Rigidbody2D>().AddForce(dir);

        if(obj.CompareTag("Player"))
        {
            obj.transform.up = Vector3.MoveTowards(obj.transform.up, -dir, gravityScale * Time.deltaTime * planetRadius);
        }
    }
}
