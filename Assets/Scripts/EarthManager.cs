using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthManager : MonoBehaviour
{

    GameLogic gameLogicController;

    // Start is called before the first frame update
    void Start()
    {
        gameLogicController = GameObject.Find("World").GetComponent<GameLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "lba" || collision.gameObject.tag == "sba")
        {
            Destroy(gameObject);
            gameLogicController.SetState(GameLogic.State.Dead);
        }
    }
}
