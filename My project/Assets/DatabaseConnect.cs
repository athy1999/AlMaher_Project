using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;

public class DatabaseConnect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string conn = "URI=file:" + Application.dataPath + "/Database1.db"; //Path to database.
        IDbConnection dbconn = (IDbConnection) new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        ////
        IDataReader reader = null;
        String sqlQuery = null;
        sqlQuery = "CREATE TABLE IF NOT EXISTS student (SSN INTEGER PRIMARY KEY, classid INTEGER  , First name TEXT NOT NULL,Last name TEXT NOT NULL, ParentsPhone number TEXT NOT NULL,FOREIGN KEY(classid) REFERENCES class (classID) ON DELETE CASCADE ON UPDATE NO ACTION); ";
        dbcmd.CommandText = sqlQuery;
        reader = dbcmd.ExecuteReader();
        ////
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;

        //void Addstudent()
        //{

        //    sqlQuery = "INSERT INTO student
        //                + "VALUES(" + id + ", " + fn + ", " + ln + "," + phone + "); ";
        //    dbcmd.CommandText = sqlQuery;
        //    reader = dbcmd.ExecuteReader();
        //public InputField std_fn;
        //public InputField std_ln;
        //public InputField std_id;
        //public InputField phn;
        //    var fn = gameObject.GetComponent<std_fn>();
        //    var ln = gameObject.GetComponent<std_ln>();
        //    var id = gameObject.GetComponent<std_id>();
        //    var phone = gameObject.GetComponent<phn>();

        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
