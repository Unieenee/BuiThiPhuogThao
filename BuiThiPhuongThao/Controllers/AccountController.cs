using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using BuiThiPhuongThao.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Data;

namespace BuiThiPhuongThao.Controllers;

     public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
    public AccountController(RoleManager<ApplicationRole> roleManager, UserManager<AppUser> userManager,ApplicationDbContext context)
    {
        _roleManager = roleManager;
        _userManager = userManager;
               _context = context;
        }
        public async Task<IActionResult> Index()
        {
           var users = _userManager.Users.ToList();
            var UserWithRole = new List<UserWithRole>();
            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                UserWithRole.Add(new UserWithRole { User = user, Role = roles.ToList() });
            }

            return View(UserWithRole);
        }
        public async Task<IActionResult> AssignRole(string UserId)
        {
            var user = await _userManager.FindByIdAsync(UserId);
            if (user == null)
            {
                return NotFound();
            }
            var UserRole = await _userManager.GetRolesAsync(user);
            var AllRole =  _roleManager.Roles.Select(r => new RoleVM { Id = r.Id, Name = r.Name }).ToList();
            var ViewModel = new AssignRoleVM
            {
                UserId = UserId,
                AllRole = AllRole,
                SelectedRole = UserRole
            };
            return View(ViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(AssignRoleVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                if (user == null)
                {
                    return NotFound();
                }

                var userRole = await _userManager.GetRolesAsync(user);

                foreach (var role in model.SelectedRole)
                {
                    var roleExist = await _roleManager.RoleExistsAsync(role);
                    if (!roleExist)
                    {
                        ModelState.AddModelError(string.Empty, $"Role '{role}' does not exist.");
                        return View(model);
                    }

                    if (!userRole.Contains(role))
                    {
                        await _userManager.AddToRoleAsync(user, role);
                    }
                }

                foreach (var role in userRole)
                {
                    if (!model.SelectedRole.Contains(role))
                    {
                        await _userManager.RemoveFromRoleAsync(user, role);
                    }
                }

                return RedirectToAction(nameof(Index), "Account");
            }

            return View(model);
        }

        // GET: Account/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identityApp = await _context.Users.FindAsync(id);
            if (identityApp == null)
            {
                return NotFound();
            }
            return View(identityApp);
        }

        // POST: Account/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FullName,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] AppUser identityApp)
        {
            if (id != identityApp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(identityApp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IdentityAppExists(identityApp.Id))
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
            return View(identityApp);
        }

        // GET: Account/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identityApp = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (identityApp == null)
            {
                return NotFound();
            }

            return View(identityApp);
        }

        // POST: Account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var identityApp = await _context.Users.FindAsync(id);
            if (identityApp != null)
            {
                _context.Users.Remove(identityApp);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IdentityAppExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

    }
