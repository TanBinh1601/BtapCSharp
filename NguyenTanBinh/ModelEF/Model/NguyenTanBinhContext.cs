namespace ModelEF.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NguyenTanBinhContext : DbContext
    {
        public NguyenTanBinhContext()
            : base("name=NguyenTanBinhContext")
        {
        }

        public virtual DbSet<HangSX> HangSXes { get; set; }
        public virtual DbSet<HeDH> HeDHs { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TrangThai> TrangThais { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SanPham>()
                .Property(e => e.GiaTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TrangThai>()
                .HasMany(e => e.UserAccounts)
                .WithOptional(e => e.TrangThai)
                .HasForeignKey(e => e.IDStatus);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
