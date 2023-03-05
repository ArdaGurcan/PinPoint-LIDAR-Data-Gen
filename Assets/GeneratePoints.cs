using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class GeneratePoints : MonoBehaviour
{
  public List<Vector3> allPoints;
  int density = 100;
  public static bool cleared = false;

  void Awake()
  {
    if (!cleared)
    {
      cleared = true;
      File.WriteAllText("Assets/point_cloud.txt", "");
    }
    allPoints = new List<Vector3>();

    Vector3 s = transform.localScale;

    // front
    int pointCount = Mathf.RoundToInt(s.x * s.y * density);

    for (int i = 0; i < pointCount; i++)
    {
      float x = Random.Range(-s.x, s.x) / 2;
      float y = Random.Range(-s.y, s.y) / 2;

      Vector3 localPosition = new Vector3(x, y, s.z / 2);

      allPoints.Add(transform.position + transform.rotation * localPosition + Noise());
    }

    // back
    pointCount = Mathf.RoundToInt(s.x * s.y * density);

    for (int i = 0; i < pointCount; i++)
    {
      float x = Random.Range(-s.x, s.x) / 2;
      float y = Random.Range(-s.y, s.y) / 2;

      Vector3 localPosition = new Vector3(x, y, -s.z / 2);
      allPoints.Add(transform.position + transform.rotation * localPosition + Noise());
    }

    // right
    pointCount = Mathf.RoundToInt(s.z * s.y * density);

    for (int i = 0; i < pointCount; i++)
    {
      float z = Random.Range(-s.z, s.z) / 2;
      float y = Random.Range(-s.y, s.y) / 2;

      Vector3 localPosition = new Vector3(s.x / 2, y, z);

      allPoints.Add(transform.position + transform.rotation * localPosition + Noise());
    }

    // left
    pointCount = Mathf.RoundToInt(s.z * s.y * density);

    for (int i = 0; i < pointCount; i++)
    {
      float z = Random.Range(-s.z, s.z) / 2;
      float y = Random.Range(-s.y, s.y) / 2;

      Vector3 localPosition = new Vector3(-s.x / 2, y, z);

      allPoints.Add(transform.position + transform.rotation * localPosition + Noise());
    }
    WriteToFile();
  }

  Vector3 Noise()
  {
    float deg = 0.2f;
    return new Vector3(Random.Range(0, deg) - deg / 2, Random.Range(0, deg) - deg / 2, Random.Range(0, deg) - deg / 2);
  }

  void WriteToFile()
  {
    string path = "Assets/point_cloud.txt";
    string output = System.String.Join('\n', allPoints.ToArray());
    File.AppendAllText(path, output + '\n');
  }
}
