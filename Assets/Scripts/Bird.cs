using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// ����ڰ� ������ư�� ������ �����ϰ� �ϰ� �ʹ�.
// �ʿ�Ӽ� : �����Ŀ�, Rigidbody
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Bird : MonoBehaviour
{
    // Bird �� ����
    public enum BirdState
    {
        Ready,
        Start,
        Playing,
        Die
    }

    public static BirdState state = BirdState.Ready;

    // �ʿ�Ӽ� : �����Ŀ�, Rigidbody
    public float jumpPower = 2;
    Rigidbody2D rb;

    Animator anim;

    public GameObject readyText;
    public GameObject gameoverText;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // ���� ���� �ȵǵ���
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
            anim.SetTrigger("Fly");
            readyText.SetActive(false);
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
        // �ƹ�Ű�� ������ �ٽ� �����ϰ� �ʹ�.
        if(Input.anyKeyDown)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // �ε����� ���¸� Die �� ��ȯ�ϰ� �ʹ�.
    // ���� �밢�� �ڷ� �ز� ƨ��� �ʹ�.
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

    // ScoreArea �浹�ϸ� ���� �÷��ֱ�
    private void OnTriggerExit2D(Collider2D collision)
    {
        ScoreManager.Instance.Score++;
    }
}
