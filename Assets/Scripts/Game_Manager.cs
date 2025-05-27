using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance { get; private set; } // 싱글톤

    public int extraPoint = 1;  // 점수
    public int Upgradedemand = 10;  // 업그레이드 요구량
    public int score = 0; // 점수 
    public int click = -0; // 남은 횟수

    public Text scoreText; // 점수 텍스트
    public Text gameTurnText; // 게임 턴 텍스트
    public Text upgradedemandText; // 업그레이드 요구 텍스트

    public bool isShoot; // 슈팅 여부
    public bool isPlaying = true; // 게임 진행가능 여부

    // 점수 업그레이드
    public void Upgrade()
    {
        if (score >= Upgradedemand)
        {
            extraPoint *= 2;
            score -= Upgradedemand;
            Upgradedemand += 10;
        }
    }

// UI 업데이트
    void FixedUpdate()
    {
        scoreText.text = $"Score : {score}";
        upgradedemandText.text = $"UpgradeDemand : {Upgradedemand}";
        gameTurnText.text = $"Click : {click}";
    }

    void Awake()
    {
        // 싱글톤 설정
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 점수 상승
    public void UpScore()
    {
        score += extraPoint;
        Debug.Log(score);
    }

    // 클릭횟수
    public void GameTurn()
    {
        if (isPlaying)
        {
            click++;
        }

        if (score >= 100)
        {
            isPlaying = false;
        }
        Invoke("LoadEndScene", 0.1f);
    }

    // 끝 씬 이동
    public void LoadEndScene()
    {
        if (!isPlaying)
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
