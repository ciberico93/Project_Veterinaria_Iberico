using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinariaWebApp.Entities;

namespace VeterinariaWebApp.DataAccess
{
    //Esta clase nos servira para configurar los roles y crear un usuario con rol por defecto
    public class UserDataSeeder
    {
        public static async Task Seed(IServiceProvider service)
        {
            // Repositorio de Usuarios
            var userManager = service.GetRequiredService<UserManager<VeterinariaIdentityUser>>();

            // Repositorio de Roles
            var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();

            // Crear Roles
            var adminRole = new IdentityRole(Constantes.RolAdmin);
            var employeeRole = new IdentityRole(Constantes.RolEmployee);

            if (!await roleManager.RoleExistsAsync(Constantes.RolAdmin))
                await roleManager.CreateAsync(adminRole);

            if (!await roleManager.RoleExistsAsync(Constantes.RolEmployee))
                await roleManager.CreateAsync(employeeRole);

            // Creamos el usuario Admin
            var adminUser = new VeterinariaIdentityUser
            {
                Nombres = "Administrador",
                Apellidos = "del Sistema",
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                PhoneNumber = "+51 980464545",
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(adminUser, "Admin1234*");
            if (result.Succeeded)
            {
                // Esto me asegura que el usuario se creó correctamente
                adminUser = await userManager.FindByEmailAsync(adminUser.Email);
                if (adminUser is not null)
                    await userManager.AddToRoleAsync(adminUser, Constantes.RolAdmin);
            }
        }
    }
}
