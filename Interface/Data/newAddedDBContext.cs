using Infrastructure.Entity;
using Infrastructure.Entity.newAdded;
using Microsoft.EntityFrameworkCore;

namespace Interface.Data
{
    public class newAddedDBContext : DbContext
    {
        public newAddedDBContext(DbContextOptions<newAddedDBContext> options)
               : base(options)
        {
        }

        #region Price

        public DbSet<GlassTypeEnt> GlassTypes { get; set; }
        public DbSet<FabricationCategoryEnt> FabricationCategories { get; set; }
        public DbSet<Glass_FabricationEnt> Glass_Fabrications { get; set; }
        public DbSet<FabricationEnt> Fabrications { get; set; }
        public DbSet<GlassThicknesEnt> GlassThicknes { get; set; }
        public DbSet<GlassStrengthEnt> GlassStrengths { get; set; }
        public DbSet<GlassOptionEnt> GlassOptions { get; set; }
        public DbSet<GlassPriceEnt> GlassPrices { get; set; }
        public DbSet<FabricationPriceEnt> FabricationPrices { get; set; }
        public DbSet<GlassExtraPriceEnt> GlassExtraPrice { get; set; }

        public DbSet<GlassType_OptionEnt> GlassType_Options { get; set; }
        public DbSet<GlassType_StrengthEnt> GlassType_Strengths { get; set; }
        public DbSet<GlassType_ThicknesEnt> GlassType_Thickness { get; set; }

        #endregion Price

        #region newAdded

        public DbSet<newGlassType> newGlassType { get; set; }
        public DbSet<newFrameType> newFrameType { get; set; }

        #endregion newAdded

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //  modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
            //-----Change Table's Name

            //     modelBuilder.Entity<ApplicationUser>().ToTable("Users", "dbo");

            #region Glass Price

            modelBuilder.Entity<GlassTypeEnt>().ToTable("GlassTypes", "dbo");
            modelBuilder.Entity<FabricationEnt>().ToTable("Fabrications", "dbo");
            modelBuilder.Entity<Glass_FabricationEnt>().ToTable("Glass_Fabrications", "dbo");
            modelBuilder.Entity<FabricationCategoryEnt>().ToTable("FabricationCategories", "dbo");
            modelBuilder.Entity<GlassThicknesEnt>().ToTable("GlassThicknes", "dbo");
            modelBuilder.Entity<GlassStrengthEnt>().ToTable("GlassStrengths", "dbo");
            modelBuilder.Entity<GlassOptionEnt>().ToTable("GlassOptions", "dbo");
            modelBuilder.Entity<GlassPriceEnt>().ToTable("GlassPrices", "dbo");
            modelBuilder.Entity<FabricationPriceEnt>().ToTable("FabricationPrices", "dbo");
            modelBuilder.Entity<GlassExtraPriceEnt>().ToTable("GlassExtraPrices", "dbo");

            modelBuilder.Entity<GlassType_OptionEnt>().ToTable("GlassType_Option", "dbo");
            modelBuilder.Entity<GlassType_ThicknesEnt>().ToTable("GlassType_Thicknes", "dbo");
            modelBuilder.Entity<GlassType_StrengthEnt>().ToTable("GlassType_Strength", "dbo");

            #endregion Glass Price

            //#region SMS
            //modelBuilder.Entity<SMSAccountEnt>().ToTable("SMSAccount", "dbo");
            //modelBuilder.Entity<SMSContactEnt>().ToTable("SMSContacts", "dbo");
            //modelBuilder.Entity<SMSGroupEnt>().ToTable("SMSGroups", "dbo");
            //modelBuilder.Entity<Group_ContactEnt>().ToTable("Group_Contact", "dbo");
            //modelBuilder.Entity<SMSGroupNoNameEnt>().ToTable("SMSGroupNoNames", "dbo");
            //modelBuilder.Entity<SendSMSEnt>().ToTable("SendSMS", "dbo");
            //modelBuilder.Entity<SendSMSGroupEnt>().ToTable("SendSMSGroup", "dbo");
            //#endregion
        }
    }
}