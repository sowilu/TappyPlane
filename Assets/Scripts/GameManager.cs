using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Spawner spawner;
    public AudioSource music;

    public int Score
    {
        get => score;
        set
        {
            score = value;
            UiManager.Instance.SetScore(score);
            LevelUp();
        }
    }

    private int score = 0;
    private IPausable[] pausables;
    private bool endGame = false;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Scroller.SpeedMultiplier = 1;
        Score = 0;
        endGame = false;

        FindPausables();
        Pause();
    }


    private void LevelUp()
    {
        if (spawner.cooldown > 0.8f)
            spawner.cooldown -= 0.01f;

        Scroller.SpeedMultiplier += 0.04f;
        music.pitch = Mathf.Min(music.pitch + 0.003f, 3);
    }

    public void End(float delay = 0.5f)
    {
        if (!endGame)
        {
            endGame = true;
            Invoke(nameof(ShowScore), delay);
        }
    }

    private void ShowScore()
    {
        Pause();
        UiManager.Instance.ShowScoreBoard(Score);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Pause()
    {
        foreach (var p in pausables)
            p.OnPause();
    }

    public void Resume()
    {
        foreach (var p in pausables)
        {
            if (p != null)
                p.OnResume();
        }
    }

    private void FindPausables()
    {
        pausables = FindObjectsOfType<MonoBehaviour>(true)
            .OfType<IPausable>()
            .ToArray();
    }
}