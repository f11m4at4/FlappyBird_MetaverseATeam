using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �����ð��� �ѹ��� ��ֹ��� ����� �ʹ�.
public class ObstacleManager : MonoBehaviour
{
    public GameObject obsFactory;
    public float createTime = 2;
    float currentTime;
    // ���� ���� ����
    public float minPos = -1;
    public float maxPos = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Bird.state != Bird.BirdState.Playing)
        {
            return;
        }
        // �����ð��� �ѹ��� ��ֹ��� ����� �ʹ�.
        currentTime += Time.deltaTime;
        if(currentTime > createTime)
        {
            currentTime = 0;
            GameObject obstacle = Instantiate(obsFactory);
            float randY = Random.Range(minPos, maxPos);
            obstacle.transform.position = transform.position + Vector3.up * randY;
        }
    }
}
