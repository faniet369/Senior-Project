using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenMemorypiece : MonoBehaviour
{
    public Vector2 vector2;
    public GameObject memorypiece1;
    public GameObject memorypiece2;
    public GameObject memorypiece3;
    public GameObject memorypiece4;
    public GameObject memorypiece5;
    public GameObject memorypiece6;
    public GameObject memorypiece7;
    // public GameObject memorypiece8;
    // public GameObject memorypiece9;
    public GameObject memorypiece10;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 val;
        List<List<float>> listPosMemorypiece = new List<List<float>>();
        listPosMemorypiece.Add(new List<float> {12f, 1.4f});
        listPosMemorypiece.Add(new List<float> {26.41f, -7.64f});
        listPosMemorypiece.Add(new List<float> {-5f, -9.54f});
        listPosMemorypiece.Add(new List<float> {42.49f, -13.5f});
        listPosMemorypiece.Add(new List<float> {61.67f, -12.53f});
        listPosMemorypiece.Add(new List<float> {90.03f, -6.54f});
        listPosMemorypiece.Add(new List<float> {75.43f, 8.42f});
        listPosMemorypiece.Add(new List<float> {109.391f, -0.237f});
        listPosMemorypiece.Add(new List<float> {7.57f, -0.58f});
        listPosMemorypiece.Add(new List<float> {11.51f, -9.7f});
        listPosMemorypiece.Add(new List<float> {25.85f, 2.32f});
        listPosMemorypiece.Add(new List<float> {45.33f, -0.64f});
        listPosMemorypiece.Add(new List<float> {60.91f, 6.98f});
        listPosMemorypiece.Add(new List<float> {51.58f, -8.719999f});
        listPosMemorypiece.Add(new List<float> {56.55f, -12.1f});
        listPosMemorypiece.Add(new List<float> {87.58f, 10.12f});
        listPosMemorypiece.Add(new List<float> {98.67f, 0.83f});
        listPosMemorypiece.Add(new List<float> {31.64f, 0.58f});

        List<GameObject> listMemorypiece = new List<GameObject>();
        listMemorypiece.Add(memorypiece1);
        listMemorypiece.Add(memorypiece2);
        listMemorypiece.Add(memorypiece3);
        listMemorypiece.Add(memorypiece4);
        listMemorypiece.Add(memorypiece5);
        listMemorypiece.Add(memorypiece6);
        listMemorypiece.Add(memorypiece7);
        // listMemorypiece.Add(memorypiece8);
        // listMemorypiece.Add(memorypiece9);
        listMemorypiece.Add(memorypiece10);

        var random = RandomGen.random;
        for (int i = 0; i < 8; i++) { //เดี๋ยวต้องแก้เป็น 10
            int index = random.Next(listPosMemorypiece.Count);
            val.x = listPosMemorypiece[index][0];
            val.y = listPosMemorypiece[index][1];
            listPosMemorypiece.RemoveAt(index);
            listMemorypiece[i].transform.position = val;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Vector2 val;
        // var xPos = memorypiece1.transform.position.x;
        // var yPos = memorypiece1.transform.position.y;
        // val.x = xPos;
        // val.y = yPos;
        // vector2 = val;
    }
}
