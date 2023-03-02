using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public Vector2 vector2;
    public Heart heart;
    
    // Start is called before the first frame update
    void Start()
    {
        Vector2 val;
        // var xPos = heart.transform.position.x;
        // var yPos = heart.transform.position.y;
        // val.x = xPos;
        // val.y = yPos;
        // heart.vector2 = val;
        List<List<float>> listPosHeart = new List<List<float>>();
        listPosHeart.Add(new List<float> {0.0005057454f, 0.1393254f});
        listPosHeart.Add(new List<float> {-2.372f, 0.132f});
        listPosHeart.Add(new List<float> {-0.7434942f, 0.7533255f});

        var random = new System.Random();
        int index = random.Next(listPosHeart.Count);

        val.x = listPosHeart[index][0];
        val.y = listPosHeart[index][1];
        vector2 = val;
        heart.transform.position = val;
    }
}
