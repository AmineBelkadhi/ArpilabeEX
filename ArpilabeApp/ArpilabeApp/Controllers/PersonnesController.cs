using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArpilabeApp.Data;
using ArpilabeApp.Models;

namespace ArpilabeApp.Controllers
{
    public class PersonnesController : Controller
    {
        private readonly PersonneContext _context;

        public PersonnesController(PersonneContext context)
        {
            _context = context;
        }

        // GET: Personnes
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["EmailSortParm"] = String.IsNullOrEmpty(sortOrder) ? "email_desc" : "";
            ViewData["PrenomSortParm"] = String.IsNullOrEmpty(sortOrder) ? "prenom_desc" : "";
            ViewData["CurrentFilter"] = searchString;

            var personnes = from s in _context.Personne
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                personnes = personnes.Where(s => s.Nom.Contains(searchString) || s.Prenom.Contains(searchString) || s.NumTel.Contains(searchString) || s.Email.Contains(searchString) ||
                s.Note.Contains(searchString) || s.Departement.Contains(searchString) || s.DateNaissance.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    personnes = personnes.OrderByDescending(s => s.Nom);
                    break;

                case "email_desc":
                    personnes = personnes.OrderByDescending(s => s.Email);
                    break;

                case "prenom_desc":
                    personnes = personnes.OrderByDescending(s => s.Prenom);
                    break;

                default:
                    personnes = personnes.OrderBy(s => s.Nom);
                    personnes = personnes.OrderBy(s => s.Email);
                    personnes = personnes.OrderBy(s => s.Prenom);
                    break;



            }
                    return View(await personnes.AsNoTracking().ToListAsync());
        }

        // GET: Personnes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personne = await _context.Personne
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personne == null)
            {
                return NotFound();
            }

            return View(personne);
        }

        // GET: Personnes/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: Personnes/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Prenom,Email,NumTel,Note,Departement,DateNaissance")] Personne personne)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personne);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personne);
        }

        // GET: Personnes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personne = await _context.Personne.FindAsync(id);
            if (personne == null)
            {
                return NotFound();
            }
            return View(personne);
        }

        // POST: Personnes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Prenom,Email,NumTel,Note,Departement,DateNaissance")] Personne personne)
        {
            if (id != personne.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personne);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonneExists(personne.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(personne);
        }

        // GET: Personnes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personne = await _context.Personne
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personne == null)
            {
                return NotFound();
            }

            return View(personne);
        }

        // POST: Personnes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personne = await _context.Personne.FindAsync(id);
            _context.Personne.Remove(personne);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonneExists(int id)
        {
            return _context.Personne.Any(e => e.Id == id);
        }
    }
}
