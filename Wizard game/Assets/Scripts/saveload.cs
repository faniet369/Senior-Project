using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveload : MonoBehaviour
{
    public PlayerController player;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)){
            Vector2 val;
            var xPos = player.transform.position.x;
            var yPos = player.transform.position.y;
            val.x = xPos;
            val.y = yPos;
            player.vector2 = val;
            PlayerPrefsJTA.SetVector2("PlayerV2", player.vector2);
        }
        if (Input.GetKeyDown(KeyCode.L)){
            player.vector2 = PlayerPrefsJTA.GetVector2("PlayerV2");
            player.transform.position = PlayerPrefsJTA.GetVector2("PlayerV2");
        }
    }
}
