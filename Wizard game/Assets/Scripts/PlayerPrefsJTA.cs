using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;
//using UnityEngine.UI;

public static class PlayerPrefsJTA
{
    //public GameObject player;
    //public TextMeshProUGUI helperText;

    // Start is called before the first frame update
    // void Start()
    // {
    //     //LoadPosition();
    // }

    public static void SetVector2(string key, Vector2 val) {
        string x = key + "V2X";
        string y = key + "V2Y";
        PlayerPrefs.SetFloat(x, val.x);
        PlayerPrefs.SetFloat(y, val.y);
    }

    public static Vector2 GetVector2(string key) {
        Vector2 val;
        string x = key + "V2X";
        string y = key + "V2Y";
        val.x = PlayerPrefs.GetFloat(x);
        val.y = PlayerPrefs.GetFloat(y);
        return val;
    }


    // public void save()
    // {
    //     var xPos = player.transform.position.x;
    //     var yPos = player.transform.position.y;
    //     PlayerPrefs.SetFloat("X", xPos);
    //     PlayerPrefs.SetFloat("Y", yPos);
    //     PlayerPrefs.Save();
    //     //helperText.text = "player position saved";
    // }

    // public void LoadPosition()
    // {
    //     player.transform.position = new Vector2(PlayerPrefs.GetFloat("X"), PlayerPrefs.GetFloat("Y"));
    //     helperText.text = "player position loaded";
    // }
}
