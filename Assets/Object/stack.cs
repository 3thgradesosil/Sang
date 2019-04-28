using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stack : MonoBehaviour
{
    /*
    private Vector3 mousePosition;
    public float moveSpeed = 0.01f;
    public float speed = 3.5f;
    */
    // Start is called before the first frame update
    //겜메로 따지면 Create이벤트, 가장 처음 생성시 옵션.
    public float Speed;
    public float offset = 0.0f;
    void Start()
    {

    }

    // Update is called once per frame
    // 겜메로 따지면 Update는 step같은것. 매 프레임 실행되는 함수.
    void Update()
    {/*
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed*speed);
        */
        Vector3 Target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Target.z = transform.position.z;
        transform.position = Vector3.MoveTowards(transform.position, Target, Speed * Time.deltaTime / transform.localScale.x);
        
        //I have to fixed direction that looking
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + offset);
    }
}
