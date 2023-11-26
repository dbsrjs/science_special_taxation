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

    private GameManager gameManager;


    private float skySpeed = 3f;
    private float cloudSpeed = 3f;
    private float backSpeed = 4f;
    private float cactusSpeed = 4.5f;
    private float groundpeed = 5f;

    private float lastPos = -8f;    //끝 값
    private float initPos = 30f;    //시작 값
    // Update is called once per frame
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (gameManager.timeSize == 1)
        {
            Move();
        }
    }

    public void Move()
    {
        foreach (var item in skyTs)
        {
            BGMove(item, skySpeed, -1f);
        }
        
        foreach (var item in cloudTs)
        {
            BGMove(item, cloudSpeed, 1.71f);
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
            BGMove(item, groundpeed, -3f);
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
