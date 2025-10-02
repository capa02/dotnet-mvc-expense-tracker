using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering; // Penting untuk SelectList
using Microsoft.EntityFrameworkCore;
using dotnet_mvc_expense_tracker.Data; // Sesuaikan dengan namespace Anda
using dotnet_mvc_expense_tracker.Models; // Sesuaikan dengan namespace Anda

public class BudgetController : Controller
{
    private readonly ApplicationDbContext _context;

    public BudgetController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Budget
    public async Task<IActionResult> Index()
    {
        // Mengambil data Budget bersamaan dengan Category (eager loading)
        var budgets = _context.Budgets.Include(b => b.Category);
        return View(await budgets.ToListAsync());
    }

    // GET: Budget/Create
    public IActionResult Create()
    {
        // Mengirim daftar kategori aktif ke View melalui ViewBag
        ViewBag.CategoryId = new SelectList(
            _context.Categories.Where(c => c.Status == "Active"),
            "Id",
            "Name"
        );
        return View();
    }

    // POST: Budget/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("CategoryId,Name,Description,TotalBudget,StartDate,EndDate,IsRepeat,Status")] Budget budget)
    {
        // Hilangkan validasi untuk Navigation Property jika ada
        ModelState.Remove("Category");

        if (ModelState.IsValid)
        {
            _context.Add(budget);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Jika model tidak valid, isi kembali ViewBag
        ViewBag.CategoryId = new SelectList(
            _context.Categories.Where(c => c.Status == "Active"),
            "Id",
            "Name",
            budget.CategoryId
        );
        return View(budget);
    }

    // Anda akan mengulangi logika serupa (dengan SelectList) untuk action Edit
}