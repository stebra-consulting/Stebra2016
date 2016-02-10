using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage.Table;
using System.Net;
using System.Text.RegularExpressions;
/// <summary>
/// Summary description for AzureManager
/// </summary>
public class AzureManager
{
    private const string tableName = "stebraNyhetslist";
    private const string partitionKey = "Nyhet";

    private static CloudStorageAccount StorageAccount = CloudStorageAccount.Parse(Keys.AzureConnectionString);

    //CloudConfigurationManager.GetSetting("StorageConnectionString")
    //get Table -client  
    public static CloudTableClient tableClient = StorageAccount.CreateCloudTableClient();
    public static List<StebraEntity> getAzure()
    {
        CloudTable table = SelectValidTable();

        //Query all entities where "PartitionKey" is "News"
        var allNewsQuery = new TableQuery<StebraEntity>()
            .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionKey));//partitionKey is "Nyhet"

        //Entities to List
        var news = table.ExecuteQuery(allNewsQuery).ToList();

        //Return List
        return news;
    }
    private static CloudTable SelectValidTable()
    {
        CloudTable tempTable = null;

        for (int id = 0; id < 10; id++)
        {
            tempTable = tableClient.GetTableReference(tableName + id.ToString());
            if (tempTable.Exists()) break;
        }
        //check this tables

        return tempTable;
    }


    public static List<StebraEntity> sort()
    {
        List<StebraEntity> news = getAzure();
        news = news.OrderByDescending(o => o.IntDate).ToList();
        news[0].Image = WebUtility.HtmlDecode(news[0].Image);
        news[0].Body = Regex.Replace(news[0].Body, @"(<img\/?[^>]+>)", @"",
        RegexOptions.IgnoreCase);
        news[0].Article = Regex.Replace(news[0].Article, @"(<img\/?[^>]+>)", @"",
        RegexOptions.IgnoreCase);
        return news;
    }
}