using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
  public Transform border_top;
  public Transform border_bottom;
  public Transform border_left;
  public Transform border_right;

  public GameObject prefabFood;

  // Start is called before the first frame update
  void Start()
  {
    
  }

  // Update is called once per frame
  void Update()
  {
        
  }

  void Spawn()
  {
    int x = (int)Random.Range(border_left.position.x, border_right.position.x);
    int y = (int)Random.Range(border_top.position.y, border_bottom.position.y);

    Instantiate(prefabFood, new Vector2(x, y), Quaternion.identity);
  }

  public void StartSpawnFood()
  {
    InvokeRepeating("Spawn", 3, 4);
  }
}
