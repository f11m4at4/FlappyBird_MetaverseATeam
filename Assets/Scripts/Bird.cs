using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 사용자가 점프버튼을 누르면 점프하게 하고 싶다.
// 필요속성 : 점프파워, Rigidbody
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Bird : MonoBehaviour
{
    // Bird 의 상태
    enum BirdState
    {
        Ready,
        Start,
        Playing,
        Die
    }

    BirdState state = BirdState.Ready;

    // 필요속성 : 점프파워, Rigidbody
    public float jumpPower = 2;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // 물리 적용 안되도록
        rb.simulated = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case BirdState.Ready:
                Ready();
                break;
            case BirdState.Start:
                GameStart();
                break;
            case BirdState.Playing:
                Playing();
                break;
            case BirdState.Die:
                Die();
                break;
        }
    }

    // 일정시간 기다렸다가 상태를 Start 로 전환
    public float readyDelayTime = 2;
    float currentTime = 0;
    private void Ready()
    {
        currentTime += Time.deltaTime;
        if(currentTime > readyDelayTime)
        {
            currentTime = 0;
            state = BirdState.Start;
        }
    }

    // 사용자가 점프 혹은 발사 버튼을 누르면 상태를 Playing 으로 전환
    // 그리고 점프도 가능

    private void GameStart()
    {
        if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1"))
        {
            rb.simulated = true;
            // 2. 점프하고 싶다.
            rb.velocity = Vector2.up * jumpPower;
            state = BirdState.Playing;
        }
    }


    // 사용자가 점프버튼을 누르면 점프하게 하고 싶다.
    void Playing()
    {
        // 1. 사용자가 점프버튼을 눌렀으니까
        if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1"))
        {
            // 2. 점프하고 싶다.
            rb.velocity = Vector2.up * jumpPower;
        }
    }

    private void Die()
    {
        throw new NotImplementedException();
    }

}
