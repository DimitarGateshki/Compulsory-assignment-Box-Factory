using infrastructure;
using infrastructure.DataModels;

namespace service;

public class Service
{
    private readonly Repository _repository;

    public Service(Repository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Box> GetAllBoxes()
    {
        try
        {
            return _repository.GetAllBoxes();
        }
        catch (Exception)
        {
            throw new Exception("Could not get boxes");
        }
    }

    public Box GetBox(int id)
    {
        try
        {
            return _repository.GetBoxByID(id);
        }
        catch
        {
            throw new Exception("Could not get the certain box!");
        }
    }

    public Box CreateBox(string name, DateTime DateOfCreation, string category)
    {
        try
        {
           return _repository.CreateBox(name, DateOfCreation, category);
        }
        catch (Exception )
        {
            throw new Exception("Could not create the box!");
        }
    }

    public IEnumerable<SearchBoxItem> SearchBoxItems(string searchTerm, int pageSize)
    {
        return _repository.SearchBoxes(searchTerm, pageSize);
    }

    public Box UpdateBox( int id,string name, DateTime date, string category)
    {
        return _repository.UpdateBox(id ,name, date, category);
    }
    /*
    public void DeleteBox(int boxId)
    {
        var result = _repository.DeleteBox(boxId);
        if (!result)
        {
            throw new Exception("Could not delete that box!");
        }
        
    }
    */

}