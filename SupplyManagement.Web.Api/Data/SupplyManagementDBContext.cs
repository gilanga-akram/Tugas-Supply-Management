using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;
public class SupplyManagementDBContextContext : DbContext
{
    public SupplyManagementDBContext(DbContextOptions<SupplyManagementDBContext> options) : base(options)
    {

    }

    // Table
    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountRole> AccountRoles { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Room> Rooms { get; set; }


    // Other Configuration or Fluent API
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Contraints Unique
        modelBuilder.Entity<Employee>()
                    .HasIndex(e => new
                    {
                        e.Nik,
                        e.Email,
                        e.PhoneNumber
                    }).IsUnique();

        // Create Relation

        // Employee - Booking (One to Many)
        modelBuilder.Entity<Employee>()
                    .HasMany(employee => employee.Bookings)
                    .WithOne(booking => booking.Employee)
                    .HasForeignKey(booking => booking.EmployeeGuid);

        // Booking - Room (Many to One)
        modelBuilder.Entity<Booking>()
                    .HasOne(booking => booking.Room)
                    .WithMany(room => room.Bookings)
                    .HasForeignKey(booking => booking.RoomGuid);

        // Employee - Account (One to One)
        modelBuilder.Entity<Employee>()
                    .HasOne(employee => employee.Account)
                    .WithOne(account => account.Employee)
                    .HasForeignKey<Account>(account => account.Guid);

        // Account - AccountRoles (One to Many)
        modelBuilder.Entity<Account>()
                    .HasMany(account => account.AccountRoles)
                    .WithOne(accountRole => accountRole.Account)
                    .HasForeignKey(accountRole => accountRole.AccountGuid);

        // AccountRoles - Roles (Many to One)
        modelBuilder.Entity<AccountRole>()
                    .HasOne(role => role.Role)
                    .WithMany(AccountRole => AccountRole.AccountRole)
                    .HasForeignKey(role => role.RoleGuid);
    }

}