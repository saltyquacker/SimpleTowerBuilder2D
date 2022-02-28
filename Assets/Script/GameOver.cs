using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using MongoDB.Driver;
public class GameOver : MonoBehaviour
{

    //Get username entered
    //Get current score

    private PlayerData _playerData = new PlayerData();
   
    public InputField inputUser;
    public GameObject wait;

    public void OnGameOverClick()
    {
        //Get from input

        wait.SetActive(true);
        StartCoroutine(Upload());
        //inputUser.text = GlobalVar.previousEntry;



    }

    IEnumerator Upload()
    {

        yield return new WaitForSeconds(0.5f);
        _playerData.username = inputUser.text;
        _playerData.score = GlobalVar.score;
        _playerData.datetime = DateTime.Now.ToString("yyyy-MM-dd | HH:mm:ss");

        //GlobalVar.previousEntry = inputUser.text;

        MongoClient dbClient = new MongoClient("mongodb+srv://dcomo:mongomadness01@slidergame.xhvhl.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");

        var database = dbClient.GetDatabase("SliderDatabase");
        var collection = database.GetCollection<PlayerData>("SliderCollection");

        collection.InsertOne(_playerData);

        Debug.Log("INSERTED!");





        SceneManager.LoadScene("Game");
        GlobalVar.score = 0;
        GlobalVar.squareCount = 0.0f;
        GlobalVar.gameOver = false;
        GlobalVar.move = true;
        GlobalVar.ypos = -3.5f;
    }



   

}



