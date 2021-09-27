using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DatabaseFirstLINQ.Models;

namespace DatabaseFirstLINQ
{
    class Problems
    {
        private ECommerceContext _context;

        public Problems()
        {
            _context = new ECommerceContext();
        }
        public void RunLINQQueries()
        {
            //            //ProblemOne();
            //            //ProblemTwo();
            //ProblemThree();
            //ProblemFour();
            //ProblemFive();
            //ProblemSix();
            //ProblemSeven();
            //ProblemEight();
            //ProblemNine();
            //ProblemTen();
            //ProblemEleven();
            //ProblemTwelve();
            //ProblemThirteen();
            //ProblemFourteen();
            //ProblemFifteen();
            //ProblemSixteen();
            //ProblemSeventeen();
            //ProblemEighteen();
            //ProblemNineteen();
            //ProblemTwenty();
            //BonusOne();
            //BonusTwo();
            BonusThree();
        }

        // <><><><><><><><> R Actions (Read) <><><><><><><><><>
        private void ProblemOne()
        {
            // Write a LINQ query that returns the number of users in the Users table.
            // HINT: .ToList().Count
            var users = _context.Users;
            var numberOfUsers = users.ToList().Count;
            Console.WriteLine(numberOfUsers);

        }

        private void ProblemTwo()
        {
            // Write a LINQ query that retrieves the users from the User tables then print each user's email to the console.
            var users = _context.Users;

            foreach (User user in users)
            {
                Console.WriteLine(user.Email);
            }

        }

        private void ProblemThree()
        {
            // Write a LINQ query that gets each product where the products price is greater than $150.
            // Then print the name and price of each product from the above query to the console.

            var products = _context.Products;
            var expensiveProducts = products.Where(p => p.Price >= 150);
            foreach (var product in expensiveProducts)
                {
                Console.WriteLine(product.Name + "" + product.Price);
                }

        }

        private void ProblemFour()
        {
            // Write a LINQ query that gets each product that contains an "s" in the products name.
            // Then print the name of each product from the above query to the console.
            var products = _context.Products;
            var productsWithS = products.Where(p => p.Name.Contains("s"));
            foreach(var product in productsWithS)
            {
                Console.WriteLine(product.Name);
            }
        }

        private void ProblemFive()
        {
            // Write a LINQ query that gets all of the users who registered BEFORE 2016
            // Then print each user's email and registration date to the console.

            var user =_context.Users;
            DateTime d1 = new DateTime(2016, 1, 1);
            var userOld = user.Where(u => u.RegistrationDate<d1);
            foreach( var date in userOld)
            {
                Console.WriteLine(date.Email + "" + date.RegistrationDate);
            }


        }

        private void ProblemSix()
        {
            // Write a LINQ query that gets all of the users who registered AFTER 2016 and BEFORE 2018
            // Then print each user's email and registration date to the console.
            var user = _context.Users;
            DateTime d1 = new DateTime(2016, 1, 1);
            DateTime d2 = new DateTime(2018, 1, 1);
            var userOld = user.Where(u => u.RegistrationDate > d1 && u.RegistrationDate < d2);
            foreach (var date in userOld)
            {
                Console.WriteLine(date.Email + "" + date.RegistrationDate);
            }

        }

        // <><><><><><><><> R Actions (Read) with Foreign Keys <><><><><><><><><>

        private void ProblemSeven()
        {
            // Write a LINQ query that retreives all of the users who are assigned to the role of Customer.
            // Then print the users email and role name to the console.
            var customerUsers = _context.UserRoles.Include(ur => ur.Role).Include(ur => ur.User).Where(ur => ur.Role.RoleName == "Customer");
            foreach (UserRole userRole in customerUsers)
            {
                Console.WriteLine($"Email: {userRole.User.Email} Role: {userRole.Role.RoleName}");
            }
        }

        private void ProblemEight()
        {
            // Write a LINQ query that retreives all of the products in the shopping cart of the user who has the email "afton@gmail.com".
            // Then print the product's name, price, and quantity to the console.
            var products = _context.ShoppingCarts.Include(ur => ur.Product).Include(ur => ur.User).Where(ur => ur.User.Email == "afton@gmail.com");
            foreach (ShoppingCart product in products) 
            {
                Console.WriteLine($"Name: {product.Product.Name} Price: {product.Product.Name} Quantity: {product.Quantity}");
            }
        }

