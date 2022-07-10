using ShoppingList.Models;
using SQLite;

namespace ShoppingList.Repositories;

public class PromiseRepository
{
    string _dbPath;
    private SQLiteConnection conn;

    public string StatusMessage { get; set; }

    private void Init()
    {
        if (conn != null)
            return;

        conn = new SQLiteConnection(_dbPath);
        conn.CreateTable<Promise>();
    }


    public PromiseRepository(string dbPath)
    {
        _dbPath = dbPath;                        
    }

    public void Create(Promise promise)
    {            
        int result = 0;
        try
        {
            // enter this line
            Init();

            // enter this line
            result = conn.Insert(promise);
            if (result != 1)
            {
                throw new Exception("Couldn't be created for unknown reasons");
            } 
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to add {0}. Error: {1}", promise, ex.Message);
        }

    }

    public List<Promise> GetAll()
    {
        try
        {
            Init();
            return conn.Table<Promise>().ToList();
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
        }

        return new List<Promise>();
    }
    
    public Promise Get()
    {
        try
        {
            Init();
            return conn.Table<Promise>().ToList().First();
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
        }

        return new Promise();
    }

    public Promise Update(Promise promise)
    {
        return new Promise();
    }

    public void Delete(int id)
    {
        
    }

    public void Deconstruct()
    {
        this.conn.Close();
    }
}