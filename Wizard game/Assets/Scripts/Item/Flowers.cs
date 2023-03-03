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
        List<List<float>> listPosFlowers = new List<List<float>>();
        listPosFlowers.Add(new List<float> {98.85f, -0.266f});
        listPosFlowers.Add(new List<float> {16.001f, -1.263f});
        listPosFlowers.Add(new List<float> {72.258f, -2.26f});

        var random = RandomGen.random;
        int index = random.Next(listPosFlowers.Count);

        val.x = listPosFlowers[index][0];
        val.y = listPosFlowers[index][1];
        flowers.transform.position = val;
    }

    void Update() {
        Vector2 val;
        var xPos = flowers.transform.position.x;
        var yPos = flowers.transform.position.y;
        val.x = xPos;
        val.y = yPos;
        vector2 = val;
    }
}
