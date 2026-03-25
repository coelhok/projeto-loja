using Microsoft.AspNetCore.Mvc;
using ProjectStore.Domain.Entities;
using ProjectStore.Domain.Interfaces;

namespace ProjectStore.Web.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        // GET /Client
        public async Task<IActionResult> Index()
        {
            var clients = await _clientRepository.GetAllAsync();
            return View(clients);
        }

        // GET /Client/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST /Client/Create
        [HttpPost]
        public async Task<IActionResult> Create(Client client)
        {
            client.RegistrationDate = DateTime.Now;
            await _clientRepository.CreateAsync(client);
            return RedirectToAction("Index");
        }

        // GET /Client/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            if (client == null) return NotFound();
            return View(client);
        }

        // POST /Client/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(Client client)
        {
            await _clientRepository.UpdateAsync(client);
            return RedirectToAction("Index");
        }

        // POST /Client/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _clientRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}