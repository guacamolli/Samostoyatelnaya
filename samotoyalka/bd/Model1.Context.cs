﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace samotoyalka.bd
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class studentsEntities : DbContext
    {
        public studentsEntities()
            : base("name=studentsEntities")
        {
        }
        private static studentsEntities _context;

        public static studentsEntities GetContext()
        {
            if (_context == null)
                _context = new studentsEntities();

            return _context;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Курсы> Курсы { get; set; }
        public virtual DbSet<Студенты> Студенты { get; set; }
    }
}