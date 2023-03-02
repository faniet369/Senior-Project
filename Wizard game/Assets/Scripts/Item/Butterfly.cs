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
        var xPos = butterfly.transform.position.x;
        var yPos = butterfly.transform.position.y;
        val.x = xPos;
        val.y = yPos;
        vector2 = val;
        List<List<float>> listPosButterfly = new List<List<float>>();
        listPosButterfly.Add(new List<float> {1f, 0.632f});
        listPosButterfly.Add(new List<float> {0.4825057f, 0.8313255f});
        listPosButterfly.Add(new List<float> {1f, 1.322325f});

        var random = new System.Random();
        int index = random.Next(listPosButterfly.Count);

        val.x = listPosButterfly[index][0];
        val.y = listPosButterfly[index][1];
        vector2 = val;
        butterfly.transform.position = val;
    }
}
