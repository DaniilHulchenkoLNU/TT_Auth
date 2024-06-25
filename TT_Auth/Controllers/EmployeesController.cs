using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TT_Auth.Data;
using TT_Auth.Models.Entity;

namespace TT_Auth.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Authorize(Policy = "RequireRoleAdmin1")]
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Employees.Include(e => e.PeoplePartner)/*.Include(e => e.Role)*/.Include(e => e.UserInfo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.PeoplePartner)
                //.Include(e => e.Role)
                .Include(e => e.UserInfo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["PeoplePartnerId"] = new SelectList(_context.Employees, "Id", "Position");
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Description");
            ViewData["UserInfoId"] = new SelectList(_context.UserInfo, "Id", "Id");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserInfoId,Subdivision,Position,Status,PeoplePartnerId,OutOfOfficeBalance,Photo,RoleId,Id")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PeoplePartnerId"] = new SelectList(_context.Employees, "Id", "Position", employee.PeoplePartnerId);
            //ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Description", employee.RoleId);
            ViewData["UserInfoId"] = new SelectList(_context.UserInfo, "Id", "Id", employee.UserInfoId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["PeoplePartnerId"] = new SelectList(_context.Employees, "Id", "Position", employee.PeoplePartnerId);
            //ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Description", employee.RoleId);
            ViewData["UserInfoId"] = new SelectList(_context.UserInfo, "Id", "Id", employee.UserInfoId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserInfoId,Subdivision,Position,Status,PeoplePartnerId,OutOfOfficeBalance,Photo,RoleId,Id")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
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
            ViewData["PeoplePartnerId"] = new SelectList(_context.Employees, "Id", "Position", employee.PeoplePartnerId);
            //ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Description", employee.RoleId);
            ViewData["UserInfoId"] = new SelectList(_context.UserInfo, "Id", "Id", employee.UserInfoId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.PeoplePartner)
                //.Include(e => e.Role)
                .Include(e => e.UserInfo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
