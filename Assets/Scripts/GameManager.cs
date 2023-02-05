using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int level = 0;
    public int score = 0;
    public int lives = 3;

    public Ball ball { get; private set; }
    public Paddle paddle { get; private set; }
    public Brick[] bricks { get; private set; }

    public Text scoreNLives { get; private set; }

    public SoundManager soundManager { get; private set; }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    private void Start()
    {
        this.soundManager = FindObjectOfType<SoundManager>();
    }

    public void NewGame()
    {
        this.score = 0;
        this.lives = 3;

        LoadLevel(0);
    }

    private void LoadLevel(int level)
    {
        this.level= level;

        if (this.lives < 3)
            this.lives++;

        SceneManager.LoadScene("Level" + (level % 7 + 1));
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        this.ball = FindObjectOfType<Ball>();
        this.paddle = FindObjectOfType<Paddle>();
        this.bricks = FindObjectsOfType<Brick>();
        this.scoreNLives = FindObjectOfType<Text>();
    }

    private void ResetLevel()
    {
        this.ball.ResetBall();
        this.paddle.ResetPaddle();
    }

    private void GameOver()
    {
        SceneManager.LoadScene("EndGame");
    }

    public void UpdateScore()
    {
        this.scoreNLives.text = "Level : " + (this.level + 1) + "  -  Score : " + this.score + "  -  Lives : " + this.lives;
    }

    public void Miss()
    {
        this.soundManager.PlayLoseOneLife();

        this.lives--;
        UpdateScore();

        if (this.lives > 0)
            ResetLevel();
        else
            GameOver();
    }

    public void Hit(Brick brick)
    {
        this.score += brick.points;
        UpdateScore();
        if (Cleared())
        {
            LoadLevel(this.level + 1);
        }
    }

    private bool Cleared()
    {
        for (int i = 0; i < this.bricks.Length; i++)
        {
            if (this.bricks[i].gameObject.activeInHierarchy && !this.bricks[i].unbreakable)
            {
                return false;
            }
        }
        return true;
    }
}
