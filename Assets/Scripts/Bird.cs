using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 사용자가 점프버튼을 누르면 점프하게 하고 싶다.
// 필요속성 : 점프파워, Rigidbody
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Bird : MonoBehaviour
{
    // Bird 의 상태
    public enum BirdState
    {
        Ready,
        Start,
        Playing,
        Die
    }

    public static BirdState state = BirdState.Ready;

    // 필요속성 : 점프파워, Rigidbody
    public float jumpPower = 2;
    Rigidbody2D rb;

    Animator anim;

    public GameObject readyText;
    public GameObject gameoverText;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // 물리 적용 안되도록
        rb.simulated = false;

        state = BirdState.Ready;
        anim = GetComponent<Animator>();
        gameoverText.SetActive(false);
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
            anim.SetTrigger("Fly");
            readyText.SetActive(false);
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
        // 아무키나 누르면 다시 시작하고 싶다.
        if(Input.anyKeyDown)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // 부딪히면 상태를 Die 로 전환하고 싶다.
    // 왼쪽 대각선 뒤로 쬐끔 튕기고 싶다.
    public Vector2 dieSpeed = new Vector2(-1, 2);
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(state == BirdState.Die)
        {
            return;
        }
        state = BirdState.Die;
        anim.SetTrigger("Die");
        rb.velocity = dieSpeed;
        gameoverText.SetActive(true);
    }

    // ScoreArea 충돌하면 점수 올려주기
    private void OnTriggerExit2D(Collider2D collision)
    {
        ScoreManager.Instance.Score++;
    }
}
