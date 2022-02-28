using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;


public class HighScore : MonoBehaviour
{
    public Text txtHighscore;
    List<PlayerData> players = new List<PlayerData>();
    //private PlayerData _pd;
    // Only gets and shows highest score 
    private PlayerData maxScorer = new PlayerData();
    void Start()
    {

        MongoClient dbClient = new MongoClient("mongodb+srv://dcomo:mongomadness01@slidergame.xhvhl.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");

        var database = dbClient.GetDatabase("SliderDatabase");
        var collection = database.GetCollection<BsonDocument>("SliderCollection");



        var documents = collection.Find(new BsonDocument()).ToList();


        foreach (BsonDocument doc in documents)
        {
            players.Add(BsonSerializer.Deserialize<PlayerData>(doc));
            Debug.Log(doc.ToString());
        }
        //FindHighscore();

        foreach(PlayerData p in players)
        {
            if (p.score > maxScorer.score)
            {
                maxScorer = p;
            }
            Debug.Log(p.username + " - " + p.score);
        }
        txtHighscore.text = "Highest Score: "+maxScorer.username.ToString() + " - " + maxScorer.score.ToString();

    }

    //public static async Task FindHighscore()
    //{
    //    await Task.Run(() =>
    //    {
    //        collection.Find(new BsonDocument()).Sort(new BsonDocument("$natural", -1)).FirstOrDefault();
    //        Debug.Log(result.ToString());
    //    });
    //}




}
