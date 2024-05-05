using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;  // for hash password  Encoding 
using static systemdesignProject.Models.Userstable;

namespace systemdesignProject.Controllers
{
    public class AuthController : Controller
    {
     
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]  // for login functionality  to check user  
        public IActionResult Login(string name, string password)
        {
            // Hash the provided password to compare with the stored hash
            var hashedPassword = HashPassword(password);

            var user = _context.Users.FirstOrDefault(u => u.Name == name && u.Password == hashedPassword);

            if (user == null)
            {
                ModelState.AddModelError("Name", "Invalid username or password");
                return View();
            }

            // Set session or cookie to indicate successful login
            HttpContext.Session.SetString("UserId", user.Id.ToString());

            return RedirectToAction("Profile");
        }

        [HttpPost]
        public IActionResult Register(Models.Userstable newUser)
        {
            // Check if the username already exists
            if (!_context.Users.Any(u => u.Name == newUser.Name))
            {
                // Hash the password
                newUser.Password = HashPassword(newUser.Password);

                // Add the new user to the context and save
                _context.Users.Add(newUser);
                _context.SaveChanges();

                // Redirect to login after successful registration
                return RedirectToAction("Login");
            }

            ModelState.AddModelError("Name", "Username already exists");
            return View(newUser);
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
       public IActionResult Profile()
{
    var userIdStr = HttpContext.Session.GetString("UserId");
    
    if (string.IsNullOrEmpty(userIdStr) || !int.TryParse(userIdStr, out int userId))
    {
        // If there's no valid session, redirect to login
        return RedirectToAction("Login");
    }

    var user = _context.Users.FirstOrDefault(u => u.Id == userId);

    if (user == null)
    {
        // If the user is not found, redirect to login
        return RedirectToAction("Login");
    }

    return View(user); // Pass the user data to the view
}
    }
}
