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

    [SerializeField]
    public Text scoreNLives { get; private set; }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        this.score = 0;
        this.lives = 3;

        LoadLevel(0);
    }

    private void LoadLevel(int level)
    {
        this.level= level;

        SceneManager.LoadScene("Level" + (level % 5 + 1));
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
        NewGame();
    }

    public void UpdateScore()
    {
        this.scoreNLives.text = "Score : " + this.score + "  -  Lives : " + this.lives;
    }

    public void Miss()
    {
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
