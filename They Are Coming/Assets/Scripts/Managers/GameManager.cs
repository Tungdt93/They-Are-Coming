using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : Manager<GameManager>, ISubcribers
{
    public static int sceneIndex = 0;

    public event Action<int> OnGameStarted = delegate { };
    public event Action OnLevelCompleted = delegate { };
    public event Action OnGameOver = delegate { };

    [SerializeField] private GameObject bulletStorgage;
    [SerializeField] private EnemySpawner[] enemySpawners;
    [SerializeField] private CameraFollow cameraFollow;

    private UIManager uiManager;
    private PlayerMain playerMain;
    private int[] currentEnemies;
    private int totalEnemies;
    private int currentLevel;
    private bool onStartedGame;
    private bool stopFiring;
    private bool reachedFinishLine;
    private bool gameStarted;
    private bool levelCompleted;
    private bool gameOver;

    public GameObject BulletStorgage { get => bulletStorgage; set => bulletStorgage = value; }
    public bool StopFiring { get => stopFiring; set => stopFiring = value; }
    public bool GameStarted { get => gameStarted; set => gameStarted = value; }
    public bool LevelCompleted { get => levelCompleted; set => levelCompleted = value; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
        InitializeVariables();
    }

    private void OnEnable()
    {
        SubscribeEvent();
    }

    private void OnDisable()
    {
        UnsubscribeEvent();
    }

    private void Update()
    {
        CheckCurrentEnemies();
        CheckFinalResult();
        GameState();
    }

    public override void InitializeVariables()
    {     
        currentEnemies = new int[enemySpawners.Length];
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        uiManager = UIManager.Instance;
        playerMain = PlayerMain.Instance;
        onStartedGame = true;
        stopFiring = false;
        reachedFinishLine = false;
        gameStarted = true;
        levelCompleted = false;
        gameOver = false;
    }

    public void SubscribeEvent()
    {
        playerMain.OnReachedFinishLine += PlayerReachedFinishLine;
        playerMain.OnOutOfMinions += GameOver;
    }

    private void CheckCurrentEnemies()
    {
        for (int i = 0; i < enemySpawners.Length; i++)
        {
            currentEnemies[i] = enemySpawners[i].NumberOfEnemies;
        }
        totalEnemies = 0;
        for (int i = 0; i < currentEnemies.Length; i++)
        {
            totalEnemies += currentEnemies[i];
        }
    }

    public void UnsubscribeEvent()
    {
        playerMain.OnReachedFinishLine -= PlayerReachedFinishLine;
        playerMain.OnOutOfMinions -= GameOver;
    }

    public override void InitializeSingleton()
    {
       
    }

    private void PlayerReachedFinishLine(GameObject[] gameObjects)
    {
        reachedFinishLine = true;
        foreach (EnemySpawner spawner in enemySpawners)
        {
            spawner.IsSpawning = false;
        }
        cameraFollow.MoveSpeed = 0f;
    }

    private void CheckFinalResult()
    {
        if (gameStarted && reachedFinishLine)
        {
            if (playerMain.NumberOfMinions > 0 && totalEnemies == 0)
            {
                levelCompleted = true;
                stopFiring = true;
            }

            if (playerMain.NumberOfMinions <= 0 && totalEnemies > 0)
            {
                gameOver = true;
            }
        }
       
    }

    private void GameState()
    {
        if (onStartedGame)
        {
            OnGameStarted?.Invoke(currentLevel);
            onStartedGame = false;
        }
        

        if (levelCompleted)
        {
            gameStarted = false;
            OnLevelCompleted?.Invoke();
            levelCompleted = false;
        }

        if (gameOver)
        {
            gameStarted = false;
            OnGameOver?.Invoke();
            gameOver = false;
        }
    }

    private void GameOver()
    {
        foreach (EnemySpawner spawner in enemySpawners)
        {
            spawner.IsSpawning = false;
        }
        cameraFollow.MoveSpeed = 0f;
        gameOver = true;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        sceneIndex++;
        if (sceneIndex > SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            PlayerPrefs.SetInt("CurrentLevel", currentLevel + 1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
