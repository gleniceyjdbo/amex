// Create a repository object that works with a list of strings
var repo = new Repository<string>();

// Add some items to the repository
repo.Add("Hello");
repo.Add("World");
repo.Add("example");

// Print the number of items in the repository
Console.WriteLine(repo.Count); // Output: 3

// Remove all the items from the repository
repo.RemoveAll();

// Print the number of items in the repository
Console.WriteLine(repo.Count); // Output: 0
