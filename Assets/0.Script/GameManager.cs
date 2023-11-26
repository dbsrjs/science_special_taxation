using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public int timeSize = 1;

    void Update()
    {
        Time.timeScale = timeSize;
    }

    public void GameStart() //게임 시작
    {
        timeSize = 1;
    }

    public void GameStop()  //게임 정지
    {
        timeSize = 0;
    }
}
