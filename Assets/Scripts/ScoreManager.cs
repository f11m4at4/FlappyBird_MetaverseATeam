using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// 점수 저장 및 표시
public class ScoreManager : MonoBehaviour
{
    public Text scoreUI;
    public Text topScoreUI;
    int _score = 0;
    int _topScore = 0;
    public int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            scoreUI.text = "Score : " + _score;
            if(_score > _topScore)
            {
                _topScore = _score;
                topScoreUI.text = "Top Score : " + _score;
                // 저장
                PlayerPrefs.SetInt("FlappyBird", _topScore);
            }
        }
    }

    public static ScoreManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        _topScore = PlayerPrefs.GetInt("FlappyBird", 0);
        topScoreUI.text = "Top Score : " + _topScore;
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
