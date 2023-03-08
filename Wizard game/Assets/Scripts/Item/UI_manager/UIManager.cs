using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void LoadGame()
    {
        //ถ้าทำหน้า Load แล้วค่อยมาแก้
        SceneManager.LoadScene("MainScene");
    }
}
