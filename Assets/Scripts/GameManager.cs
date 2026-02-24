using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private float GameSpeed = 5f;
    [SerializeField] private float speedIncrease = 0.15f;
    [SerializeField] private TextMeshProUGUI scoreText;
    private float score = 0;

    [SerializeField] private GameObject scoreTextObject;
    [SerializeField] private GameObject gameStartMess;
    [SerializeField] private GameObject gameOverMess;
    private bool isGameOver = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public float GetGameSpeed()
    {
        return GameSpeed;
    }
    void Start()
    {
        StartGame();
    }

    
    void Update()
    {
        HandleStartGameInput();
        
        if (!isGameOver)
        {
            UpdateGameSpeed();
            UpdateScore();
        }

    }
    public void UpdateGameSpeed()
    {
        GameSpeed += Time.deltaTime * speedIncrease;
    }
    public void UpdateScore()
    {
        score += Time.deltaTime * 10;
        scoreText.text = "Score: " + Mathf.FloorToInt(score);
    }
    public void StartGame()
    {
        Time.timeScale = 0f;
        scoreTextObject.SetActive(false);
        gameStartMess.SetActive(true);
        gameOverMess.SetActive(false);
    }
    public void HandleStartGameInput()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Time.timeScale = 1f;
            scoreTextObject.SetActive(true);
            gameStartMess.SetActive(false);
            
        }
    }
    public void GameOver()
    {
        isGameOver = true;
        gameOverMess.SetActive(true);
        Time.timeScale = 0f;
        StartCoroutine(ReloadScene());

    }
    private IEnumerator ReloadScene()
    {
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
