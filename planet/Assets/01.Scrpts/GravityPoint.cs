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
        //행성과 오브젝트 사이의 거리 계산
        Vector3 dir = (transform.position - obj.transform.position) * gravityScale;
        

        if(obj.CompareTag("Player") || obj.CompareTag("Turret"))
        {
            //중력이 작용하는 방향설정
            obj.GetComponent<Rigidbody2D>().AddForce(dir);
            obj.transform.up = Vector3.MoveTowards(obj.transform.up, -dir, gravityScale * Time.deltaTime * planetRadius);
        }
    }
}
