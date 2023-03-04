using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huntress : MonoBehaviour
{
    public Vector2 vector2;
    public Huntress huntress;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 val;
        List<List<float>> listPosHuntress = new List<List<float>>();
        listPosHuntress.Add(new List<float> {39.08f, -3.606179f});
        listPosHuntress.Add(new List<float> {63.15f, -1.606168f});
        listPosHuntress.Add(new List<float> {68.3f, -12.60617f});

        var random = RandomGen.random;
        int index = random.Next(listPosHuntress.Count);

        val.x = listPosHuntress[index][0];
        val.y = listPosHuntress[index][1];
        huntress.transform.position = val;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 val;
        var xPos = huntress.transform.position.x;
        var yPos = huntress.transform.position.y;
        val.x = xPos;
        val.y = yPos;
        vector2 = val;
    }
}
