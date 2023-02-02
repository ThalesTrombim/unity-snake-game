using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
  Vector2 dir = Vector2.right;

  bool ate = false;

  public GameObject prefabTail;

  List<Transform> tail = new List<Transform>();

  // Start is called before the first frame update
  void Start()
  {
    InvokeRepeating("Move", 0.3f, 0.3f);
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

    transform.Translate(dir);

    if (ate)
    {
      GameObject g = (GameObject)Instantiate(prefabTail, v, Quaternion.identity);
      tail.Insert(0, g.transform);
      ate = false;
    }
    else if (tail.Count > 0)
    {
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
    }
    else
    {
      // End game
      Debug.Log("Morreu");
    }
  }
}
