using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
  public GameObject snakeHeadPrefab;
  public GameObject panelMenu;
  public GameObject panelGameOver;
  public SpawnFood spawnFood;
  private bool running;

  public Text scoreGame;
  public Text scoreGameOver;

  private int score;

  // Start is called before the first frame update
  void Start()
  {
    panelMenu.SetActive(true);
    panelGameOver.SetActive(false);
    running = false;
  }

  // Update is called once per frame
  void Update()
  {
    if(Input.GetKey(KeyCode.Space) && !running)
    {
      StartGame();
    }
    scoreGame.text = "SCORE: " + score.ToString();
  }

  void StartGame()
  {
    panelMenu.SetActive(false);
    running = true;
    scoreGame.text = "SCORE: 0";
    score = 0;
    spawnFood.StartSpawnFood();
    Instantiate(snakeHeadPrefab, new Vector2(0f, 0f), Quaternion.identity);
  }

  public void GameOver()
  {
    //snakeHeadPrefab.SetActive(false);
    panelGameOver.SetActive(true);
    scoreGameOver.text = "SCORE: " + score.ToString();
    Invoke("RestartGame", 5);
  }

  public void RestartGame()
  {
    SceneManager.LoadScene("Main");
  }

  public void IncScore()
  {
    score += 10;
  }
}