        private void ProblemNine()
        {
            // Write a LINQ query that retreives all of the products in the shopping cart of the user who has the email "oda@gmail.com" and returns the sum of all of the products prices.
            // HINT: End of query will be: .Select(sc => sc.Product.Price).Sum();
            // Then print the total of the shopping cart to the console.
            var productsum = _context.ShoppingCarts.Include(ur => ur.Product).Include(ur => ur.User).Where(ur => ur.User.Email == "oda@gmail.com").Select(sc => sc.Product.Price).Sum();
            {
                Console.WriteLine(productsum);
            }
        }

        //private void ProblemTen()
        //{
        //    // Write a LINQ query that retreives all of the products in the shopping cart of users who have the role of "Employee".
        //    // Then print the user's email as well as the product's name, price, and quantity to the console.
        //    // Need multiple queries
        //    var usersInRole = _context.UserRoles.Where(u => u.Role.RoleName == "Employee").Select(u => u.User.Id);
        //    var userShoppingCartProducts = _context.ShoppingCarts.Include(sc => sc.Product).Include(sc => sc.User).Where(sc => usersInRole.Contains(sc.UserId));​
        //    foreach (var shoppingCart in userShoppingCartProducts)
        //    {
        //        Console.WriteLine($"Email: {shoppingCart.User.Email}\n Product Name: {shoppingCart.Product.Name} \n {shoppingCart.Product.Price}\n {shoppingCart.Quantity}\n\n");
        //    }

        //}

        // <><><><><><><><> CUD (Create, Update, Delete) Actions <><><><><><><><><>

        // <><> C Actions (Create) <><>

