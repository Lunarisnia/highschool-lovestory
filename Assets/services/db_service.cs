using UnityEngine;
using Mono.Data.Sqlite;
using System.IO;
using System.Data;


public class db_service : MonoBehaviour
{
    // Start is called before the first frame update
    string Skit = "CREATE TABLE IF NOT EXISTS [skit] ([id] TEXT PRIMARY KEY NOT NULL,[content] TEXT  NOT NULL)";
    IDbConnection dbcon;
    void Awake()
    {
        dbOpen();
    }

    public IDbConnection dbOpen()
    {
        string connection = "URI=file:" + Application.persistentDataPath + "/" + "highschool_lovestory";
        dbcon = new SqliteConnection(connection);
        dbcon.Open();

        IDbCommand dbcmd;
        dbcmd = dbcon.CreateCommand();

        dbcmd.CommandText = Skit;
        dbcmd.ExecuteReader();
        return dbcon;
    }
}
