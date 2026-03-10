using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDManager : MonoBehaviour
{
    public static HUDManager instance;
    
    [SerializeField] private TextMeshProUGUI playername;
    [SerializeField] private TextMeshProUGUI currentScore;
    [SerializeField] private TextMeshProUGUI highscore;

    [SerializeField] private GameObject restartButton;

    private int score = 0;

    // ENCAPSULATION
    public int Score
    {
        get => score;
        set
        {
            score = value;
            SetScore(value);
            if (value > DataTransfer.instance.highestScore)
            {
                DataTransfer.instance.highestScore = value;
                DataTransfer.instance.highestScorePlayer = DataTransfer.instance.playerName;
            }
        }
    }
    
    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetHighScore(DataTransfer.instance.highestScorePlayer, DataTransfer.instance.highestScore);
        SetPlayer(DataTransfer.instance.playerName);
        SetScore(00);
        
        restartButton.gameObject.SetActive(false);
    }


    public void SetHighScore(string player, int score)
    {
        highscore.text = $"Highscore : {score} by {player}";
    }

    public void SetPlayer(string player)
    {
        playername.text = player;
    }

    public void SetScore(int score)
    {
        currentScore.text = score.ToString();
    }

    public void EnableRestart()
    {
        restartButton.SetActive(true);
    }

    // ABSTRACTION
    public void LoadScene(int id)
    {
        SceneManager.LoadScene(id);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
