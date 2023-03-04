using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public Vector2 vector2;
    public Skeleton skeleton;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 val;
        List<List<float>> listPosSkeleton = new List<List<float>>();
        listPosSkeleton.Add(new List<float> {17.47f, -9.447445f});
        listPosSkeleton.Add(new List<float> {-1.599999f, -9.447412f});
        listPosSkeleton.Add(new List<float> {48.63f, -17.44741f});

        var random = RandomGen.random;
        int index = random.Next(listPosSkeleton.Count);

        val.x = listPosSkeleton[index][0];
        val.y = listPosSkeleton[index][1];
        skeleton.transform.position = val;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 val;
        var xPos = skeleton.transform.position.x;
        var yPos = skeleton.transform.position.y;
        val.x = xPos;
        val.y = yPos;
        vector2 = val;
    }
}
