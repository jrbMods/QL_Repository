using QL2026_Exam;
using System.Text.RegularExpressions;

using var db = new SchoolContext();

db.Database.EnsureDeleted();
db.Database.EnsureCreated();

db.Students.AddRange(
    new Student
    {
        Name = "John Smith",
        BirthDate = new DateTime(2000, 1, 15),
        Grade = 5.50m
    },
    new Student
    {
        Name = "Anna Brown",
        BirthDate = new DateTime(2001, 5, 10),
        Grade = 4.80m
    },
    new Student
    {
        Name = "Peter Johnson",
        BirthDate = new DateTime(1999, 3, 20),
        Grade = 5.90m
    }
);

db.SaveChanges();

Console.WriteLine("===== QUERY 1 =====");

try
{
    var result = db.Students
        .Where(s => Regex.Replace(s.Name, "[aeiou]", "").Length > 5)
        .ToList();

    Console.WriteLine($"Rows: {result.Count}");
}
catch (Exception ex)
{
    Console.WriteLine("LINQ-to-SQL failed:");
    Console.WriteLine(ex.Message);
}

var query1Fixed = db.Students
    .AsEnumerable()
    .Where(s => Regex.Replace(s.Name, "[aeiou]", "").Length > 5)
    .ToList();

Console.WriteLine($"LINQ-to-Objects works: {query1Fixed.Count}");

Console.WriteLine();
Console.WriteLine("===== QUERY 2 =====");

try
{
    var result = db.Students
        .Where(s => string.Join('-', s.Name.ToCharArray()).Contains('o'))
        .ToList();

    Console.WriteLine($"Rows: {result.Count}");
}
catch (Exception ex)
{
    Console.WriteLine("LINQ-to-SQL failed:");
    Console.WriteLine(ex.Message);
}

var query2Fixed = db.Students
    .AsEnumerable()
    .Where(s => string.Join('-', s.Name.ToCharArray()).Contains('o'))
    .ToList();

Console.WriteLine($"LINQ-to-Objects works: {query2Fixed.Count}");

Console.WriteLine();
Console.WriteLine("===== QUERY 3 =====");

try
{
    var result = db.Students
        .Where(s => new string(s.Name.Reverse().ToArray()).StartsWith('n'))
        .ToList();

    Console.WriteLine($"Rows: {result.Count}");
}
catch (Exception ex)
{
    Console.WriteLine("LINQ-to-SQL failed:");
    Console.WriteLine(ex.Message);
}

var query3Fixed = db.Students
    .AsEnumerable()
    .Where(s => new string(s.Name.Reverse().ToArray()).StartsWith('n'))
    .ToList();

Console.WriteLine($"LINQ-to-Objects works: {query3Fixed.Count}");

Console.WriteLine();
Console.WriteLine("Press any key to exit...");
Console.ReadKey();