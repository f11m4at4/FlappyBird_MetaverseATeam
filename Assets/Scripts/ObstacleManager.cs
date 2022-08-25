using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 일정시간에 한번씩 장애물을 만들고 싶다.
public class ObstacleManager : MonoBehaviour
{
    public GameObject obsFactory;
    public float createTime = 2;
    float currentTime;
    // 생성 높이 간격
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
        // 일정시간에 한번씩 장애물을 만들고 싶다.
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
