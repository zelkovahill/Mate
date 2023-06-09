using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public PlayerController player;
    public int maxLives = 3;

    private int currentLives;

    private void Start()
    {
        currentLives = maxLives;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }

        if (currentLives <= 0)
        {
            // 게임 오버 로직
            GameOver();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            // 게임 재시작 로직
            RestartGame();
        }
    }

    public void DecreaseLives()
    {
        currentLives--;
    }

    private void GameOver()
    {
        // 게임 오버 상태로 변경하는 로직 작성
        Debug.Log("Game Over!");
    }

    private void RestartGame()
    {
        // 3초 후에 씬을 이동하는 코루틴 시작
        StartCoroutine(RestartWithDelay());
        
    }

    private System.Collections.IEnumerator RestartWithDelay()
    {
        // 게임 일시 정지
        Time.timeScale = 0f;

        yield return new WaitForSecondsRealtime(0f); // 3초 대기 (실제 시간 기준)

        // 씬 재로드
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // 게임 재개
        Time.timeScale = 1f;
    }

    private bool isPaused = false;

    private void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
        // 포즈 상태에 맞게 추가 동작 수행
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;
        // 포즈 상태 해제에 맞게 추가 동작 수행
    }
}