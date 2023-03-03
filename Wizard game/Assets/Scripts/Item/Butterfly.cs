using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly : MonoBehaviour
{
    public Vector2 vector2;
    public Butterfly butterfly;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 val;
        List<List<float>> listPosButterfly = new List<List<float>>();
        listPosButterfly.Add(new List<float> {-6.96f, -1.38f});
        listPosButterfly.Add(new List<float> {36.25f, -3.52f});
        listPosButterfly.Add(new List<float> {74.78f, -2.49f});

        var random = RandomGen.random;
        int index = random.Next(listPosButterfly.Count);

        val.x = listPosButterfly[index][0];
        val.y = listPosButterfly[index][1];
        butterfly.transform.position = val;
    }

    void Update() {
        Vector2 val;
        var xPos = butterfly.transform.position.x;
        var yPos = butterfly.transform.position.y;
        val.x = xPos;
        val.y = yPos;
        vector2 = val;
    }
}
