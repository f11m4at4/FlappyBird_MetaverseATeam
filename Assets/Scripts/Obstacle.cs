using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 왼쪽으로 계속 이동하고 싶다.
// 필요속성 : 이동속도
public class Obstacle : MonoBehaviour
{
    // 필요속성 : 이동속도
    public float speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Bird 상태가 Playing 일때만 적용
        if(Bird.state != Bird.BirdState.Playing)
        {
            return;
        }
        // 왼쪽으로 계속 이동하고 싶다.
        // P = P0 + vt
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
