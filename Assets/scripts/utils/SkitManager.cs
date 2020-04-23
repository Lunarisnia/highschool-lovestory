using Mono.Data.Sqlite;
using System.IO;
using System.Data;
using UnityEngine;

public class SkitManager : MonoBehaviour
{
    skit_service skit = new skit_service();
    public SkitModel SkitEntry;
    [ContextMenu("Get All Skit")]
    public void getAllSkit()
    {
        IDataReader result = new skit_service().getAllSkit();

        while (result.Read())
        {
            Debug.Log("id : " + result[0]);
            Debug.Log("content : " + result[1]);
        }
    }

    [ContextMenu("Add New Skit")]
    public void addNewSkit()
    {
        int result = new skit_service().addNewSkit(SkitEntry);
        Debug.Log(result);
    }
}
