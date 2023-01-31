using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invaders : MonoBehaviour
{
    public Invader[] prefabs;

    //total number of rows of invaders.
    public int rows = 5; 

    //total number of columns of invaders.
    public int columns = 11;

    //how fast each row of invaders will move.
    public float speed = 1.0f; 

    // determines which direction each row will move. 
    private Vector3 _direction = Vector2.right; 


    //Code to spawn the invaders in a grid formation on game start 

    private void Awake()
    {
        for(int row = 0; row < this.rows; row ++)
        {
            //determines the width of the total spawn area for the space invaders. 
            float width = 2.0f * (this.columns - 1);

            //determines the height of the total spawn area for the space invaders.
            float height = 2.0f * (this.rows - 1);

            //find the center point of the spawn area by dividing the spawn area's width and height by 2.  
            Vector2 centering = new Vector2(-width / 2, -height / 2); 

            //determine where each row of invaders will appear and how spaced out they will be. 
            Vector3 rowPosition = new Vector3(centering.x, centering.y +(row * 2.0f) , 0.0f); 


            for (int col = 0; col < this.columns; col++)
            {
               Invader invader = Instantiate(this.prefabs[row], this.transform);
                Vector3 position = rowPosition;
                position.x += col * 2.0f;
                invader.transform.localPosition = position; 
                
            }
        }
    }

    //script for moving the invaders until they hit the bounds of the screen. 
    private void Update()
    {
        this.transform.position += _direction * this.speed * Time.deltaTime;

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right); 

        foreach (Transform invader in this.transform)
        {
            if (!invader.gameObject.activeInHierarchy)
            {
                continue; 
            }

            if (_direction == Vector3.right && invader.position.x >= (rightEdge.x - 1.0f))
            {
                AdvanceRow(); 
            } else if (_direction == Vector3.left && invader.position.x <= (leftEdge.x + 1.0f))
            {
                AdvanceRow(); 
            }
        }
    }

    //script to move the invaders down a row when they hit the bound of the screen. 
    private void AdvanceRow()
    {
        _direction.x *= -1.0f;

        Vector3 position = this.transform.position;
        position.y -= 1.0f;
        this.transform.position = position; 
    }
}
