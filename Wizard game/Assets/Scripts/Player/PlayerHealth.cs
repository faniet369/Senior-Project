using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static int health = 3;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Start()
    {
        health = 3;
    }

    public void AddHealth(int number) {
        if (health + number <= 3) {
            health = health + number;
        }
        else {
            health = 3;
        }
    }

    public void ReduceHealth(int number) {
        if (health - number >= 0) {
            health = health + number;
        }
        else {
            health = 0;
        }
    }

    void Update()
    {
        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }
        for (int i = 0; i < health; i++)
        {
            hearts[i].sprite = fullHeart;
        }
    }
}
