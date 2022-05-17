using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minXPos = 1f;
    [SerializeField] float maxXPos = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.mousePosition.x / Screen.width * screenWidthInUnits);
        
        
        
        //paddle position settings
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        
        //Constrain the paddle movements suct that it will not go out of the game window.
        paddlePosition.x = Mathf.Clamp(GetXPosition(), minXPos, maxXPos);
        
        //paddle will be transformed or positioned to the postion asigned
        transform.position = paddlePosition;
        // float mouseXPos = transform.position.x;
        // float mouseYPos = paddlePosition;

    }

    private float GetXPosition()
    {
        /*if (FindObjectOfType<GameStatus>().IsAutoPlayEnabled()){
            return FindObjectOfType<Ball>().transform.position.x;
        }*/
        //else
        //{
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        //}
    }
}
