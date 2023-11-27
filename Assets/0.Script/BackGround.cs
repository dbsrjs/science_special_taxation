using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] private Transform[] skyTs; //slow
    [SerializeField] private Transform[] cloudTs;
    [SerializeField] private Transform[] backTs;
    [SerializeField] private Transform[] cactusTs;
    [SerializeField] private Transform[] groundTs;  //fast

    private float skySpeed = 3f;
    private float cloudSpeed = 3f;
    private float backSpeed = 4f;
    private float cactusSpeed = 4.5f;
    private float groundpeed = 5f;

    private float lastPos = -14f;    //끝 값
    private float initPos = 45f;    //시작 값

    void Update()
    {
        if (Time.timeScale != 0)
        {
            Move();
        }
    }

    public void Move()
    {
        foreach (var item in skyTs)
        {
            BGMove(item, skySpeed, 0);    //-1f
        }
        
        foreach (var item in cloudTs)
        {
            BGMove(item, cloudSpeed, 0);    //1.71f
        }

        foreach (var item in backTs)
        {
            BGMove(item, backSpeed, 0f);
        }
        
        foreach (var item in cactusTs)
        {
            BGMove(item, cactusSpeed, 0f);
        }

        foreach (var item in groundTs)
        {
            BGMove(item, groundpeed, 0);  //-3f
        }
    }

    public void BGMove(Transform trans, float speed, float posY)
    {
        trans.Translate(new Vector2(-(Time.deltaTime * speed), 0f));
        if (trans.position.x < lastPos)
        {
            trans.position = new Vector3(initPos, posY);
        }
    }
}
