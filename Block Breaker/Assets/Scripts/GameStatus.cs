using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int currentScore = 0;
    [SerializeField] int oneHitBreakable = 5;
    [SerializeField] int twoHitBreakable = 10;
    [SerializeField] int threeHitBreakable = 15;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPayEnabled;
        
    Block block;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        scoreText.text = currentScore.ToString();
    }

    public void IncreaseScore()
    {
        currentScore = currentScore + 5;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
     
    public bool IsAutoPlayEnabled()
    {
        return isActiveAndEnabled;
    }
}
