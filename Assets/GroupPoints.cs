using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GroupPoints
{
  public static float count = 2;
  public static float sideLength = .5f;
  public static List<List<int>> grid;

  public static void Run()
  {}

  public static bool btwn(Vector3 point, Vector3 min, Vector3 max)
  {
    return
      point.x > min.x &&
      point.z > min.z &&
      point.x < max.x &&
      point.z < max.z;
  }
}
