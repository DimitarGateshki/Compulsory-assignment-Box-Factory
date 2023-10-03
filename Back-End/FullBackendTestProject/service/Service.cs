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

    public Box CreateBox(string name, DateOnly DateOfCreation, string category)
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

}