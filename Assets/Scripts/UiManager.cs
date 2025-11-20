using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance;

    [Header("Score")] [SerializeField] private TextMeshProUGUI scoreText;

    [Header("Restarer")] [SerializeField] private GameObject restarer;

    [Header("Score Board")] [SerializeField]
    private GameObject scoreBoard;

    [SerializeField] private TextMeshProUGUI finalText;
    [SerializeField] private TextMeshProUGUI bestText;
    [SerializeField] private Image medalImage;
    [SerializeField] private Sprite[] medalSprite;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        scoreBoard.SetActive(false);
        restarer.SetActive(false);
    }

    public void SetScore(int score)
    {
        scoreText.transform.DOKill();
        scoreText.text = score.ToString();
        scoreText.transform.DOScale(Vector3.one, 0.3f)
            .ChangeStartValue(Vector3.one * 1.3f)
            .SetEase(Ease.OutBounce);
    }

    public void ShowScoreBoard(int score)
    {
        scoreBoard.SetActive(true);

        scoreBoard.transform.DOScale(Vector3.one, 0.3f)
            .ChangeStartValue(Vector3.one * 1.3f)
            .SetEase(Ease.OutBounce);

        var best = PlayerPrefs.GetInt("Best", 0);
        var secondBest = PlayerPrefs.GetInt("SecondBest", 0);

        finalText.text = $"Score: {score}";
        bestText.text = $"Best: {best}";
        medalImage.sprite = medalSprite[2];

        if (score >= best)
        {
            PlayerPrefs.SetInt("Best", score);
            bestText.text = $"Best: {score}";
            medalImage.sprite = medalSprite[0];
        }
        else if (score >= secondBest)
        {
            PlayerPrefs.SetInt("SecondBest", score);
            medalImage.sprite = medalSprite[1];
        }

        PlayerPrefs.Save();
        Invoke(nameof(ShowRestarter), 3);
    }

    private void ShowRestarter()
    {
        restarer.SetActive(true);
    }
}