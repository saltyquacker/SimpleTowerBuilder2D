using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using UnityEngine.UI;
using System;
using MongoDB.Driver;

public class Screen : MonoBehaviour
{
    //Create a vectorlocation object for squares
   // private VectorLocation currentLocation = new VectorLocation();

    public GameObject stackSquare;
    public GameObject scrollSquare;
    public GameObject currentSquare;
    public GameObject camera;
    private GameObject stationSquare;
    public GameObject yesSquare;
    public GameObject noSquare;
    public GameObject gameOverOverlay;
    public GameObject rotateLeft;
    public GameObject rotateRight;

    public GameObject destroyNext;
    public GameObject platform;


    public Text txtScore;
    //public Text txtHighscore;

    private float step;
    private float speed = 10.0f;

    private float minx;
    private float maxx;

    private float currminx;
    private float currmaxx;



    void Start()
    {
        Instantiate(scrollSquare, new Vector3(3.0f, GlobalVar.ypos, 0.0f), Quaternion.identity);
        //step = speed* Time.deltaTime;
        step = 0.06f;
        Debug.Log("SPEED: " + speed);
        Debug.Log("STEP: " + step);


    }
    void Update() {
        //Needs update to move camera

        if (GlobalVar.squareCount > 3)
        {

            Vector3 cameraMove = new Vector3(0.0f, GlobalVar.squareCount - 3, -10f);
            //Move camera up
            camera.transform.position = Vector3.MoveTowards(camera.transform.position, cameraMove, step);

        }

    }
    void OnMouseDown()
    {
        //Moved from Update, trying to get rid of all updates for speed

        if (GlobalVar.gameOver == false)
        {
            //gameOverOverlay.SetActive(false);
            //GlobalVar.move = false;
            currentSquare = GameObject.Find("ScrollSquare(Clone)");
            //Debug.Log("New ypos" + GlobalVar.ypos);
            //Debug.Log("Stopping #" + currentSquare.transform.position);

            currminx = currentSquare.transform.position.x - 0.5f;
            currmaxx = currentSquare.transform.position.x + 0.5f;

            //Track locations of squares
          //  currentLocation.xpos = currentSquare.transform.position.x;
          //  currentLocation.ypos = currentSquare.transform.position.y;

            GlobalVar.ypos += 1.0f;

         //   Debug.Log("Adding x: " + currentLocation.xpos + " y: " + currentLocation.ypos);
            //Tell me if next square is inside previous square, skip first square
            if (GlobalVar.squareCount >= 1)
            {
                stationSquare = GameObject.Find("YesSquare(Clone)");
                stationSquare.name = "s" + GlobalVar.squareCount;
                //Updated to a more dynamic approach using global variable to hold V2 locations
                if (currminx <= maxx && currminx >= minx)
                {
                    //Debug.Log("IN " + currminx + ", " + currmaxx);

                    GlobalVar.score++;
                    Instantiate(yesSquare, currentSquare.transform.position, Quaternion.identity);
                 //   GlobalVar.squareLocations.Add(currentLocation);

                }
                else if (currmaxx >= minx && currmaxx <= maxx)
                {

                    //Debug.Log("IN " + currminx + ", " + currmaxx);
                    Instantiate(yesSquare, currentSquare.transform.position, Quaternion.identity);
                 //   GlobalVar.squareLocations.Add(currentLocation);
                    GlobalVar.score++;
                }
                else
                {
                //    GlobalVar.squareLocations.Add(currentLocation);
                    Instantiate(noSquare, currentSquare.transform.position, Quaternion.identity);
                    Debug.Log("GAME OVER");
                   // GameOver();
                    GlobalVar.gameOver = true;


                    gameOverOverlay.SetActive(true);


                }

            }
            else
            {
                Instantiate(yesSquare, currentSquare.transform.position, Quaternion.identity);
            }

            //Assign next
            minx = currentSquare.transform.position.x - 0.5f;
            maxx = currentSquare.transform.position.x + 0.5f;

            //Useless target min max
            GlobalVar.targetMin = currminx;
            GlobalVar.targetMax = currmaxx;


            //Debug.Log("TARGET COORDS: " + minx + ", " + maxx);




            //Make stack square in place of scroll square




            currentSquare.transform.position = new Vector3(3.0f, GlobalVar.ypos, 0.0f);

            //DestroyImmediate(scrollSquare,true);
            //Instantiate(scrollSquare, new Vector3(3.0f, GlobalVar.ypos, 0.0f), Quaternion.identity);

            GlobalVar.squareCount += 1.0f;
            txtScore.text = "Score: " + GlobalVar.score;
           // txtHighscore.text = "Highscore";
            DestroyUnderStack();
        }
        else
        {
            Debug.Log("Game is still over");
        }
    }
   
    //Displays only the game objects/squares that are visible to the camera
    //Only display the 5 previous stacks
    //Object clean up
    void DestroyUnderStack()
    {
        //Destroy old cube
        //5 below

        if (GlobalVar.score > 4)
        {
            destroyNext = GameObject.Find("s" + (GlobalVar.score - 4));
            Destroy(destroyNext);
            try
            {
                Destroy(platform);
            }
            catch (Exception e)
            {
                Debug.Log("Base is already destroyed");
            }
        }


    }


}


