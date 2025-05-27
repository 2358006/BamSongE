using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance { get; private set; } // 싱글톤

    public int score = 0; // 점수 
    public int haveBamsonge = 10; // 남은 횟수


    public Text scoreText; // 점수 텍스트
    public Text gameTurnText; // 게임 턴 텍스트

    public bool isShoot; // 슈팅 여부
    public bool isPlaying = true; // 게임 진행가능 여부

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
        score += 10;
        scoreText.text = $"Score : {score}";
    }

    // 턴 진행 
    public void GameTurn()
    {
        if (isPlaying)
        {
            haveBamsonge -= 1;
            gameTurnText.text = $"Turn : {haveBamsonge}";
        }

        if (haveBamsonge == 0)
        {
            isPlaying = false;
        }

        Invoke("LoadEndScene", 3f);
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
