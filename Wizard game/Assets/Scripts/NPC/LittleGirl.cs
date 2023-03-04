using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleGirl : MonoBehaviour
{
    public Vector2 vector2;
    public LittleGirl littleGirl;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 val;
        List<List<float>> listPosLittleGirl = new List<List<float>>();
        listPosLittleGirl.Add(new List<float> {100.742f, -0.7117774f});
        listPosLittleGirl.Add(new List<float> {18.478f, -1.711783f});
        listPosLittleGirl.Add(new List<float> {-6.642f, -1.711736f});

        var random = RandomGen.random;
        int index = random.Next(listPosLittleGirl.Count);

        val.x = listPosLittleGirl[index][0];
        val.y = listPosLittleGirl[index][1];
        littleGirl.transform.position = val;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 val;
        var xPos = littleGirl.transform.position.x;
        var yPos = littleGirl.transform.position.y;
        val.x = xPos;
        val.y = yPos;
        vector2 = val;
    }
}
