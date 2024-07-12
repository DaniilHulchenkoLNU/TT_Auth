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
using TT_Auth.Models.ENUMS;

namespace TT_Auth.Controllers
{
    [Authorize(Policy = "RequireRoleAdmin1")]
    public class LeaveRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeaveRequestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LeaveRequests
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.LeaveRequests.Include(l => l.Employee);
            return View(await applicationDbContext.Where(a=>a.Status=="New").ToListAsync());
        }

        public async Task<IActionResult> Arhive(SortOptions ?sortOption = null)
        {
            //var applicationDbContext = _context.LeaveRequests.Include(l => l.Employee);
            IQueryable<LeaveRequests> applicationDbContext = _context.LeaveRequests.Include(l => l.Employee);
            switch (sortOption)
            {
                case SortOptions.ByDate:
                    applicationDbContext = applicationDbContext.OrderBy(e => e.EndDate);
                    break;
                case SortOptions.ByName:
                    applicationDbContext = applicationDbContext.OrderBy(e => e.Employee.UserInfo.UserName);
                    break;
                case SortOptions.ByRole:
                    applicationDbContext = applicationDbContext.OrderBy(e => e.Employee.UserInfo.Role.RoleName);
                    break;
                default:
                    applicationDbContext = applicationDbContext.OrderBy(e => e.StartDate);
                    break;
            }
            return View("Index", await applicationDbContext.ToListAsync());
        }


        // GET: LeaveRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveRequests = await _context.LeaveRequests
                .Include(l => l.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveRequests == null)
            {
                return NotFound();
            }

            return View(leaveRequests);
        }

        // GET: LeaveRequests/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Position");
            return View();
        }

        // POST: LeaveRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,AbsenceReason,StartDate,EndDate,Status,Comment,Id")] LeaveRequests leaveRequests)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leaveRequests);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Position", leaveRequests.EmployeeId);
            return View(leaveRequests);
        }

        // GET: LeaveRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveRequests = await _context.LeaveRequests.FindAsync(id);
            if (leaveRequests == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Position", leaveRequests.EmployeeId);
            return View(leaveRequests);
        }

        // POST: LeaveRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,AbsenceReason,StartDate,EndDate,Status,Comment,Id")] LeaveRequests leaveRequests)
        {
            if (id != leaveRequests.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leaveRequests);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveRequestsExists(leaveRequests.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Position", leaveRequests.EmployeeId);
            return View(leaveRequests);
        }

        // GET: LeaveRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveRequests = await _context.LeaveRequests
                .Include(l => l.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveRequests == null)
            {
                return NotFound();
            }

            return View(leaveRequests);
        }

        // POST: LeaveRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leaveRequests = await _context.LeaveRequests.FindAsync(id);
            if (leaveRequests != null)
            {
                _context.LeaveRequests.Remove(leaveRequests);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveRequestsExists(int id)
        {
            return _context.LeaveRequests.Any(e => e.Id == id);
        }
    }
}
