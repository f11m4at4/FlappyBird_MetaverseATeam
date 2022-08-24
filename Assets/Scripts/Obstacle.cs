using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �������� ��� �̵��ϰ� �ʹ�.
// �ʿ�Ӽ� : �̵��ӵ�
public class Obstacle : MonoBehaviour
{
    // �ʿ�Ӽ� : �̵��ӵ�
    public float speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Bird ���°� Playing �϶��� ����
        if(Bird.state != Bird.BirdState.Playing)
        {
            return;
        }
        // �������� ��� �̵��ϰ� �ʹ�.
        // P = P0 + vt
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
