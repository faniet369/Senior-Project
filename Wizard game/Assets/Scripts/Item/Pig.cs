using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{
    public Vector2 vector2;
    public Pig pig;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 val;
        List<List<float>> listPosPig = new List<List<float>>();
        listPosPig.Add(new List<float> {37.02f, -12.75658f});
        listPosPig.Add(new List<float> {54.2f, -9.757277f});
        listPosPig.Add(new List<float> {87.35423f, -4.757113f});

        var random = RandomGen.random;
        int index = random.Next(listPosPig.Count);

        val.x = listPosPig[index][0];
        val.y = listPosPig[index][1];
        pig.transform.position = val;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 val;
        var xPos = pig.transform.position.x;
        var yPos = pig.transform.position.y;
        val.x = xPos;
        val.y = yPos;
        vector2 = val;
    }
}
