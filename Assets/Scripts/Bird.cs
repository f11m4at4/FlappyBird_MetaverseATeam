using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����ڰ� ������ư�� ������ �����ϰ� �ϰ� �ʹ�.
// �ʿ�Ӽ� : �����Ŀ�, Rigidbody
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Bird : MonoBehaviour
{
    // Bird �� ����
    enum BirdState
    {
        Ready,
        Start,
        Playing,
        Die
    }

    BirdState state = BirdState.Ready;

    // �ʿ�Ӽ� : �����Ŀ�, Rigidbody
    public float jumpPower = 2;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // ���� ���� �ȵǵ���
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

    // �����ð� ��ٷȴٰ� ���¸� Start �� ��ȯ
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

    // ����ڰ� ���� Ȥ�� �߻� ��ư�� ������ ���¸� Playing ���� ��ȯ
    // �׸��� ������ ����

    private void GameStart()
    {
        if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1"))
        {
            rb.simulated = true;
            // 2. �����ϰ� �ʹ�.
            rb.velocity = Vector2.up * jumpPower;
            state = BirdState.Playing;
        }
    }


    // ����ڰ� ������ư�� ������ �����ϰ� �ϰ� �ʹ�.
    void Playing()
    {
        // 1. ����ڰ� ������ư�� �������ϱ�
        if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1"))
        {
            // 2. �����ϰ� �ʹ�.
            rb.velocity = Vector2.up * jumpPower;
        }
    }

    private void Die()
    {
        throw new NotImplementedException();
    }

}
