using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequencer : MonoBehaviour
{
  void Start()
  {
    ReadLidar.Run();
    GroupPoints.Run();
  }

  void OnDrawGizmos()
  {
    Gizmos.DrawCube(Vector3.zero, Vector3.one * GroupPoints.count * GroupPoints.sideLength);
if (Application.isPlaying && ReadLidar.allPoints != null)
    {
      foreach (Vector3 point in ReadLidar.allPoints)
      {
        Gizmos.color = Color.red;

        Gizmos.DrawIcon(point, "dot.png", true);
      }
    }

    // Gizmos.DrawCube(Vector3.zero, GroupPoints.sideLength * GroupPoints.count * Vector3.one);
    if (GroupPoints.grid != null)
    {
        int i = 0;
      for (var x = -GroupPoints.count / 2f * GroupPoints.sideLength; x < GroupPoints.count / 2f * GroupPoints.sideLength; x += GroupPoints.sideLength)
      {
          int j = 0;
        for (var z = -GroupPoints.count / 2f * GroupPoints.sideLength; z < GroupPoints.count / 2f * GroupPoints.sideLength; z += GroupPoints.sideLength)
        {
          Debug.Log(GroupPoints.grid[i][j]);
          if (GroupPoints.grid[i][j] > 10)
            Gizmos.DrawCube(new Vector3(x + GroupPoints.sideLength / 2, 0, z + GroupPoints.sideLength/2), GroupPoints.sideLength * Vector3.one );
          ++j;
        }
        ++i;
      }
    }
  }
}

