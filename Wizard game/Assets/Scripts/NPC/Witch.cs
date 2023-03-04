using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witch : MonoBehaviour
{
    public Vector2 vector2;
    public Witch witch;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 val;
        List<List<float>> listPosWitch = new List<List<float>>();
        listPosWitch.Add(new List<float> {60.3f, -1.615153f});
        listPosWitch.Add(new List<float> {0.2000008f, -1.615131f});
        listPosWitch.Add(new List<float> {82.53f, -2.615141f});

        var random = RandomGen.random;
        int index = random.Next(listPosWitch.Count);

        val.x = listPosWitch[index][0];
        val.y = listPosWitch[index][1];
        witch.transform.position = val;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 val;
        var xPos = witch.transform.position.x;
        var yPos = witch.transform.position.y;
        val.x = xPos;
        val.y = yPos;
        vector2 = val;
    }
}
