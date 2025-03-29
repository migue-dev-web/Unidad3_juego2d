using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using UnityEditor.MemoryProfiler;
using System.IO;

public class SQLiteDB : MonoBehaviour
{
  private string dbPath;
  private IDbConnection dbConnection;
    void Start()
    {
       dbPath = "URI=file:" + Application.persistentDataPath + "/gameData.db";
       dbConnection = new SqliteConnection(dbPath);
        dbConnection.Open();

        CreateTables();
        Debug.Log("Conexion establecida ");
    }

    void CreateTables(){
        IDbCommand command =dbConnection.CreateCommand();
        command.CommandText = @"CREATE TABLE IF NOT EXISTS playerdata(
        id INTEGER PRIMARY KEY AUTOINCREMENT,
        coins INTEGER,
        level1Progress INTEGER,
        level2Progress INTEGER
        )";
        command.ExecuteNonQuery();
    }

    public void SaveData(int coins,int lvl1, int lvl2){
         

        IDbCommand command = dbConnection.CreateCommand();
        command.CommandText = $"UPDATE PlayerData SET coins = coins + {coins}, level1Progress = {lvl1}, level2Progress = {lvl2} WHERE id = 1";
        int rowsAffected = command.ExecuteNonQuery();

        if (rowsAffected == 0){

        command.CommandText = $"INSERT INTO PlayerData (coins, level1Progress, level2Progress) VALUES ({coins}, {lvl1}, {lvl2})";
        command.ExecuteNonQuery();
        }
        Debug.Log("Datos guardados en SQLite");

        LoadData();
    }
    public void LoadData(){
        IDbCommand command = dbConnection.CreateCommand();
        command.CommandText = "SELECT * FROM playerdata  WHERE id = 1";
        IDataReader reader = command.ExecuteReader();

        if (reader.Read() ){
            Debug.Log($"Monedas: {reader["coins"]}, Nivel 1: {reader["level1Progress"]}, Nivel 2:{reader["level2Progress"]} ");
        }
    }
    

    void OnApplicationQuit()
    {
        dbConnection.Close();
        Debug.Log("Conexion cerrada con sqlite");
    }
    void Update()
    {
        
    }
}
