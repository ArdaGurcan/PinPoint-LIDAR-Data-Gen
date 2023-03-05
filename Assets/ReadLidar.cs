using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class ReadLidar
{
  public static List<Vector3> allPoints;

  public static Vector3 StringToVector3(string sVector)
  {
    // Remove the parentheses
    if (sVector.StartsWith("(") && sVector.EndsWith(")"))
    {
      sVector = sVector.Substring(1, sVector.Length - 2);
    }

    // split the items
    string[] sArray = sVector.Split(',');

    // store as a Vector3
    Vector3 result = new Vector3(
        float.Parse(sArray[0]),
        float.Parse(sArray[1]),
        float.Parse(sArray[2]));

    return result;
  }

  static void ReadData()
  {
    string path = "Assets/point_cloud.txt";
    StreamReader sr = new StreamReader(path);
    while (!sr.EndOfStream)
    {
      string line = sr.ReadLine();
      string[] Splitted = line.Split('\n', System.StringSplitOptions.RemoveEmptyEntries);
      allPoints.Add(StringToVector3(line));
    }
    Debug.Log(allPoints[2]);
  }

  static void OnDrawGizmos()
  {
    if (Application.isPlaying && allPoints != null)
    {
      foreach (Vector3 point in allPoints)
      {
        Gizmos.color = Color.red;

        Gizmos.DrawIcon(point, "dot.png", true);
      }
    }
  }

  public static void Run()
  {
    allPoints = new List<Vector3>();
    ReadData();

  }

}
