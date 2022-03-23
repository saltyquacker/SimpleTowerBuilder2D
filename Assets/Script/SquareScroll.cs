using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
public class SquareScroll : MonoBehaviour
{
   
    //Up 1 unit every time
    //Camera also needs to move up 1 unit
    private bool routineFlag = false;
    private Vector3 left;
    private Vector3 right;
    private float step;
    private float speed = 3.0f;
    private int thisMod = 0;
    public GameObject stopSquare;
    private bool localMove = true;
    // Start is called before the first frame update
    void Start()
    {
        right = new Vector3(3.0f, GlobalVar.ypos, 0.0f);
        left = new Vector3(-3.0f, GlobalVar.ypos, 0.0f);
        transform.position = right;
        step = speed * Time.deltaTime;
        GlobalVar.squareSpeed = speed;
    }

    void Update()
    {
        if (GlobalVar.squareCount>1)
        {
            GlobalVar.modulo = (int)(GlobalVar.squareCount % 10);
            if (thisMod != GlobalVar.modulo)
            {
                thisMod = GlobalVar.modulo;

                step = step +0.001f;
            }
            
        }
       
        GlobalVar.squareSpeed = step;
        if (GlobalVar.gameOver == false)
        {
            right = new Vector3(3.0f, GlobalVar.ypos, 0.0f);
            left = new Vector3(-3.0f, GlobalVar.ypos, 0.0f);

            if (localMove == true)
            {


                if (transform.position == left)
                {
                    routineFlag = true;
                }
                else if (transform.position == right)
                { routineFlag = false; }



                if (routineFlag == false)//Moves left
                {
                    transform.position = Vector3.MoveTowards(transform.position, left, step);

                }
                else
                {

                    transform.position = Vector3.MoveTowards(transform.position, right, step);
                }

                //Touch Screen
                //foreach (Touch touch in Input.touches)
                //{
                //    if (touch.fingerId == 0)
                //    {
                //        if (Input.GetTouch(0).phase == TouchPhase.Began)
                //        {
                //            Debug.Log("First finger entered!");
                //        }
                //        if (Input.GetTouch(0).phase == TouchPhase.Ended)
                //        {
                //            Debug.Log("First finger left.");
                //        }
                //    }
                //}

            }
        }
        else
        {
            //If Game is over
            //popup
        }
        //if(GlobalVar.move == false)
        //{
        //    localMove = false;
        //    GlobalVar.move = true;
    
            //Make stationary square
            //Instantiate(stopSquare, transform.position, Quaternion.identity);
 
            

        //}
    }

   
  
}
