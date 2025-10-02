using Microsoft.AspNetCore.Mvc;

public class CategoryController : Controller
{
    // Ini memungkinkan menu Master Data Kategori berfungsi dan menampilkan halaman list data.
    public IActionResult Index()
    {
        // Nantinya akan mengambil data dari database
        return View();
    }
    // Anda akan menambahkan action Create, Edit, Details, dan Delete di sini
}

public class BudgetController : Controller
{
    // Ini memungkinkan menu Master Data Budget berfungsi dan menampilkan halaman list data.
    public IActionResult Index()
    {
        // Nantinya akan mengambil data dari database
        return View();
    }
    // Anda akan menambahkan action Create, Edit, Details, dan Delete di sini
}