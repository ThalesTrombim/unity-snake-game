using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
  public GameObject snakeHeadPrefab;
  public GameObject panelMenu;
  public SpawnFood spawnFood;
  private bool running;

  // Start is called before the first frame update
  void Start()
  {
    panelMenu.SetActive(true);
    running = false;
  }

  // Update is called once per frame
  void Update()
  {
    if(Input.GetKey(KeyCode.Space) && !running)
    {
      StartGame();
    }  
  }

  void StartGame()
  {
    panelMenu.SetActive(false);
    running = true;
    spawnFood.StartSpawnFood();
    Instantiate(snakeHeadPrefab, new Vector2(0f, 0f), Quaternion.identity);
  }
}
