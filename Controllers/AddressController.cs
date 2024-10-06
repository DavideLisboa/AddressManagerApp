using Microsoft.AspNetCore.Mvc;
using AddressManagerApp.Models;
using AddressManagerApp.Services;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AddressManagerApp.Controllers
{
    public class AddressController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ViaCepService _viaCepService;

        public AddressController(ApplicationDbContext context, ViaCepService viaCepService)
        {
            _context = context;
            _viaCepService = viaCepService;
        }

        // List all addresses
        public async Task<IActionResult> Index()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var addresses = await _context.Enderecos.Where(a => a.UsuarioId == userId).ToListAsync();
            return View(addresses);
        }

        // Display the form to add a new address
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Handle the submission of the new address form
        [HttpPost]
        public async Task<IActionResult> Create(Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                endereco.UsuarioId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                _context.Add(endereco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(endereco);
        }

        // Display the form to edit an existing address
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var endereco = await _context.Enderecos.FindAsync(id);
            if (endereco == null || endereco.UsuarioId != int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                return NotFound();
            }
            return View(endereco);
        }

        // Handle the submission of the edit form
        [HttpPost]
        public async Task<IActionResult> Edit(Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                _context.Update(endereco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(endereco);
        }

        // View address details
        public async Task<IActionResult> Details(int id)
        {
            var endereco = await _context.Enderecos.FindAsync(id);
            if (endereco == null || endereco.UsuarioId != int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                return NotFound();
            }
            return View(endereco);
        }

        // Handle address deletion
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var endereco = await _context.Enderecos.FindAsync(id);
            if (endereco != null && endereco.UsuarioId == int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                _context.Enderecos.Remove(endereco);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
