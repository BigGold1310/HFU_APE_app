using System.Collections.ObjectModel;
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
            Init();

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

    public ObservableCollection<Promise> GetAll()
    {
        try
        {
            Init();
            return new ObservableCollection<Promise>(conn.Table<Promise>().ToList());
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
        }

        return new ObservableCollection<Promise>();
    }
    
    public Promise Get(int id)
    {
        try
        {
            Init();
            return conn.Table<Promise>().FirstOrDefault(p => p.Id == id);
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
        }

        return new Promise();
    }

    public void Update(Promise promise)
    {
        int result = 0;
        try
        {
            Init();
            
            result = conn.Update(promise);
            if (result != 1)
            {
                throw new Exception("Couldn't be updated for unknown reasons");
            } 
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
        }
    }

    public void Delete(int id)
    {
        try
        {
            Init();
            conn.Table<Promise>().Delete(p => p.Id == id);
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
        }
    }

    public void Deconstruct()
    {
        conn.Close();
    }
}