        private void ProblemEleven()
        {
            DateTime d1 = new DateTime(2021, 1, 1);
            // Create a new User object and add that user to the Users table using LINQ.
            User newUser = new User()
            {
                Email = "david@gmail.com",
                Password = "DavidsPass123",
                RegistrationDate = d1,
            };
            Console.WriteLine(newUser);
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        private void ProblemTwelve()
        {
            // Create a new Product object and add that product to the Products table using LINQ.

            //.name, desc. , price

            Product newProduct = new Product()
            {
                Name = "Blue Light Blocking Glasses",
                Description = "Blocks Blue Light",
                Price = 20,

            };
            _context.Products.Add(newProduct);
            _context.SaveChanges();
        }

        private void ProblemThirteen()
        {
            // Add the role of "Customer" to the user we just created in the UserRoles junction table using LINQ.
            var roleId = _context.Roles.Where(r => r.RoleName == "Customer").Select(r => r.Id).SingleOrDefault();
            var userId = _context.Users.Where(u => u.Email == "david@gmail.com").Select(u => u.Id).SingleOrDefault();
            UserRole newUserRole = new UserRole()
            {
                UserId = userId,
                RoleId = roleId
            };
            _context.UserRoles.Add(newUserRole);
            _context.SaveChanges();
        }

        private void ProblemFourteen()
        {
            // Add the product you create to the user we created in the ShoppingCart junction table using LINQ.
            var userId = _context.Users.Where(u => u.Email == "david@gmail.com").Select(u => u.Id).SingleOrDefault();
            var productId = _context.Products.Where(p => p.Id == 8).Select(p => p.Id).SingleOrDefault();
            ShoppingCart newProduct = new ShoppingCart()
            {
                UserId = userId,
                ProductId = productId,
                Quantity = 1,
            };
            _context.ShoppingCarts.Add(newProduct);
            _context.SaveChanges();
        }

        // <><> U Actions (Update) <><>

        private void ProblemFifteen()
        {
            // Update the email of the user we created to "mike@gmail.com"
            var user = _context.Users.Where(u => u.Email == "david@gmail.com").SingleOrDefault();
            user.Email = "mike@gmail.com";
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        private void ProblemSixteen()
        {
            // Update the price of the product you created to something different using LINQ.
            var product = _context.Products.Where(p => p.Id ==8).SingleOrDefault();
            product.Price = 1350;
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        private void ProblemSeventeen()
        {
            // Change the role of the user we created to "Employee"
            // HINT: You need to delete the existing role relationship and then create a new UserRole object and add it to the UserRoles table
            // See problem eighteen as an example of removing a role relationship
            var userRole = _context.UserRoles.Where(ur => ur.User.Email == "mike@gmail.com").SingleOrDefault();
            _context.UserRoles.Remove(userRole);
            UserRole newUserRole = new UserRole()
            {
                UserId = _context.Users.Where(u => u.Email == "mike@gmail.com").Select(u => u.Id).SingleOrDefault(),
                RoleId = _context.Roles.Where(r => r.RoleName == "Employee").Select(r => r.Id).SingleOrDefault()
            };
            _context.UserRoles.Add(newUserRole);
            _context.SaveChanges();
        }

        // <><> D Actions (Delete) <><>

        private void ProblemEighteen()
        {
            // Delete the role relationship from the user who has the email "oda@gmail.com" using LINQ.
            var userRole = _context.UserRoles.Where(ur => ur.User.Email == "oda@gmail.com").SingleOrDefault();
            _context.UserRoles.Remove(userRole);
            _context.SaveChanges();
        }

        private void ProblemNineteen()
        {
            // Delete all of the product relationships to the user with the email "oda@gmail.com" in the ShoppingCart table using LINQ.
            // HINT: Loop
            var shoppingCartProducts = _context.ShoppingCarts.Where(sc => sc.User.Email == "oda@gmail.com");
            foreach (ShoppingCart userProductRelationship in shoppingCartProducts)
            {
                _context.ShoppingCarts.Remove(userProductRelationship);
            }
            _context.SaveChanges();
        }

        private void ProblemTwenty()
        {
            // Delete the user with the email "oda@gmail.com" from the Users table using LINQ.
            var deleteUser = _context.Users.Where(u => u.Email == "oda@gmail.com");
            foreach (User user in deleteUser)
            {
                _context.Users.Remove(user);
            }
            _context.SaveChanges();
        }

        // <><><><><><><><> BONUS PROBLEMS <><><><><><><><><>

        private void BonusOne()
        {
            // Prompt the user to enter in an email and password through the console.
            // Take the email and password and check if the there is a person that matches that combination.
            // Print "Signed In!" to the console if they exists and the values match otherwise print "Invalid Email or Password.".
            Console.WriteLine("Please enter your email");
            string email = Console.ReadLine();
            Console.WriteLine("Please enter your password");
            string password = Console.ReadLine();

            var userEmail = _context.Users.Select(u => u.Email);
            var userPass = _context.Users.Select(u => u.Password);
            bool validPass = false;
            bool validEmail = false;
            foreach (var emailLogin in userEmail)
            {
                if (emailLogin == email)
                {
                    validEmail = true;
                }
            }
            foreach (var passLogin in userPass)
            {
                if (passLogin == password)
                {
                    validPass = true;
                }
            }
            if(validEmail == true && validPass == true)
            {
                Console.WriteLine("login successful");
            }else
            {
                Console.WriteLine("Incorrect email or password");
            }

        }

        //private void BonusTwo()
        //{
        //    // Write a query that finds the total of every users shopping cart products using LINQ.
        //    // Display the total of each users shopping cart as well as the total of the totals to the console.
        //    var productsum = _context.ShoppingCarts.Include(ur => ur.Product).Select(sc => sc.Product.Price).Sum();
        //    {
        //        Console.WriteLine(productsum);
        //    }

        //    ///////////////////////////////////////////////////
        //    var usersInRole = _context.UserRoles.Where(u => u.Role.RoleName == "Employee").Select(u => u.User.Id);
        //    var userShoppingCartProducts = _context.ShoppingCarts.Include(sc => sc.Product).Include(sc => sc.User).Where(sc => usersInRole.Contains(sc.UserId));​
        //    foreach (var shoppingCart in userShoppingCartProducts)
        //    {
        //        Console.WriteLine($"Email: {shoppingCart.User.Email}\n Product Name: {shoppingCart.Product.Name} \n {shoppingCart.Product.Price}\n {shoppingCart.Quantity}\n\n");
        //    }
        //    ///////////////////////////////////////////////////

        //    var customer = _context.Users.Select(s => s.Id);
         
        //    foreach (var total in customer)
        //    {
        //        var userTotal = _context.ShoppingCarts.Include(p => p.Product).Include(u => u.UserId).Include(t => customer.Contains(t.UserId).Select(p => p.Product.Price).Sum();
        //    }

        //    //customer == userID

        //    //we have the products and the user tables available. 
        //    //we are selecting the 
            
    
        //}

        //get all prod prices and quantity for sun 

        // BIG ONE
        private void BonusThree()
        {
            // 1. Create functionality for a user to sign in via the console
            // 2. If the user succesfully signs in
            // a. Give them a menu where they perform the following actions within the console
            // View the products in their shopping cart
            // View all products in the Products table
            // Add a product to the shopping cart (incrementing quantity if that product is already in their shopping cart)
            // Remove a product from their shopping cart
            // 3. If the user does not succesfully sing in
            // a. Display "Invalid Email or Password"
            // b. Re-prompt the user for credentials
            Console.WriteLine("Please enter your email");
            string email = Console.ReadLine();
            Console.WriteLine("Please enter your password");
            string password = Console.ReadLine();

            var userEmail = _context.Users.Select(u => u.Email);
            var userPass = _context.Users.Select(u => u.Password);
            bool validPass = false;
            bool validEmail = false;
            bool validLogin = false;
            foreach (var emailLogin in userEmail)
            {
                if (emailLogin == email)
                {
                    validEmail = true;
                }
            }
            foreach (var passLogin in userPass)
            {
                if (passLogin == password)
                {
                    validPass = true;
                }
            }
            if (validEmail == true && validPass == true)
            {
                Console.WriteLine("login successful");
                validLogin = true;
            }
            else
            {
                Console.WriteLine("Incorrect email or password");
                BonusThree();
            }

            if(validLogin == true)
            { 
                    Console.WriteLine("Press 1 to view cart, press 2 to view all products for sale");
                    int userChoice = int.Parse(Console.ReadLine());
                // products in cart

                if (userChoice == 1)
                {
                    var userCart = _context.ShoppingCarts.Include(ur => ur.Product).Include(ur => ur.User).Where(ur => ur.User.Email == $"{email}").Select(sc => sc.Product);
                    foreach (var item in userCart)
                    {
                        Console.WriteLine($"Cart: {item.Name} \n ${item.Price} Product ID: {item.Id}");
                    }
                    Console.WriteLine("If you would you like to delete an item/items, enter the product id");
                    int itemToDelete = int.Parse(Console.ReadLine());
                    var userIdDelete = _context.Users.Where(u => u.Email == $"{email}").Select(u => u.Id).SingleOrDefault();
                    var productIdDelete = _context.Products.Where(p => p.Id == itemToDelete).Select(p => p.Id).SingleOrDefault();
                    ShoppingCart deletedProduct = new ShoppingCart()
                    {
                        UserId = userIdDelete,
                        ProductId = productIdDelete,
                        Quantity = 0,
                    };
                    _context.ShoppingCarts.Update(deletedProduct);
                    _context.SaveChanges();
                    //Made this an update function with thoughts of adding else/if for a update/delete capability
                }
                else if (userChoice == 2)
                {
                    //All products
                    var productList = _context.Products;
                    foreach (var item in productList)
                    {
                        Console.WriteLine($"Product: {item.Name} \n Price: ${item.Price} \n Product ID {item.Id} \n");
                    }

                    //Add a product to cart
                    Console.WriteLine("Enter product ID to add it to your cart");
                    int chosenNumber = int.Parse(Console.ReadLine());
                    var userId = _context.Users.Where(u => u.Email == $"{email}").Select(u => u.Id).SingleOrDefault();
                    var productId = _context.Products.Where(p => p.Id == chosenNumber).Select(p => p.Id).SingleOrDefault();
                    int quant = _context.ShoppingCarts.Where(p => p.ProductId == chosenNumber).Where(p => p.UserId == userId).Select(q => q.Quantity).Count();
                    ShoppingCart newProduct = new ShoppingCart()
                    {
                        UserId = userId,
                        ProductId = productId,
                        Quantity = quant + 1,
                    };
                    _context.ShoppingCarts.Update(newProduct);
                    _context.SaveChanges();
                }
            }
        }

    }
}
