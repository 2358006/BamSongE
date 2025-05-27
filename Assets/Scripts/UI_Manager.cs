using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    // 게임 시작 버튼
    public void GameStart()
    {
        SceneManager.LoadScene("GameScene");
    }

    // 메뉴 버튼
    public void Menu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    // 타이틀 메뉴 버튼
    public void TitleMenu()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
