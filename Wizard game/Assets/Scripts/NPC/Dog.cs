using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public Vector2 vector2;
    public Dog dog;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 val;
        List<List<float>> listPosDog = new List<List<float>>();
        listPosDog.Add(new List<float> {71.34f, 8.232492f});
        listPosDog.Add(new List<float> {95.68f, -0.7675135f});
        listPosDog.Add(new List<float> {54.51f, -15.7675f});

        var random = RandomGen.random;
        int index = random.Next(listPosDog.Count);

        val.x = listPosDog[index][0];
        val.y = listPosDog[index][1];
        dog.transform.position = val;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 val;
        var xPos = dog.transform.position.x;
        var yPos = dog.transform.position.y;
        val.x = xPos;
        val.y = yPos;
        vector2 = val;
    }
}
