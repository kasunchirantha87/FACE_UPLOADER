using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FaceUploader.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Drawing;

namespace FaceUploader.Controllers
{
    public class FaceMasterController : Controller
    {
        private readonly FuContext _context;

        public FaceMasterController(FuContext context)
        {
            _context = context;
        }

        // GET: FaceMasters
        public async Task<IActionResult> Index()
        {
            return View(await _context.FaceMaster.ToListAsync());
        }

        public async Task<IActionResult> UploadP0ToDirectory(List<IFormFile> files)
        {
            if (files.Count > 0)
            {

                foreach (var file in files)
                {

                    string tempFileName = file.FileName;
                    var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\P0", file.FileName);

                    int count = 1;

                    string fileNameOnly = Path.GetFileNameWithoutExtension(fullPath);
                    string extension = Path.GetExtension(fullPath);
                    string path = Path.GetDirectoryName(fullPath);
                    string newFullPath = fullPath;

                    if (!string.Equals(extension, ".jpg", StringComparison.OrdinalIgnoreCase)
                        && !string.Equals(extension, ".png", StringComparison.OrdinalIgnoreCase)
                        && !string.Equals(extension, ".gif", StringComparison.OrdinalIgnoreCase)
                        && !string.Equals(extension, ".jpeg", StringComparison.OrdinalIgnoreCase))
                    {
                        return View("Create");
                    }
                    else
                    {
                        while (System.IO.File.Exists(newFullPath))
                        {
                            tempFileName = string.Format("{0}({1})", fileNameOnly, count++);
                            newFullPath = Path.Combine(path, tempFileName + extension);
                            tempFileName = tempFileName + extension;
                        }

                        using (var stream = new FileStream(newFullPath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        return RedirectToAction("DisplayP0", "FaceMaster", new { imageName = tempFileName });
                    }

                }
            }
            return View("Create");

        }

        public ActionResult DisplayP0(string imageName)
        {

            var directory = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\P0"));
            var myFile = directory.GetFiles(imageName).FirstOrDefault();


            ViewBag.fileNameP0 = myFile.Name;
            ViewBag.pathP0 = "/images/P0/" + myFile.Name;

            return View("Create");
        }

        public async Task<IActionResult> UploadP45ToDirectory(IFormFile file)
        {


            if (file.Length > 0)
            {
                string tempFileName = file.FileName;
                var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\P45", file.FileName);

                int count = 1;

                string fileNameOnly = Path.GetFileNameWithoutExtension(fullPath);
                string extension = Path.GetExtension(fullPath);
                string path = Path.GetDirectoryName(fullPath);
                string newFullPath = fullPath;

                if (!string.Equals(extension, ".jpg", StringComparison.OrdinalIgnoreCase)
                    && !string.Equals(extension, ".png", StringComparison.OrdinalIgnoreCase)
                    && !string.Equals(extension, ".gif", StringComparison.OrdinalIgnoreCase)
                    && !string.Equals(extension, ".jpeg", StringComparison.OrdinalIgnoreCase))
                {
                    return View("Create");
                }
                else
                {
                    while (System.IO.File.Exists(newFullPath))
                    {
                        tempFileName = string.Format("{0}({1})", fileNameOnly, count++);
                        newFullPath = Path.Combine(path, tempFileName + extension);
                        tempFileName = tempFileName + extension;
                    }

                    using (var stream = new FileStream(newFullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    return RedirectToAction("DisplayP45", "FaceMaster", new { imageName = tempFileName });
                }

            }

            return View("Create");

        }

        public ActionResult DisplayP45(string imageName)
        {

            var directory = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\P45"));
            var myFile = directory.GetFiles(imageName).FirstOrDefault();


            ViewBag.fileNameP45 = myFile.Name;
            ViewBag.pathP45 = "/images/P45/" + myFile.Name;

            return View("Create");
        }

        public async Task<IActionResult> UploadP90ToDirectory(IFormFile file)
        {


            if (file.Length > 0)
            {
                string tempFileName = file.FileName;
                var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\P90", file.FileName);

                int count = 1;

                string fileNameOnly = Path.GetFileNameWithoutExtension(fullPath);
                string extension = Path.GetExtension(fullPath);
                string path = Path.GetDirectoryName(fullPath);
                string newFullPath = fullPath;

                if (!string.Equals(extension, ".jpg", StringComparison.OrdinalIgnoreCase)
                    && !string.Equals(extension, ".png", StringComparison.OrdinalIgnoreCase)
                    && !string.Equals(extension, ".gif", StringComparison.OrdinalIgnoreCase)
                    && !string.Equals(extension, ".jpeg", StringComparison.OrdinalIgnoreCase))
                {
                    return View("Create");
                }
                else
                {
                    while (System.IO.File.Exists(newFullPath))
                    {
                        tempFileName = string.Format("{0}({1})", fileNameOnly, count++);
                        newFullPath = Path.Combine(path, tempFileName + extension);
                        tempFileName = tempFileName + extension;
                    }

                    using (var stream = new FileStream(newFullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    return RedirectToAction("DisplayP90", "FaceMaster", new { imageName = tempFileName });
                }

            }

            return View("Create");

        }

        public ActionResult DisplayP90(string imageName)
        {

            var directory = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\P90"));
            var myFile = directory.GetFiles(imageName).FirstOrDefault();


            ViewBag.fileNameP90 = myFile.Name;
            ViewBag.pathP90 = "/images/P90/" + myFile.Name;

            return View("Create");
        }

        // GET: FaceMasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faceMaster = await _context.FaceMaster
                .FirstOrDefaultAsync(m => m.Id == id);
            if (faceMaster == null)
            {
                return NotFound();
            }

            return View(faceMaster);
        }

        // GET: FaceMasters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FaceMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,P0,P45,P90")] FaceMaster faceMaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(faceMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(faceMaster);
        }

        // GET: FaceMasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faceMaster = await _context.FaceMaster.FindAsync(id);
            if (faceMaster == null)
            {
                return NotFound();
            }
            return View(faceMaster);
        }

        // POST: FaceMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,P0,P45,P90")] FaceMaster faceMaster)
        {
            if (id != faceMaster.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(faceMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FaceMasterExists(faceMaster.Id))
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
            return View(faceMaster);
        }

        // GET: FaceMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faceMaster = await _context.FaceMaster
                .FirstOrDefaultAsync(m => m.Id == id);
            if (faceMaster == null)
            {
                return NotFound();
            }

            return View(faceMaster);
        }

        // POST: FaceMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var faceMaster = await _context.FaceMaster.FindAsync(id);
            _context.FaceMaster.Remove(faceMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FaceMasterExists(int id)
        {
            return _context.FaceMaster.Any(e => e.Id == id);
        }
    }
}
