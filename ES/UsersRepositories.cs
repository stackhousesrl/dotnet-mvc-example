namespace MvcMovie.ES;


using MvcMovie.DataContext;
using MvcMovie.Models;


public class UsersRepositories(ApplicationDbContext context)
{

    public IEnumerable<User> GetAll()
    {

        try
        {
            var blogs = context.Users.ToList();

            var filtered =
                from blog in blogs
                where blog.Name!.StartsWith("Gian")
                orderby blog.Name
                select blog;


            return filtered;
        }
        catch (Exception)
        {
            return [];
        }

    }


    public User Create(string name)
    {

        /* try
        { */
            var user = new User
            {
                Name = name
            };

            context.Users.Add(user);
            context.SaveChanges();

            return user;
        /* }
        catch (Exception)
        {
            return false;
        } */

    }
}