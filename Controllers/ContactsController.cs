using ContactsAdm.Models;
using ContactsAdm.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ContactsAdm.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactsRepository _contactsRepository;
        public ContactsController( IContactsRepository contactsRepository ) 
        {
            _contactsRepository = contactsRepository;
        }

        public async Task<IActionResult> Index()
        {
            var  contacts = await _contactsRepository.ListAll();
            return View(contacts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContactModel contato) 
        {
            if (ModelState.IsValid)
            {
                await _contactsRepository.Create(contato);
                TempData["SuccessMessage"] = "Contato cadastrado com sucesso";
                return RedirectToAction("Index");
            }
            return View(contato);   
        }

        public async  Task<IActionResult> Edit(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            ContactModel contact = await _contactsRepository.GetById(id);
            
            if(contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        [HttpPost]
        public async  Task<IActionResult> Edit(Guid id, ContactModel contact)
        {
            if(id == Guid.Empty)
            {
                return NotFound();
            }

            ContactModel contactUpdated = await _contactsRepository.Update(contact);

            if(contactUpdated == null)
            {
                return BadRequest();
            }

            await _contactsRepository.Update(contactUpdated);
            TempData["InfoMessage"] = "Contato alterado com sucesso";
            return RedirectToAction(nameof(Index));
        }

        public async  Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            ContactModel contact = await _contactsRepository.GetById(id);

            if (contact == null)
            {
                return BadRequest();
            }

            return View(contact);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> ConfirmDeletion(Guid id) 
        {
            ContactModel contact = await _contactsRepository.GetById(id);
            await _contactsRepository.Delete(contact);
            TempData["InfoMessage"] = "Contato deletado com sucesso";
            return RedirectToAction(nameof(Index));
        }

    }
}
