using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
  Vector2 dir = Vector2.right;

  bool ate = false;

  public GameObject prefabTail;

  List<Transform> tail = new List<Transform>();

  GameObject gameController;
  private float speed;
  private float startTime;

  void Start()
  {
    gameController = GameObject.FindGameObjectWithTag("GameController");
    //InvokeRepeating("Move", 0.3f, 0.3f);
    speed = 0.3f;
    startTime = Time.time;
    StartCoroutine(nameof(NewMove));
  }

  // Update is called once per frame
  void Update()
  {
    if ((Input.GetKey(KeyCode.RightArrow)) && (dir != Vector2.left))
      dir = Vector2.right;
    else if ((Input.GetKey(KeyCode.LeftArrow)) && (dir != Vector2.right))
      dir = Vector2.left;
    else if ((Input.GetKey(KeyCode.DownArrow)) && (dir != Vector2.up))
      dir = Vector2.down;
    else if ((Input.GetKey(KeyCode.UpArrow)) && (dir != Vector2.down))
      dir = Vector2.up;
  }

  void Move()
  {
    Vector2 v = transform.position;
    Debug.Log("Teste");
    transform.Translate(dir);

    if (ate)
    {
      // Cria a cauda
      GameObject g = (GameObject)Instantiate(prefabTail, v, Quaternion.identity);
      // Define o elemento com inicio da cauda
      tail.Insert(0, g.transform);
      ate = false;
    }
    else if (tail.Count > 0)
    {
      // muda a coordenada de tela do elemento
      tail[tail.Count - 1].position = v;
      tail.Insert(0, tail[tail.Count - 1]);
      tail.RemoveAt(tail.Count - 1);
    }
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.name.StartsWith("Food"))
    {
      ate = true;
      Destroy(collision.gameObject);
      gameController.GetComponent<GameController>().IncScore();
    }
    else
    {
      gameController.GetComponent<GameController>().GameOver();
    }
  }

  private IEnumerator NewMove()
  {
    while (true)
    {
      Move();
      Debug.Log("Teste" + speed);
      yield return new WaitForSeconds(speed);
      if (Time.time - startTime > 10)
      {
        if (speed > 0.03) speed -= 0.01f;
        startTime = Time.time;
      }
    }
  }
}
