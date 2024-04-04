
using Infrastructure.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Interface.Data
{
    //public class ApplicationDbContext : IdentityDbContext
    //{
    //    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    //        : base(options)
    //    {
    //    }
    //}







    public class ApplicationUser : IdentityUser
    {
        //public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        //{
        //    // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        //    var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        //    // Add custom user claims here
        //    userIdentity.AddClaim(new Claim("FullName", this.FirstName + " " + this.LastName));
        //    userIdentity.AddClaim(new Claim("UserID", this.Id));
        //    return userIdentity;
        //}
        [StringLength(200)]
        public string? FirstName { get; set; }
        [StringLength(200)]
        public string? LastName { get; set; }

        public int DocumentGroupID { get; set; }
        [StringLength(200)]
        public string? FatherName { get; set; }
        [StringLength(200)]

        public string? NationalCode { get; set; }
        [StringLength(200)]
        public string? IdNumber { get; set; }
        [StringLength(200)]
        public string? PersonallyCode { get; set; }
        [StringLength(200)]
        public string? CompanyName { get; set; }
        public string? ZipCode { get; set; }
        [StringLength(200)]
        public string? Address { get; set; }
        [StringLength(200)]
        public string? SecondEmail { get; set; }
        [StringLength(500)]
        public string? Image { get; set; }
        [StringLength(200)]
        public string? OtherInformation { get; set; }
        public UserType UserType { get; set; }
        [StringLength(200)]
        public string? Role { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime BirthDate { get; set; }
        public bool isActive { get; set; }
        public bool isCheckOut { get; set; }
        public string? CheckOutDescription { get; set; }
        public int BorrowNumber { get; set; }
        public string? modifiedInfo { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime HeartBeatDate { get; set; }
        public long LoginNumber { get; set; }
        public string? LastIP { get; set; }
        public string? NewEmail { get; set; }
        public int StateID { get; set; }
        public int CityID { get; set; }
        public string? BotToken { get; set; }
        public bool UseSMSService { get; set; }
        public string? ConnectionId { get; set; }
        public string? NightMode { get; set; }
        public string? CardList { get; set; }
        public string? UserColor { get; set; }
        public string? latitude { get; set; }
        public string? longitude { get; set; }
        [Display(Name = "Gmail Voice")]
        public string? VoiceGmail { get; set; }
        public bool? UserCheckProfile { get; set; }
        [Display(Name = "User Work Page")]
        public string? UrlRedirect { get; set; }
        public string? LastToken { get; set; }
        public string? LoginToken { get; set; }
        public PaymentTerms PaymentTerms { get; set; }
        public string? ParrentID { get; set; }
        public string? TimeZone { get; set; }
        public ApplicationUser()
        {   
            isActive = true;
            UserCheckProfile = false;
            PaymentTerms = PaymentTerms.PIA;
        }

    }
  

    public class UserInfo
    {
        public string Id { get; set; }
        public string USerInfo { get; set; }
    }
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }

        public ApplicationRole(string name, string description, RoleType type, string fontawesome, string title)
            : base(name)
        {
            this.description = description;
            this.type = type;
            this.title = title;
            this.fontawesome = fontawesome;
            Visible = true;
            Gift = false;
            popular = false;
            discountPercent = 0;
            NumberOfBook = 0;
            NumberOfUser = 0;
            NumberOfLibrarian = 0;
            isDefault = false;
        }
        public virtual string description { get; set; }
        /// <summary>
        /// type = 0 => users role
        /// type = 1 => service role
        /// </summary>
        public virtual RoleType type { get; set; }
        public virtual string fontawesome { get; set; }
        public virtual string title { get; set; }
        public virtual int price { get; set; }
        public virtual int mainPrice { get; set; }
        public virtual int discountPercent { get; set; }
        public virtual bool popular { get; set; }
        public virtual int dayNumber { get; set; }
        public int OrderID { get; set; }
        public bool Visible { get; set; }
        public bool Gift { get; set; }
        public bool isDefault { get; set; }
        //--------
        public int NumberOfBook { get; set; }
        public int NumberOfUser { get; set; }
        public int NumberOfLibrarian { get; set; }
    }

    public enum RoleType
    {
        Operating,
        Service,
        UsersRole,
        Ticket,
        Language,
        Website,
        Pack
    }

    //public class ApplicationDbContext : IdentityDbContext
    //{
    //    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    //        : base(options)
    //    {
    //    }
    //}

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        new public DbSet<ApplicationRole> Roles { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
              : base(options)
        {
            //   Database.SetInitializer<ApplicationDbContext>(new CreateDatabaseIfNotExists<ApplicationDbContext>());

        }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException("ModelBuilder is NULL");
            }

            base.OnModelCreating(modelBuilder);


        }
    }
    public class IdentityManager

    {
        public ApplicationDbContext _context { get; set; }
       // public RoleManager<IdentityRole> _roleManager { get; set; }
          public RoleManager<ApplicationRole> _roleManager { get; set; }
        public UserManager<ApplicationUser> _userManager { get; set; }
        public IdentityManager(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<bool> RoleExists(string name)
        {
            return await _roleManager.RoleExistsAsync(name);
        }


        public async Task<bool> CreateRole(string name, RoleType type, string description, string fontawesome = null)
        {
            // Swap ApplicationRole for IdentityRole:
            try
            {
                if (await RoleExists(name)) return true;

                var idResult = await _roleManager.CreateAsync(new ApplicationRole() { description = description, Name = name, type = type, fontawesome = fontawesome });
                return idResult.Succeeded;
            }
            catch (Exception ex)
            {

                return false;
            }
        }


        public async Task<bool> CreateRole(ApplicationRole item)
        {
            // Swap ApplicationRole for IdentityRole:
            try
            {
                if (await RoleExists(item.Name)) return true;

                var idResult = await _roleManager.CreateAsync(new ApplicationRole() { description = item.description, Name = item.Name, type = item.type, fontawesome = item.fontawesome, price = item.price, title = item.title, dayNumber = item.dayNumber, OrderID = item.OrderID, Visible = item.Visible, Gift = item.Gift, discountPercent = item.discountPercent, popular = item.popular, mainPrice = item.mainPrice, NumberOfBook = item.NumberOfBook, NumberOfLibrarian = item.NumberOfLibrarian, NumberOfUser = item.NumberOfUser, isDefault = item.isDefault });
                return idResult.Succeeded;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public async Task<bool> CreateUser(ApplicationUser user, string password)
        {
            try
            {
                var idResult = await _userManager.CreateAsync(user, password);

                return idResult.Succeeded;
            }
            catch (Exception ex)
            {
                return false;
            }


        }


        public async Task<bool> AddUserToRole(string userId, string roleName)
        {
            var userApp = await _userManager.FindByIdAsync(userId);
            if (await _userManager.IsInRoleAsync(userApp, roleName))
                return true;

            var Result = await _userManager.AddToRoleAsync(userApp, roleName);
            return Result.Succeeded;
        }


        public async Task<bool> DeleteUserRole(string userId, string roleName)
        {
            var userApp = await _userManager.FindByIdAsync(userId);
            if (!(await _userManager.IsInRoleAsync(userApp, roleName)))//اگر وجود نداشت پاکش کن
                return true;

            var Result = await _userManager.IsInRoleAsync(userApp, roleName);
            return Result;
        }



   


        public async Task<bool> UpdateRole(string roleId, string Symbol, string Description, string fontawesome = null)
        {
            try
            {
                var OldRole =await _roleManager.FindByIdAsync(roleId);
                OldRole.Name = Symbol;
                OldRole.fontawesome = fontawesome;
                OldRole.description = Description + " ";
                _context.Update(OldRole);
                return Convert.ToBoolean(_context.SaveChanges());
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateRole(ApplicationRole item)
        {
            try
            {
                var OldRole =await _roleManager.FindByIdAsync(item.Id);
                OldRole.Name = item.Name;
                OldRole.fontawesome = item.fontawesome;
                OldRole.description = item.description + " ";
                OldRole.dayNumber = item.dayNumber;
                OldRole.title = item.title;
                OldRole.type = item.type;
                OldRole.OrderID = item.OrderID;
                OldRole.Visible = item.Visible;
                OldRole.Gift = item.Gift;
                OldRole.price = item.price;
                OldRole.mainPrice = item.mainPrice;
                OldRole.popular = item.popular;
                OldRole.discountPercent = item.discountPercent;
                OldRole.NumberOfBook = item.NumberOfBook;
                OldRole.NumberOfLibrarian = item.NumberOfLibrarian;
                OldRole.NumberOfUser = item.NumberOfUser;
                OldRole.isDefault = item.isDefault;
                _context.Update(OldRole);
                return Convert.ToBoolean(_context.SaveChanges());
            }
            catch (Exception ex)
            {
                return false;
            }
        }
      
    
    }



}