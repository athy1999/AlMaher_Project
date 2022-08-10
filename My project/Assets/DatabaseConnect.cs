using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.UI;

public class DatabaseConnect : MonoBehaviour
{
    String sqlQuery = null;
    string conn;
    IDbConnection dbconn;
    IDbCommand dbcmd;
    IDataReader reader;
    // Start is called before the first frame update
    void Start()
    {
        conn = "URI=file:" + Application.dataPath + "/Database1.db"; //Path to database.
        dbconn = (IDbConnection) new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        dbcmd = dbconn.CreateCommand();
        ////
        reader = null;
        
        sqlQuery = "CREATE TABLE IF NOT EXISTS student (SSN INTEGER PRIMARY KEY, classid INTEGER  , First_name TEXT NOT NULL,Last_name TEXT NOT NULL, ParentsPhone number TEXT NOT NULL,FOREIGN KEY(classid) REFERENCES class (classID) ON DELETE CASCADE ON UPDATE NO ACTION); ";
        dbcmd.CommandText = sqlQuery;
        reader = dbcmd.ExecuteReader();
        ////
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;

    }

    public InputField std_fn;
    public InputField std_ln;
    public InputField std_id;
    public InputField phn;


    public void Addstudent()
    {
        var fn = std_fn.text;
        var ln = std_ln.text;
        var id = std_id.text;
        var phone = phn.text ;
        print(fn + ln + id + phone);
        sqlQuery = "INSERT INTO student (SSN,First_name,Last_name,ParentsPhone) VALUES(" + id + ", '" + fn + "', '" + ln + "','" + phone + "'); ";
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = sqlQuery;
        reader = dbcmd.ExecuteReader();


        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
