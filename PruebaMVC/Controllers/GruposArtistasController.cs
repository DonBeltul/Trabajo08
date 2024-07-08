using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using PruebaMVC.Models;
using PruebaMVC.Services.Repositorio;

namespace PruebaMVC.Controllers
{
    public class GruposArtistasController(
        IGenericRepositorio<GruposArtista> context,
        IGenericRepositorio<Artista> contextArtista,
        IGenericRepositorio<Grupo> contextGrupo)
        : Controller
    {
        // GET: GruposArtistas
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["ArtistaSortParm"] = sortOrder == "NombreArtista" ? "artista_desc" : "NombreArtista";
            ViewData["GrupoSortParm"] = sortOrder == "NombreGrupo" ? "grupo_desc" : "NombreGrupo";

            var TodoGrupoCContext = await context.DameTodos();
            
            foreach (var item in TodoGrupoCContext)
            {
                if (item.ArtistasId != null) item.Artistas = await contextArtista.DameUno((int)item.ArtistasId);
                if (item.GruposId != null) item.Grupos = await contextGrupo.DameUno((int)item.GruposId);
            }

            switch (sortOrder)
            {
                case "artista_desc":
                    TodoGrupoCContext = TodoGrupoCContext.OrderByDescending(s => s.Artistas.Nombre).ToList();
                    break;
                case "NombreArtista":
                    TodoGrupoCContext = TodoGrupoCContext.OrderBy(s => s.Artistas.Nombre).ToList();
                    break;
                case "grupo_desc":
                    TodoGrupoCContext = TodoGrupoCContext.OrderByDescending(s => s.Grupos.Nombre).ToList();
                    break;
                case "NombreGrupo":
                    TodoGrupoCContext = TodoGrupoCContext.OrderBy(s => s.Grupos.Nombre).ToList();
                    break;
            }

            return View(TodoGrupoCContext);
        }

        // GET: GruposArtistas/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            var grupoArtistaDetalles = await context.DameTodos();

            foreach (var item in grupoArtistaDetalles)
            {
                item.Artistas = await contextArtista.DameUno((int)item.ArtistasId);
                item.Grupos = await contextGrupo.DameUno((int)item.GruposId);
            }
            var lista = grupoArtistaDetalles.FirstOrDefault(m => m.Id == id);
            if (lista == null)
            {
                return NotFound();
            }

            return View(lista);
        }

        // GET: GruposArtistas/Create
        public async Task<IActionResult> Create()
        {
            var contextArt = await contextArtista.DameTodos();
            var contextGru = await contextGrupo.DameTodos();
            ViewData["ArtistasId"] = new SelectList(contextArt.OrderBy(x => x.Nombre), "Id", "Nombre");
            ViewData["GruposId"] = new SelectList(contextGru.OrderBy(x => x.Nombre), "Id", "Nombre");
            return View();
        }

        // POST: GruposArtistas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ArtistasId,GruposId")] GruposArtista gruposArtista)
        {
            if (ModelState.IsValid)
            {
                await context.Agregar(gruposArtista);
                return RedirectToAction(nameof(Index));
            }
            var contextArt = await contextArtista.DameTodos();
            var contextGru = await contextGrupo.DameTodos();
            ViewData["ArtistasId"] = new SelectList(contextArt.OrderBy(x => x.Nombre), "Id", "Nombre", gruposArtista.ArtistasId);
            ViewData["GruposId"] = new SelectList(contextGru.OrderBy(x => x.Nombre), "Id", "Nombre", gruposArtista.GruposId);
            return View(gruposArtista);
        }

        // GET: GruposArtistas/Edit/5
        public async Task<IActionResult> Edit(int? id, GruposArtista artistaGrupo)
        {

            if (id == null)
            {
                return NotFound();
            }

            var gruposArtista = await context.DameUno((int)id);
            if (gruposArtista == null)
            {
                return NotFound();
            }

            var contextArt = await contextArtista.DameTodos();
            var contextGru = await contextGrupo.DameTodos();
            ViewData["ArtistasId"] = new SelectList(contextArt.OrderBy(x => x.Nombre), "Id", "Nombre", gruposArtista.ArtistasId);
            ViewData["GruposId"] = new SelectList(contextGru.OrderBy(x => x.Nombre), "Id", "Nombre", gruposArtista.GruposId);
           
            return View(gruposArtista);
        }

        // POST: GruposArtistas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ArtistasId,GruposId")] GruposArtista gruposArtista)
        {
            if (id != gruposArtista.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await context.Modificar(id, gruposArtista);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GruposArtistaExists(gruposArtista.Id).Result)
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

            var contextArt = await contextArtista.DameTodos();
            var contextGru = await contextGrupo.DameTodos();
            ViewData["ArtistasId"] = new SelectList(contextArt.OrderBy(x => x.Nombre), "Id", "Nombre", gruposArtista.ArtistasId);
            ViewData["GruposId"] = new SelectList(contextGru.OrderBy(x => x.Nombre), "Id", "Nombre", gruposArtista.GruposId);
            return View(gruposArtista);
        }

        // GET: GruposArtistas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var gruposArtista = await context.DameTodos();

            foreach (var item in gruposArtista)
            {
                item.Artistas = await contextArtista.DameUno((int)item.ArtistasId);
                item.Grupos = await contextGrupo.DameUno((int)item.GruposId);
            }
            var lista = gruposArtista.FirstOrDefault(m => m.Id == id);
            if (lista == null)
            {
                return NotFound();
            }
            return View(lista);
        }

        // POST: GruposArtistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gruposArtista = await context.DameUno(id);
            if (gruposArtista != null)
            {
                await context.Borrar(id);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<bool> GruposArtistaExists(int id)
        {
            var vista = await contextArtista.DameTodos();
            return vista.Any(e => e.Id == id);
        }
    }
}
