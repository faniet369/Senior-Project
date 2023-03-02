using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowers : MonoBehaviour
{
    public Vector2 vector2;
    public Flowers flowers;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 val;
        // var xPos = flowers.transform.localPosition.x;
        // var yPos = flowers.transform.localPosition.y;
        // val.x = xPos;
        // val.y = yPos;
        // vector2 = val;
        List<List<float>> listPosFlowers = new List<List<float>>();
        listPosFlowers.Add(new List<float> {-0.67f, 0.0f});
        listPosFlowers.Add(new List<float> {-1.912f, 0.0f});
        listPosFlowers.Add(new List<float> {0.0f, 0.0f});

        var random = new System.Random();
        int index = random.Next(listPosFlowers.Count);

        val.x = listPosFlowers[index][0];
        val.y = listPosFlowers[index][1];
        vector2 = val;
        flowers.transform.localPosition = val;
    }
}
