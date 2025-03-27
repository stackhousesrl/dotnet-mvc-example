using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.ES;
using System.Text.Json;

namespace MvcMovie.Controllers;



public class HelloWorldController : Controller
{
    private readonly UsersRepositories _userRepository;

    // Constructor
    public HelloWorldController(UsersRepositories usersContext)
    {
        _userRepository = usersContext;
    }

    // 
    // GET: /HelloWorld/
    public string Index()
    {

        var users = _userRepository.GetAll();
        string jsonString = JsonSerializer.Serialize(users);

        /*
            if(jsonString.Length == 0){
                return NotFound();
            } 
        */

        return jsonString; //Ok(jsonString);
    }
    
    // 
    // GET: /HelloWorld/Welcome/ 
    public string Welcome()
    {
        _userRepository.Create("Andrea");

        return "OKK";
    }
}