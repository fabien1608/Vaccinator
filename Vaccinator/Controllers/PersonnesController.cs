using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vaccinator.Models;

namespace Vaccinator.Controllers
{
    public class PersonnesController : Controller
    {
        private readonly ContexteBDD _context = new ContexteBDD();


        // GET: Personnes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Personnes.ToListAsync());
        }

        // GET: Personnes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personne = await _context.Personnes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personne == null)
            {
                return NotFound();
            }



            var injection = _context.Injection.Include(e => e.Vaccin).Where(e => e.Personne.Id.Equals(id));
            ViewBag.injection = injection;

            return View(personne);
        }

        // GET: Personnes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Personnes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Prenom,DateDeNaissance,sexe,residence")] Personne personne)
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

            var personne = await _context.Personnes.FindAsync(id);
            if (personne == null)
            {
                return NotFound();
            }
            return View(personne);
        }

        // POST: Personnes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Prenom,DateDeNaissance,sexe,residence")] Personne personne)
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

            var personne = await _context.Personnes
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
            var personne = await _context.Personnes.FindAsync(id);
            _context.Personnes.Remove(personne);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonneExists(int id)
        {
            return _context.Personnes.Any(e => e.Id == id);
        }

        // GET: Personnes/NoGrippe
        public async Task<IActionResult> NoGrippe()
        {

            var injections = _context.Injection
                .Include(i => i.Vaccin)
                .Include(i => i.Personne)
                .Where(i => i.Vaccin.TypeV.Equals("Grippe"))
                .ToList();

            var personne = _context.Personnes.ToList();

            for (int i = 0; i < injections.Count(); i++)
            {
                Injection CurrentI = injections[i];
                Personne user = personne.Find(x => x.Id.Equals(CurrentI.Personne.Id));
                if (user != null)
                {
                    personne.Remove(user);
                }
            }

            return View(personne);
            
        }


        // GET: Personnes/NoCovid
        public async Task<IActionResult> NoCovid()
        {

            var injections = _context.Injection
                .Include(i => i.Vaccin)
                .Include(i => i.Personne)
                .Where(i => i.Vaccin.TypeV.Equals("Covid-19"))
                .ToList();

            var personne = _context.Personnes.ToList();

            for (int i = 0; i < injections.Count(); i++)
            {
                Injection CurrentI = injections[i];
                Personne user = personne.Find(x => x.Id.Equals(CurrentI.Personne.Id));
                if (user != null)
                {
                    personne.Remove(user);
                }
            }

            return View(personne);

        }

        // GET: Personnes/GetRetard
        public async Task<IActionResult> GetRetard()
        {

            var injections = _context.Injection
                .Include(i => i.Vaccin)
                .Include(i => i.Personne)
                .ToList();

            List<Injection> lastI = new List<Injection>();

            
            for (int i = 0; i < injections.Count(); i++)
            {
                Injection CurrentI = injections[i];
                Injection injectionFound = lastI.Find(x => x.Personne.Id.Equals(CurrentI.Personne.Id) && x.Vaccin.Id.Equals(CurrentI.Vaccin.Id));
                
                if (injectionFound != null)
                {
                    
                    if (CurrentI.DateRappel > injectionFound.DateRappel)
                    {
                        lastI.Remove(injectionFound);
                        lastI.Add(CurrentI);
                    }
                   
                }
                else 
                {
                    lastI.Add(CurrentI);
                }
            }

            DateTime now = DateTime.Now;
            var InjectionLate = lastI.Where(i => i.DateRappel < now);
            return View(InjectionLate);
        }

    }
}
