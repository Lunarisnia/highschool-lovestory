using UnityEngine;
using Mono.Data.Sqlite;
using System.IO;
using System.Data;

public class skit_service : MonoBehaviour
{
    // public str
    public IDataReader getAllSkit()
    {
        IDbConnection dbConn = new db_service().dbOpen();

        IDbCommand command = dbConn.CreateCommand();
        command.CommandText = "SELECT * FROM skit";
        IDataReader reader = command.ExecuteReader();
        return reader;
    }

    public int addNewSkit(SkitModel skit)
    {
        System.Guid uuid = System.Guid.NewGuid();

        IDbConnection dbConn = new db_service().dbOpen();
        IDbCommand command = dbConn.CreateCommand();
        command.CommandText = string.Format("INSERT INTO skit (id, content) VALUES (\"{0}\", \"{1}\")", uuid, skit.skit);
        int result = command.ExecuteNonQuery();
        return result;
    }
}