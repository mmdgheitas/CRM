using Infrastructure.Entity;
using Infrastructure.Repository;
using Infrastructure.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Implement
{
    public class FactorService : IFactorService
    {
        IRepositoryBase<FactorEnt, int> _FactorRepo;
        IRepositoryBase<Factor_ItemEnt, long> _Factor_ItemRepo;
        IRepositoryBase<FactorItem_ImageEnt, long> _factorItem_ImageRepo;
        IRepositoryBase<ItemEnt, long> _itemRepo;
        IRepositoryBase<ItemModifireEnt, long> _itemModifiresRepo;
        IRepositoryBase<ItemCategoryEnt, int> _itemCategoryRepo;
        IRepositoryBase<Item_ItemModifireEnt, long> _item_itemModifireRepo;
        IRepositoryBase<ItemModifireAnswerEnt, long> _itemModifireAnswerRepo;
        IRepositoryBase<CustomerOrderToEnt, int> _orderToRepo;
        IRepositoryBase<FactorNoteEnt, long> _factorNoteRepo;
        IRepositoryBase<FactorInstallerEnt, int> _factorInstallerRepo;
        IRepositoryBase<CustomerRequestEnt, int> _customerRequestRepo;
        IRepositoryBase<CustomerRequest_ItemEnt, int> _customerRequest_itemRepo;
        IRepositoryBase<RequestEstimateAppointmentEnt, long> _requestEstimateAppointmentRepo;
        IRepositoryBase<LaborCostEnt, int> _laborCostRepo;
        IRepositoryBase<CustomerOrderToEnt, int> _customerOrderToRepo;
        IRepositoryBase<CityEnt, int> _cityRepo;
        IRepositoryBase<StateEnt, int> _stateRepo;
        IRepositoryBase<PaymentEnt, long> _paymentRepo;
        IRepositoryBase<FactorTaskEnt, long> _factorTaskRepo;
        IRepositoryBase<ResellerPermitEnt, long> _resellerPermitRepo;

        IRepositoryBase<LastActivityEnt, long> _lasdtActivirtRepo;




        //  List<FactorEnt> factorList;
        public FactorService(IRepositoryBase<FactorEnt, int> _FactorRepo,
            IRepositoryBase<Factor_ItemEnt, long> _Factor_itemRepo,
            IRepositoryBase<ItemEnt, long> itemRepo,
            IRepositoryBase<ItemModifireEnt, long> itemModifiresRepo,
            IRepositoryBase<ItemCategoryEnt, int> itemCategoryRepo,
            IRepositoryBase<Item_ItemModifireEnt, long> item_ItemModifireRepo,
            IRepositoryBase<ItemModifireAnswerEnt, long> itemModifireAnswerRepo,
            IRepositoryBase<FactorItem_ImageEnt, long> factorItem_ImageRepo,
            IRepositoryBase<CustomerOrderToEnt, int> orderToRepo, IRepositoryBase<FactorNoteEnt, long> factorNoteRepo,
            IRepositoryBase<FactorInstallerEnt, int> factorInstallerRepo,
            IRepositoryBase<RequestEstimateAppointmentEnt, long> requestEstimateAppointmentRepo,
            IRepositoryBase<CustomerRequestEnt, int> customerRequestRepo,
            IRepositoryBase<CustomerRequest_ItemEnt, int> customerRequestItemRepo,
            IRepositoryBase<LaborCostEnt, int> laborCostRepo,
            IRepositoryBase<CityEnt, int> cityRepo,
             IRepositoryBase<StateEnt, int> stateRepo,
            IRepositoryBase<PaymentEnt, long> paymentRepo,
              IRepositoryBase<FactorTaskEnt, long> factorTaskRepo,
                 IRepositoryBase<ResellerPermitEnt, long> resellerPremitRepo,
            IRepositoryBase<CustomerOrderToEnt, int> customerOrderToRepo,
            IRepositoryBase<JobTypeEnt, int> jobType,
                 IRepositoryBase<FactorJobTypeEnt, int> factorjobType,
                  IRepositoryBase<LastActivityEnt, long> lastActivityRepo
            )

        {
            this._FactorRepo = _FactorRepo;
            this._Factor_ItemRepo = _Factor_itemRepo;
            this._itemRepo = itemRepo;
            this._itemModifiresRepo = itemModifiresRepo;
            this._itemCategoryRepo = itemCategoryRepo;
            this._item_itemModifireRepo = item_ItemModifireRepo;
            this._itemModifireAnswerRepo = itemModifireAnswerRepo;
            this._factorItem_ImageRepo = factorItem_ImageRepo;
            this._factorNoteRepo = factorNoteRepo;
            this._orderToRepo = orderToRepo;
            this._cityRepo = cityRepo;
            this._stateRepo = stateRepo;
            this._lasdtActivirtRepo = lastActivityRepo;
            this._factorInstallerRepo = factorInstallerRepo;
            this._requestEstimateAppointmentRepo = requestEstimateAppointmentRepo;
            this._customerRequestRepo = customerRequestRepo;
            this._laborCostRepo = laborCostRepo;
            this._paymentRepo = paymentRepo;
            this._customerRequest_itemRepo = customerRequestItemRepo;
            this._customerOrderToRepo = customerOrderToRepo;
            this._factorTaskRepo = factorTaskRepo;
            this._resellerPermitRepo = resellerPremitRepo;

            //  factorList = _FactorRepo.FromSql("SELECT * FROM Factors ;");
        }

        //public FactorService(IRepositoryBase<FactorEnt, int> _FactorRepo, IRepositoryBase<Factor_ItemEnt, long> _Factor_itemRepo, IRepositoryBase<ItemModifireEnt, long> _itemModifireRepo, IRepositoryBase<ItemModifireAnswerEnt, long> itemModifireAnswerRepo)
        //{
        //    this._FactorRepo = _FactorRepo;
        //    this._Factor_ItemRepo = _Factor_itemRepo;
        //    this._itemModifiresRepo = _itemModifireRepo;
        //    this._itemModifireAnswerRepo = itemModifireAnswerRepo;
        //}
        //public FactorService(IRepositoryBase<FactorEnt, int> _FactorRepo, IRepositoryBase<Factor_ItemEnt, long> _Factor_itemRepo)
        //{
        //    this._FactorRepo = _FactorRepo;
        //    this._Factor_ItemRepo = _Factor_itemRepo;

        //}
        //public FactorService(IRepositoryBase<FactorEnt, int> _FactorRepo)
        //{
        //    this._FactorRepo = _FactorRepo;


        //}
        public bool AddFactor(FactorEnt item)
        {
            try
            {
                item.WorkFlow = item.Status.ToFactorStatus() + ",";
                item.PrivateID = Guid.NewGuid().ToString("N").Replace("-", "").Substring(0, 12);
                if (_FactorRepo.GetAll().Any(p => p.PrivateID == item.PrivateID))//If Exist Private Id
                    item.PrivateID = Guid.NewGuid().ToString("N").Replace("-", "").Substring(0, 12);

                return _FactorRepo.Insert(item);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> AddFactorAsync(FactorEnt item)
        {
            try
            {
                item.WorkFlow = item.Status.ToFactorStatus() + ",";
                item.PrivateID = Guid.NewGuid().ToString("N").Replace("-", "").Substring(0, 12);
                var allFactor = await _FactorRepo.GetAllAsync().ToListAsync();
                if (allFactor.Any(p => p.PrivateID == item.PrivateID))//If Exist Private Id
                    item.PrivateID = Guid.NewGuid().ToString("N").Replace("-", "").Substring(0, 12);

                return await _FactorRepo.InsertAsync(item);
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool AddOrderTo(CustomerOrderToEnt item)
        {
            try
            {
                return _orderToRepo.Insert(item);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public CustomerOrderToEnt OrderToDetailsBtFactorID(int id)
        {
            try
            {
                return _orderToRepo.GetAll().FirstOrDefault(p => p.FactorID == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<CustomerOrderToEnt> OrderToDetailsBtFactorIDAsync(int id)
        {
            try
            {
                return await _orderToRepo.GetAllAsync().Where(p => p.FactorID == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> AddFactor_ItemAsync(Factor_ItemEnt modelItem)
        {
            try
            {
                await ResetFactorChangeViewAsync(modelItem.FacrorID, /*System.Web.HttpContext.Current.Request.RequestContext.HttpContext.User.Identity.GetUserId()*/"");
                return await _Factor_ItemRepo.InsertAsync(modelItem);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddFactor_Item(Factor_ItemEnt modelItem)
        {
            try
            {
                ResetFactorChangeView(modelItem.FacrorID, /*System.Web.HttpContext.Current.Request.RequestContext.HttpContext.User.Identity.GetUserId()*/"");
                return _Factor_ItemRepo.Insert(modelItem);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteFactorAsync(int id)
        {
            try
            {
                return await _FactorRepo.DeleteAsync(id);

            }
            catch (Exception ex)
            {

                return false;
            }
        }


        public bool DeleteFactorProduct(int id)
        {
            try
            {
                return _Factor_ItemRepo.Delete(id);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool EditFactor(FactorEnt item, FactorEnt oldFactor = null, string date = "")
        {
            try
            {
                if (oldFactor == null)
                {
                    oldFactor = _FactorRepo.FromSql($"SELECT * FROM Factors WHERE ID = {item.ID} ;").FirstOrDefault();
                }
                if (oldFactor.Status != item.Status)
                {
                    oldFactor.WorkFlow += item.Status.ToFactorStatus() + date + ",";
                    item.WorkFlow = oldFactor.WorkFlow;
                }
                item.FactorChangesView = "";



                return _FactorRepo.Update(item);



            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<bool> EditFactorAsync(FactorEnt item, FactorEnt oldFactor = null, string date = "")
        {
            try
            {
                if (oldFactor == null)
                {
                    oldFactor = await _FactorRepo.GetAllAsync().FirstOrDefaultAsync(p => p.ID == item.ID);
                }
                if (oldFactor.Status != item.Status)
                {
                    oldFactor.WorkFlow += item.Status.ToFactorStatus() + date + ",";
                    item.WorkFlow = oldFactor.WorkFlow;
                }
                item.FactorChangesView = "";

                return await _FactorRepo.UpdateAsync(item);



            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public FactorEnt FactorDetails(int id)
        {
            try
            {
                if (id == 0) return null;
                var factor = _FactorRepo.FromSql($"SELECT * FROM Factors WHERE ID = {id} ;").FirstOrDefault();
                if (factor == null)
                    factor = _FactorRepo.FromSql($"SELECT * FROM Factors WHERE PONumber = {id};").FirstOrDefault();

                try
                {
                    if (factor != null)
                    {
                        var factorDate = GetFactorPrice(factor.ID);
                        factor.FactorPrice = factorDate.FactorPrice;
                        factor.FactorLaberNumber = factorDate.FactorLaberNumber;
                        factor.FactorInstallTime = factorDate.FactorInstallTime;
                        factor.SUM_QHL = factorDate.SUM_QHL;
                        factor.SUM_HL = factorDate.SUM_HL;
                        factor.MAX_L = factorDate.MAX_L;
                    }

                }
                catch { }
                return factor;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<FactorEnt> FactorDetailsAsync(int id)
        {
            try
            {
                if (id == 0) return null;
                var factor = await _FactorRepo.GetAllAsync().FirstOrDefaultAsync(p => p.ID == id);
                if (factor == null) factor = await _FactorRepo.GetAllAsync().FirstOrDefaultAsync(p => p.PONumber == id) ?? new FactorEnt();

                try
                {
                    if (factor != null)
                    {
                        var factorDate = await GetFactorPriceAsync(factor.ID);
                        factor.FactorPrice = factorDate.FactorPrice;
                        factor.FactorLaberNumber = factorDate.FactorLaberNumber;
                        factor.FactorInstallTime = factorDate.FactorInstallTime;
                        if (factor.Status == FactorStatus.Cancelled)
                            factor.Remaining = 0;
                    }

                }
                catch { }
                return factor;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public Factor_ItemEnt FactorProductDetails(int id)
        {
            try
            {
                return _Factor_ItemRepo.FromSql($"SELECT * FROM Factor_Items WHERE ID = {id} ;").FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> GetLastFactorNumber(DateTime now)
        {
            try
            {
                var listAllFactor = (await _FactorRepo.GetAllAsync().ToListAsync());
                var lastFactor = listAllFactor.LastOrDefault(p => p.Date.Date == now.Date);
                var po = lastFactor?.PONumber ?? 1000;
                int lastNumber = 0;
                if (po > 10000000)
                {
                    lastNumber = Math.Abs(po) % 100;
                    po = po / 100;
                }
                else
                {
                    lastNumber = Math.Abs(po) % 10;
                    po = po / 10;
                }

                if (Int32.Parse(now.ToString("yyMMdd")) == po)
                    return lastNumber;
                else
                    return 0;

            }
            catch (Exception ex)
            {

                return 0;
            }
        }

        public bool IfExistCustomer(string id)
        {
            try
            {
                return _FactorRepo.FromSql($"SELECT * FROM Factors ;").Any(p => p.CustomerID == id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool IfUsedVandorsFactor_item(int id)
        {
            try
            {
                return _Factor_ItemRepo.FromSql($"SELECT * FROM Factor_Items WHERE VandorID = {id} ;").Any();
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IQueryable<FactorEnt> ListAllFactors(bool reloadFactorPrice = false)
        {
            try
            {
                var factors = _FactorRepo.GetAllAsync();
                if (!reloadFactorPrice) return factors;

                try
                {
                    var listallItems = FactorItemList();
                    factors = factors.ToList().Select(p =>
                    {
                        var factorItems = listallItems.Where(i => i.FacrorID == p.ID);
                        p.FactorPrice = factorItems.Sum(i => i.Total);
                        p.FactorLaberNumber = factorItems.Sum(i => i.LaberNumber);
                        p.FactorInstallTime = factorItems.Sum(i => i.InstallTime);

                        return p;
                    }).AsQueryable();

                }
                catch { }

                return factors;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public async Task<List<FactorEnt>> ListAllFactorsAsync(bool reloadFactorPrice = false)
        {
            try
            {
                var factors = await _FactorRepo.GetAllAsync().ToListAsync();
                if (!reloadFactorPrice) return factors;

                try
                {
                    var listallItems = await FactorItemListAsync();
                    factors = factors.Select(p =>
                    {
                        var factorItems = listallItems.Where(i => i.FacrorID == p.ID);
                        p.FactorPrice = factorItems.Sum(i => i.Total);
                        p.FactorLaberNumber = factorItems.Sum(i => i.LaberNumber);
                        p.FactorInstallTime = factorItems.Sum(i => i.InstallTime);

                        return p;
                    }).ToList();

                }
                catch { }

                return factors;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public List<FactorEnt> ListFactors(string id = "", bool reloadFactorPrice = true)
        {

            try
            {
                List<FactorEnt> factors = new List<FactorEnt>();
                if (string.IsNullOrEmpty(id))
                    factors = _FactorRepo.GetAll().ToList();
                else
                    factors = _FactorRepo.GetAll().Where(p => p.CustomerID == id).ToList();

                if (!reloadFactorPrice) return factors;

                try
                {
                    var listallItems = FactorItemList();
                    factors = factors.Select(p =>
                    {
                        var factorItems = listallItems.Where(i => i.FacrorID == p.ID);
                        p.FactorPrice = factorItems.Sum(i => i.Total);
                        p.FactorLaberNumber = factorItems.Sum(i => i.LaberNumber);
                        p.FactorInstallTime = factorItems.Sum(i => i.InstallTime);

                        return p;
                    }).ToList();

                }
                catch { }

                return factors;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public async Task<List<FactorEnt>> ListFactorsAsync(string id = "", int take = 0, bool reloadFactorPrice = true)
        {

            try
            {
                List<FactorEnt> factors = new List<FactorEnt>();
                if (string.IsNullOrEmpty(id))
                {
                    if (take == 0)
                        factors = await _FactorRepo.GetAllAsync().OrderByDescending(p => p.ID).ToListAsync();
                    else
                        factors = await _FactorRepo.GetAllAsync().OrderByDescending(p => p.ID).Take(take).ToListAsync();
                }
                else
                {
                    if (take == 0)
                        factors = await _FactorRepo.GetAllAsync().Where(p => p.CustomerID == id || p.RegisterUserID == id).OrderByDescending(p => p.ID).ToListAsync();
                    else
                        factors = await _FactorRepo.GetAllAsync().Where(p => p.CustomerID == id || p.RegisterUserID == id).OrderByDescending(p => p.ID).Take(take).ToListAsync();

                }

                if (!reloadFactorPrice) return factors;

                try
                {
                    var listallItems = await FactorItemListAsync();
                    foreach (var item in factors)
                    {

                        var factorItems = listallItems.Where(i => i.FacrorID == item.ID);
                        item.FactorPrice = factorItems.Sum(i => i.Total);
                        item.FactorLaberNumber = factorItems.Sum(i => i.LaberNumber);
                        item.FactorInstallTime = factorItems.Sum(i => i.InstallTime);
                        if (item.Status == FactorStatus.Cancelled)
                            item.Remaining = 0;
                    }


                }
                catch { }

                return factors;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public List<FactorEnt> ListFactors(int skip, int take, bool reloadFactorPrice = true)
        {

            try
            {

                //var factors = _FactorRepo.FromSql($"SELECT * FROM Factors ORDER BY ID DESC   OFFSET {skip} ROWS    FETCH NEXT { take} ROWS ONLY; ");
                var factors = _FactorRepo.GetAll().Skip(skip).Take(take).ToList();

                if (!reloadFactorPrice) return factors;
                try
                {
                    var listallItems = FactorItemList();
                    factors = factors.Select(p =>
                    {
                        var factorItems = listallItems.Where(i => i.FacrorID == p.ID);
                        p.FactorPrice = factorItems.Sum(i => i.Total);
                        p.FactorLaberNumber = factorItems.Sum(i => i.LaberNumber);
                        p.FactorInstallTime = factorItems.Sum(i => i.InstallTime);

                        return p;
                    }).ToList();

                }
                catch { }

                return factors;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public List<Factor_ItemEnt> ListFactor_Item(int id)
        {
            try
            {
                return _Factor_ItemRepo.GetAll().Where(p => p.FacrorID == id)
                    .Include(m => m.Vandor)
                      .Include(m => m.Shipping)
                      .Include(m => m.Item).ThenInclude(m => m.ItemCategory).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<Factor_ItemEnt>> ListFactor_ItemAsync(int id)
        {
            try
            {
                return await ((_Factor_ItemRepo.GetAllQueryable().Where(p => p.FacrorID == id)
                      .Include(m => m.Vandor)
                      .Include(m => m.Shipping)

                      .Include(m => m.Item).ThenInclude(m => m.ItemCategory))).ToListAsync();



            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<Factor_ItemEnt>> ListFactorItemAsync(int id)
        {
            try
            {
                return await _Factor_ItemRepo.GetAllQueryable().Where(p => p.FacrorID == id).ToListAsync();



            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool ExistAnyPendingItemInFactor(int id)
        {
            try
            {
                var listItem = _Factor_ItemRepo.FromSql($"SELECT * FROM Factor_Items WHERE FacrorID = {id} ;");
                return listItem.Any(p => p.ItemStatus == ItemStatus.Pending);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> ExistAnyPendingItemInFactorAsync(int id)
        {
            try
            {
                var listItem = await _Factor_ItemRepo.GetAllAsync().Where(p => p.FacrorID == id).ToListAsync();
                return listItem.Any(p => p.ItemStatus == ItemStatus.Pending);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<Factor_ItemEnt> ListAllFactor_Item()
        {
            try
            {
                return _Factor_ItemRepo.FromSql($"SELECT * FROM Factor_Items ;");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Factor_ItemEnt>> ListAllFactor_ItemAsync()
        {
            try
            {
                return await _Factor_ItemRepo.GetAllAsync().ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool IfUsedShippingsFactor_item(int id)
        {
            try
            {
                return _Factor_ItemRepo.FromSql($"SELECT * FROM Factor_Items WHERE ShippingID = {id} ;").Any();
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<ItemCategoryEnt> ListItemCategory()
        {
            try
            {
                return _itemCategoryRepo.GetAll().OrderBy(p => p.Name).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<ItemCategoryEnt>> ListItemCategoryAsync()
        {
            try
            {
                return await _itemCategoryRepo.GetAllAsync().OrderBy(p => p.Name).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool IfUsedItemCategory(int id)
        {
            try
            {
                return _itemRepo.GetAll().Any(p => p.ItemCategoryID == id);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool DeleteItemCategory(int id)
        {
            try
            {
                return _itemCategoryRepo.Delete(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public ItemCategoryEnt ItemCategoryDetails(int id)
        {
            try
            {
                return _itemCategoryRepo.GetAll().FirstOrDefault(p => p.ID == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool AddItemCategory(ItemCategoryEnt model)
        {
            try
            {
                return _itemCategoryRepo.Insert(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditItemCategory(ItemCategoryEnt model)
        {
            try
            {
                return _itemCategoryRepo.Update(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool IFExistItemCategoryName(string name, int id = 0)
        {
            try
            {
                if (id == 0)
                    return _itemCategoryRepo.GetAll().Any(p => p.Name == name);
                else
                    return _itemCategoryRepo.GetAll().Any(p => p.Name == name & p.ID != id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<ItemModifireEnt> ListItemModifire()
        {
            try
            {
                return _itemModifiresRepo.GetAll().Include(p => p.ItemCategory).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<ItemModifireEnt>> ListItemModifireAsync()
        {
            try
            {
                return await _itemModifiresRepo.GetAllAsync().ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool DeleteItemModifire(long id)
        {
            try
            {
                return _itemModifiresRepo.Delete(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public ItemModifireEnt ItemModifireDetails(long id)
        {
            try
            {
                return _itemModifiresRepo.GetAll().FirstOrDefault(p => p.ID == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<ItemModifireEnt> ItemModifireDetailsAsync(long id)
        {
            try
            {
                return await _itemModifiresRepo.GetAllAsync().FirstOrDefaultAsync(p => p.ID == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool IFExistItemModifireName(string name, long id = 0)
        {
            try
            {
                if (id == 0)
                    return _itemModifiresRepo.GetAll().Any(p => p.Name == name);
                else
                    return _itemModifiresRepo.GetAll().Any(p => p.Name == name & p.ID != id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddItemModifire(ItemModifireEnt model)
        {
            try
            {
                return _itemModifiresRepo.Insert(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditItemModifire(ItemModifireEnt model)
        {
            try
            {
                return _itemModifiresRepo.Update(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ifExistModofiresName(string name, long id)
        {
            try
            {
                if (id == 0)
                    return _itemModifiresRepo.GetAll().Any(p => p.Name == name);
                else
                    return _itemModifiresRepo.GetAll().Any(p => p.Name == name & p.ID != id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<ItemEnt> ListItem()
        {
            try
            {
                return _itemRepo.GetAll().Where(p => p.Enable == true).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<ItemEnt>> ListItemAsync()
        {
            try
            {
                return await _itemRepo.GetAllAsync().Where(p => p.Enable == true).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<ItemEnt> ListAllItem()
        {
            try
            {
                return _itemRepo.GetAll().Include(p => p.ItemCategory).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string DeleteItem(long id)
        {
            try
            {
                //var factorItem = _FactorRepo.
                var factorItemImages = _factorItem_ImageRepo.GetAll().Where(p => p.Factor_ItemID == id);
                foreach (var item in factorItemImages)
                {
                    _factorItem_ImageRepo.Delete(item.ID);
                }
                return _itemRepo.Delete(id) ? "success" : "false";
            }
            catch (Exception ex)
            {
                return ex.InnerException.InnerException.Message.ToString();
            }
        }

        public List<ItemModifireEnt> ListModifires()
        {
            try
            {
                return _itemModifiresRepo.GetAll().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ItemEnt ItemDetails(long id)
        {
            try
            {
                return _itemRepo.GetAll().FirstOrDefault(p => p.ID == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool IsModifireInItem(long modifireId, long itemId)
        {
            try
            {
                return _item_itemModifireRepo.GetAll().Any(p => p.ItemModifireID == modifireId & p.Item_ID == itemId);
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public async Task<bool> IsModifireInItemAsync(long modifireId, long itemId)
        {
            try
            {
                return await _item_itemModifireRepo.GetAllAsync().AnyAsync(p => p.ItemModifireID == modifireId & p.Item_ID == itemId);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public int Item_ModifirePriority(long modifireId, long itemId)
        {
            try
            {
                var im = _item_itemModifireRepo.GetAll().FirstOrDefault(p => p.ItemModifireID == modifireId & p.Item_ID == itemId);
                if (im == null)
                    return 0;
                return im.Priority;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<int> Item_ModifirePriorityAsync(long modifireId, long itemId)
        {
            try
            {
                var im = await _item_itemModifireRepo.GetAllAsync().FirstOrDefaultAsync(p => p.ItemModifireID == modifireId & p.Item_ID == itemId);
                if (im == null)
                    return 0;
                return im.Priority;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public bool IfExistItemName(string name, long id = 0)
        {
            try
            {
                if (id == 0)
                    return _itemRepo.GetAll().Any(p => p.Name == name);
                else
                    return _itemRepo.GetAll().Any(p => p.Name == name & p.ID != id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddItem(ItemEnt model)
        {
            try
            {
                return _itemRepo.Insert(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditItem(ItemEnt model)
        {
            try
            {
                return _itemRepo.Update(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddModifireToItem(long modifireId, long itemId, int priority)
        {
            try
            {
                var im = new Item_ItemModifireEnt();
                im.ItemModifireID = modifireId;
                im.Item_ID = itemId;
                im.Priority = priority;
                return _item_itemModifireRepo.Insert(im);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteModofireFromItem(long modifireId, long itemId)
        {
            try
            {
                var im = _item_itemModifireRepo.GetAll().FirstOrDefault(p => p.ItemModifireID == modifireId & p.Item_ID == itemId);
                return _item_itemModifireRepo.Delete(im.ID);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateModifireToItem(long modifireId, long itemId, int priority)
        {
            try
            {
                var im = _item_itemModifireRepo.GetAll().FirstOrDefault(p => p.ItemModifireID == modifireId & p.Item_ID == itemId);
                im.Priority = priority;
                return _item_itemModifireRepo.Update(im);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<ItemModifireEnt> ListItemModifireByCategoryID(int id)
        {
            try
            {
                return _itemModifiresRepo.GetAll().Where(p => p.ItemCategoryID == id).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public double GetLastItemNumber(int factorId)
        {
            try
            {
                return _Factor_ItemRepo.FromSql($"SELECT * FROM Factor_Items WHERE FacrorID = {factorId} ;").LastOrDefault().ItemNumber;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<double> GetLastItemNumberAsync(int factorId)
        {
            try
            {
                var modelList = (await _Factor_ItemRepo.GetAllAsync().ToListAsync()).Where(p => p.FacrorID == factorId);
                if (modelList.Count() == 0)
                    return 0;
                return modelList.LastOrDefault().ItemNumber;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public bool DeleteFactorItem(long id)
        {
            try
            {
                var listITemImage = _factorItem_ImageRepo.GetAll().Where(p => p.Factor_ItemID == id);
                foreach (var item in listITemImage)
                {
                    item.FactorID = item.Factor_Item.FacrorID;
                    item.Factor_ItemID = null;
                    _factorItem_ImageRepo.Update(item);
                }
                var fi = _Factor_ItemRepo.FromSql($"SELECT * FROM Factor_Items WHERE ID = {id} ;").FirstOrDefault();
                ResetFactorChangeView(fi.FacrorID,/* System.Web.HttpContext.Current.Request.RequestContext.HttpContext.User.Identity.GetUserId()*/ "");//#change here
                return _Factor_ItemRepo.Delete(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> DeleteFactorItemAsync(long id)
        {
            try
            {
                var listITemImage = await _factorItem_ImageRepo.GetAllAsync().Where(p => p.Factor_ItemID == id).ToListAsync();
                foreach (var item in listITemImage)
                {
                    item.FactorID = item.Factor_Item.FacrorID;
                    item.Factor_ItemID = null;
                    await _factorItem_ImageRepo.UpdateAsync(item);
                }
                var fi = await _Factor_ItemRepo.GetAllAsync().FirstOrDefaultAsync(p => p.ID == id);
                ResetFactorChangeView(fi.FacrorID /*System.Web.HttpContext.Current.Request.RequestContext.HttpContext.User.Identity.GetUserId()*/ , "");//#change here
                return await _Factor_ItemRepo.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Factor_ItemEnt FactorItemDetails(long id)
        {
            try
            {
                return _Factor_ItemRepo.FromSql($"SELECT * FROM Factor_Items WHERE ID = {id} ;").FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Factor_ItemEnt> FactorItemDetailsAsync(long id)
        {
            try
            {
                return await _Factor_ItemRepo.GetAllAsync().FirstOrDefaultAsync(p => p.ID == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> EditFactorItemAsync(Factor_ItemEnt model)
        {
            try
            {
                await ResetFactorChangeViewAsync(model.FacrorID,/* System.Web.HttpContext.Current.Request.RequestContext.HttpContext.User.Identity.GetUserId()*/ "");
                return await _Factor_ItemRepo.UpdateAsync(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> EditFactorItem2Async(Factor_ItemEnt model)
        {
            try
            {
                // await ResetFactorChangeViewAsync(model.FacrorID,/* System.Web.HttpContext.Current.Request.RequestContext.HttpContext.User.Identity.GetUserId()*/ "");
                return await _Factor_ItemRepo.Update2Async(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ResetAllFactorItem(int id, int ponumber)
        {
            try
            {
                var listFactorItem = _Factor_ItemRepo.FromSql($"SELECT * FROM Factor_Items WHERE FacrorID = {id} ;");
                var Res = true;
                var itemNumber = 0.01;
                foreach (var item in listFactorItem)
                {
                    item.ItemNumber = ponumber + itemNumber;
                    if (Res) Res = _Factor_ItemRepo.Update(item);
                    itemNumber = itemNumber + 0.01;
                }
                return Res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddItemModifireAnswer(ItemModifireAnswerEnt model)
        {
            try
            {
                return _itemModifireAnswerRepo.Insert(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> AddItemModifireAnswerAsync(ItemModifireAnswerEnt model)
        {
            try
            {
                return await _itemModifireAnswerRepo.InsertAsync(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public bool UpdateFactorItem(Factor_ItemEnt factorItem)
        {
            try
            {
                var factor = _FactorRepo.FromSql($"SELECT * FROM Factors WHERE ID = {factorItem.FacrorID} ;").FirstOrDefault();
                ResetGalleryChangeView(factorItem.FacrorID, /*System.Web.HttpContext.Current.Request.RequestContext.HttpContext.User.Identity.GetUserId()*/ "");//change here
                return _Factor_ItemRepo.Update(factorItem);
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public async Task<bool> UpdateFactorItemAsync(Factor_ItemEnt factorItem)
        {
            try
            {
                var factor = await _FactorRepo.GetAllAsync().FirstOrDefaultAsync(p => p.ID == factorItem.FacrorID);
                await ResetGalleryChangeView(factorItem.FacrorID, /*System.Web.HttpContext.Current.Request.RequestContext.HttpContext.User.Identity.GetUserId()*/ "");//change here
                return await _Factor_ItemRepo.UpdateAsync(factorItem);
            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public bool ifAnsweredModifire(long factorItemId, long ItemModifireId)
        {
            try
            {
                return _itemModifireAnswerRepo.GetAll().Any(p => (p.Factor_ItemID == factorItemId | p.CustomerRequestID == factorItemId) & p.ItemModifireID == ItemModifireId);

            }
            catch (Exception ex)
            {
                return false;

            }
        }


        public async Task<bool> ifAnsweredModifireAsync(long factorItemId, long ItemModifireId)
        {
            try
            {
                return await _itemModifireAnswerRepo.GetAllAsync().AnyAsync(p => (p.Factor_ItemID == factorItemId | p.CustomerRequestID == factorItemId) & p.ItemModifireID == ItemModifireId);

            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public ItemModifireAnswerEnt ItemModifireAnswerDetails(long id)
        {
            try
            {
                return _itemModifireAnswerRepo.GetAll().FirstOrDefault(p => p.ID == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ItemModifireAnswerEnt ItemModifireAnswerDetails(long factorItemId, long ItemModifireId)
        {
            try
            {
                return _itemModifireAnswerRepo.GetAll().FirstOrDefault(p => p.Factor_ItemID == factorItemId & p.ItemModifireID == ItemModifireId);

            }
            catch (Exception ex)
            {
                return null;

            }
        }

        public async Task<ItemModifireAnswerEnt> ItemModifireAnswerDetailsAsync(long factorItemId, long ItemModifireId)
        {
            try
            {
                return await _itemModifireAnswerRepo.GetAllAsync().FirstOrDefaultAsync(p => p.Factor_ItemID == factorItemId & p.ItemModifireID == ItemModifireId);

            }
            catch (Exception ex)
            {
                return null;

            }
        }

        public bool EditItemModifireAnswer(ItemModifireAnswerEnt answerModel)
        {
            try
            {
                if (answerModel.ID == 0)
                    return _itemModifireAnswerRepo.Insert2(answerModel);
                return _itemModifireAnswerRepo.Update(answerModel);
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public async Task<bool> EditItemModifireAnswerAsync(ItemModifireAnswerEnt answerModel)
        {
            try
            {
                if (answerModel.ID == 0)
                    return await _itemModifireAnswerRepo.Insert2Async(answerModel);
                return await _itemModifireAnswerRepo.Update2Async(answerModel);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateFactorItem_ItemText(long factorItemId)
        {
            try
            {
                var listItemModifireAnswer = _itemModifireAnswerRepo.GetAll().Where(p => p.Factor_ItemID == factorItemId).ToList();
                var FactorItem = _Factor_ItemRepo.FromSql($"SELECT * FROM Factor_Items WHERE ID = {factorItemId} ;").FirstOrDefault();

                FactorItem.ItemText = "";
                FactorItem.ItemTextVandorEmail = "";
                foreach (var answer in listItemModifireAnswer)
                {

                    if (answer.ItemModifire == null)
                        answer.ItemModifire = _itemModifiresRepo.GetAll().FirstOrDefault(p => p.ID == answer.ItemModifireID);
                    var itemName = (answer.ItemModifire?.Name ?? "");
                    if (ifExistItemModifireInItem(FactorItem.ItemID, answer.ItemModifireID))
                    {
                        FactorItem.ItemText += (itemName != "" ? (itemName + ":") : "") + answer.AnswerText + " \r\n";

                        if (!ifItemModifireDontEmail(answer.ItemModifireID))
                            FactorItem.ItemTextVandorEmail += (itemName != "" ? (itemName + ":") : "") + answer.AnswerText + " \r\n";
                    }
                }
                return FactorItem.ItemText == "" ? true : _Factor_ItemRepo.Update(FactorItem);
            }
            catch (Exception ex)
            {
                return true;
            }
        }

        public async Task<bool> UpdateFactorItem_ItemTextAsync(long factorItemId)
        {
            try
            {
                var listItemModifireAnswer = await _itemModifireAnswerRepo.GetAllAsync().Where(p => p.Factor_ItemID == factorItemId).ToListAsync();
                var FactorItem = await _Factor_ItemRepo.GetAllAsync().FirstOrDefaultAsync(p => p.ID == factorItemId);

                FactorItem.ItemText = "";
                FactorItem.ItemTextVandorEmail = "";
                foreach (var answer in listItemModifireAnswer)
                {
                    if (answer.ItemModifire == null)
                        answer.ItemModifire = await _itemModifiresRepo.GetAllAsync().FirstOrDefaultAsync(p => p.ID == answer.ItemModifireID);
                    var itemName = (answer.ItemModifire?.Name ?? "");
                    if (await ifExistItemModifireInItemAsync(FactorItem.ItemID, answer.ItemModifireID))
                    {
                        FactorItem.ItemText += (itemName != "" ? (itemName + ":") : "") + answer.AnswerText + " \r\n";

                        if (!await ifItemModifireDontEmailAsync(answer.ItemModifireID))
                            FactorItem.ItemTextVandorEmail += (itemName != "" ? (itemName + ":") : "") + answer.AnswerText + " \r\n";
                    }
                }
                return FactorItem.ItemText == "" ? true : (await _Factor_ItemRepo.UpdateAsync(FactorItem));
            }
            catch (Exception ex)
            {
                return true;
            }
        }

        private bool ifItemModifireDontEmail(long itemModifireID)
        {
            try
            {
                return (_itemModifiresRepo.GetAll().FirstOrDefault(p => p.ID == itemModifireID)?.DontSendToVandor ?? false);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        private async Task<bool> ifItemModifireDontEmailAsync(long itemModifireID)
        {
            try
            {
                return (await _itemModifiresRepo.GetAllAsync().FirstOrDefaultAsync(p => p.ID == itemModifireID))?.DontSendToVandor ?? false;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        private bool ifExistItemModifireInItem(long itemID, long itemModifireID)
        {
            try
            {
                return (_item_itemModifireRepo.GetAll()).Any(p => p.ItemModifireID == itemModifireID & p.Item_ID == itemID);
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        private async Task<bool> ifExistItemModifireInItemAsync(long itemID, long itemModifireID)
        {
            try
            {
                return await _item_itemModifireRepo.GetAllAsync().AnyAsync(p => p.ItemModifireID == itemModifireID & p.Item_ID == itemID);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public List<Factor_ItemEnt> ListTaxableFactor_Item(int id)
        {
            try
            {
                return _Factor_ItemRepo.FromSql($"SELECT * FROM Factor_Items WHERE FacrorID = {id} ;").Where(p => p.Taxable == true).ToList();
            }
            catch (Exception ex)
            {
                return new List<Factor_ItemEnt>();
            }
        }

        public bool AddFActorItemImage(FactorItem_ImageEnt fileModel)
        {
            try
            {
              //  ResetGalleryChangeView(fileModel.FactorID, /*System.Web.HttpContext.Current.Request.RequestContext.HttpContext.User.Identity.GetUserId()*/  "");//change here

                return _factorItem_ImageRepo.Insert(fileModel);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> AddFActorItemImageAsync(FactorItem_ImageEnt fileModel)
        {
            try
            {
                await ResetGalleryChangeView(fileModel.FactorID, /*System.Web.HttpContext.Current.Request.RequestContext.HttpContext.User.Identity.GetUserId()*/ "");// change here

                return await _factorItem_ImageRepo.InsertAsync(fileModel);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<FactorItem_ImageEnt> ListFActorItemImage(long id)
        {
            try
            {
                return _factorItem_ImageRepo.GetAll().Where(p => p.Factor_ItemID == id).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<FactorItem_ImageEnt>> ListFActorItemImageAsync(long id)
        {
            try
            {
                return await _factorItem_ImageRepo.GetAllAsync().Where(p => p.Factor_ItemID == id).ToListAsync();
            }
            catch (Exception ex)
            {
                return new List<FactorItem_ImageEnt>();
            }
        }

        public FactorEnt FactorDetailsByRequestID(long id)
        {
            try
            {
                var factor = _FactorRepo.FromSql($"SELECT * FROM Factors WHERE RequestEstimateID = {id} ;").LastOrDefault();
                if (factor == null)
                {
                    var fid = _requestEstimateAppointmentRepo.GetAll().FirstOrDefault(p => p.ID == id).FactorID;
                    factor = _FactorRepo.FromSql($"SELECT * FROM Factors WHERE ID = {fid} ;").FirstOrDefault();
                }

                return factor;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<FactorEnt> FactorDetailsByRequestIDAsync(long id)
        {
            try
            {
                var factor = await _FactorRepo.GetAllAsync().FirstOrDefaultAsync(p => p.RequestEstimateID == id);
                if (factor == null)
                {
                    var fid = (await _requestEstimateAppointmentRepo.GetAllAsync().FirstOrDefaultAsync(p => p.ID == id)).FactorID;
                    factor = await _FactorRepo.GetAllAsync().FirstOrDefaultAsync(p => p.ID == fid);
                }

                return factor;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Factor_ItemEnt> FactorItemList()
        {
            try
            {
                return _Factor_ItemRepo.FromSql($"SELECT * FROM Factor_Items;");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<Factor_ItemEnt>> FactorItemListAsync()
        {
            try
            {
                return await _Factor_ItemRepo.GetAllAsync().ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public bool DeleteFactorItemFile(long id)
        {
            try
            {
                return _factorItem_ImageRepo.Delete(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> DeleteFactorItemFileAsync(long id)
        {
            try
            {
                return await _factorItem_ImageRepo.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<FactorItem_ImageEnt> ListFactorImage(int factorID)
        {
            try
            {
                return _factorItem_ImageRepo.GetAll().Where(p => p.Factor_ItemID != null ? p.Factor_Item.FacrorID == factorID : p.FactorID == factorID).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<FactorItem_ImageEnt>> ListFactorImageAsync(int factorID)
        {
            try
            {
                var listItemImage = await _factorItem_ImageRepo.GetAllAsync().Where(p => p.Factor_ItemID != null ? p.Factor_Item.FacrorID == factorID : p.FactorID == factorID).ToListAsync();
                try
                {
                    var listNoteImage = await _factorNoteRepo.GetAllAsync().Where(p => !string.IsNullOrEmpty(p.FilePath) & p.FactorID == factorID).ToListAsync();
                    foreach (var note in listNoteImage)
                    {
                        listItemImage.Add(new FactorItem_ImageEnt()
                        {
                            Customers = false,
                            Estimators = true,
                            Installers = true,
                            Vandors = false,
                            Image = note.FilePath,
                            Comment = note.Note,
                            FactorID = factorID,
                            Factor_ItemID = 0,
                            Type = "image/jpeg",
                            Title = note.FilePath.Replace("/Content/Files/AttachmentFile/", ""),
                            FileName = note.FilePath.Replace("/Content/Files/AttachmentFile/", "")
                        });
                    }

                }
                catch { }

                return listItemImage;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public FactorItem_ImageEnt FactorItemImageDetails(long id)
        {
            try
            {
                return _factorItem_ImageRepo.GetAll().FirstOrDefault(p => p.ID == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<FactorItem_ImageEnt> FactorItemImageDetailsAsync(long id)
        {
            try
            {
                return await _factorItem_ImageRepo.GetAllAsync().FirstOrDefaultAsync(p => p.ID == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> UpdateFactorItemFileAsync(FactorItem_ImageEnt itemImage)
        {
            try
            {
                return await _factorItem_ImageRepo.UpdateAsync(itemImage);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateFactorItemImage(FactorItem_ImageEnt model)
        {
            try
            {
                return _factorItem_ImageRepo.Update(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateFactorItemImageAsync(FactorItem_ImageEnt model)
        {
            try
            {
                return await _factorItem_ImageRepo.UpdateAsync(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool IsCommericalFactor(int jobId)
        {
            try
            {
                return _FactorRepo.FromSql($"SELECT * FROM Factors WHERE ID = {jobId} ;").Any(p => p.ID == jobId & p.IsCommerical);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateFactor(FactorEnt item)
        {
            try
            {



                return _FactorRepo.Update(item);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> UpdateFactorAsync(FactorEnt item)
        {
            try
            {
                return await _FactorRepo.UpdateAsync(item);
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public async Task<int> GenetateNewPONumberAsync(DateTime now)
        {
            var lasFactorNumber = await GetLastFactorNumber(now);
            var res = Int32.Parse(now.ToString("yyMMdd") + (lasFactorNumber + 1).ToString());
            return res;
        }

        public async Task<double> GenerateItemNumber(FactorEnt factor)
        {
            var IN = await GetLastItemNumberAsync(factor.ID);
            IN = (IN == 0 | !IN.ToString().Contains(factor.PONumber.ToString())) ? factor.PONumber + 0.01 : IN + 0.01;
            return IN;
        }

        public List<FactorItem_ImageEnt> ListFactorImageRemoveFromItem(int factorid)
        {
            try
            {
                return _factorItem_ImageRepo.GetAll().Where(p => p.Factor_ItemID == null & p.FactorID == factorid).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<FactorItem_ImageEnt>> ListFactorImageRemoveFromItemAsync(int factorid)
        {
            try
            {
                return await _factorItem_ImageRepo.GetAllAsync().Where(p => p.Factor_ItemID == null & p.FactorID == factorid).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> IfExistImageInAnotherFactor(string image, int factorID)
        {
            try
            {
                var res1 = await _Factor_ItemRepo.GetAllAsync().Where(p => p.FacrorID == factorID).AnyAsync(p => p.Photo == image);
                var res2 = await _factorItem_ImageRepo.GetAllAsync().AnyAsync(p => p.Image == image & p.FactorID == factorID);

                return res1 | res2;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool IfExistImageInAnotherItem(string photo, long factoritemId)
        {
            try
            {
                var factorID = _Factor_ItemRepo.GetAll().FirstOrDefault(p => p.ID == factoritemId)?.FacrorID ?? 0;

                var res1 = _Factor_ItemRepo.FromSql($"SELECT * FROM Factor_Items WHERE FacrorID = {factorID} ;").Any(p => p.Photo == photo);
                var res2 = _factorItem_ImageRepo.GetAll().Any(p => p.Image == photo & p.FactorID == factorID);

                return res1 | res2;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddFactorNote(string text, int factorId, string filePath = "", string userSender = "")
        {
            try
            {

                if (string.IsNullOrWhiteSpace(userSender))
                    return _factorNoteRepo.Insert(new FactorNoteEnt() { Note = text, FactorID = factorId, FilePath = filePath });
                else
                {
                    var modifiedInfo = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss:tt") + " By " + userSender;
                    return _factorNoteRepo.Insert2(new FactorNoteEnt() { Note = text, FactorID = factorId, FilePath = filePath, modifiedInfo = modifiedInfo });
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> AddFactorNoteAsync(string text, int? factorId, string filePath = "", string userSender = "", long factorTask = 0)
        {
            try
            {
                if (factorId == 0) factorId = null;
                if (string.IsNullOrWhiteSpace(userSender))
                    return await _factorNoteRepo.InsertAsync(new FactorNoteEnt() { Note = text, FactorID = factorId, FilePath = filePath, FactorTaskID = factorTask });
                else
                {
                    var modifiedInfo = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss:tt") + " By " + userSender;
                    if (factorTask != 0)
                        modifiedInfo = DateTime.Now.ToString("dd MMMM, H:mm") + " By " + userSender;

                    return _factorNoteRepo.Insert2(new FactorNoteEnt() { Note = text, FactorID = factorId, FilePath = filePath, modifiedInfo = modifiedInfo, FactorTaskID = factorTask });
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<FactorNoteEnt> ListFactorNotes(int id)
        {
            try
            {
                return _factorNoteRepo.FromSql($"SELECT * FROM FactorNotes WHERE FactorID = {id} ;").OrderBy(p => p.ID).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<FactorNoteEnt>> ListFactorNotesAsync(int id, long factorTaskID = 0)
        {
            try
            {
                if (factorTaskID == 0)
                    return await _factorNoteRepo.GetAllAsync().Where(p => p.FactorID == id).OrderBy(p => p.ID).ToListAsync();
                else if (id == 0 & factorTaskID != 0)
                    return await _factorNoteRepo.GetAllAsync().Where(p => p.FactorTaskID == factorTaskID).OrderByDescending(p => p.ID).ToListAsync();
                else
                    return await _factorNoteRepo.GetAllAsync().Where(p => p.FactorID == id & p.FactorTaskID == factorTaskID).OrderByDescending(p => p.ID).ToListAsync();

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool isInstallerInFactor(string installerId, int factorId)
        {
            try
            {
                return _factorInstallerRepo.GetAll().Any(p => p.InstallerId == installerId & p.FactorID == factorId);
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public async Task<bool> isInstallerInFactorAsync(string installerId, int factorId)
        {
            try
            {
                return await _factorInstallerRepo.GetAllAsync().AnyAsync(p => p.InstallerId == installerId & p.FactorID == factorId);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddFactorInstaller(string insallerId, int factorID)
        {
            try
            {
                var fi = new FactorInstallerEnt();
                fi.InstallerId = insallerId;
                fi.FactorID = factorID;

                return _factorInstallerRepo.Insert(fi);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> AddFactorInstallerAsync(string insallerId, int factorID)
        {
            try
            {
                var fi = new FactorInstallerEnt();
                fi.InstallerId = insallerId;
                fi.FactorID = factorID;

                return await _factorInstallerRepo.InsertAsync(fi);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteFactorInstaller(string installerId, int factorID)
        {
            try
            {
                var fi = _factorInstallerRepo.GetAll().FirstOrDefault(p => p.InstallerId == installerId & p.FactorID == factorID);
                return _factorInstallerRepo.Delete(fi.ID);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<bool> DeleteFactorInstallerAsync(string installerId, int factorID)
        {
            try
            {
                var fi = await _factorInstallerRepo.GetAllAsync().FirstOrDefaultAsync(p => p.InstallerId == installerId & p.FactorID == factorID);
                return await _factorInstallerRepo.DeleteAsync(fi.ID);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public FactorEnt FactorDetailsByPONumber(int ponuber)
        {
            try
            {

                return _FactorRepo.FromSql($"SELECT * FROM Factors WHERE PONumber = {ponuber} ;").FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public FactorEnt FactorDetailsByPONumber(string ponuber)
        {
            try
            {

                return _FactorRepo.FromSql($"SELECT * FROM Factors WHERE PONumber ={ponuber} ;").FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool UpdateFactorChangeView(int factorId, string userId)
        {
            try
            {
                //var factor = _FactorRepo.FromSql($"SELECT * FROM Factors WHERE ID = {factorId} ;").FirstOrDefault();
                //factor.FactorChangesView = factor.FactorChangesView ?? "";
                //if (!factor.FactorChangesView.Contains(userId))
                //{
                //    factor.FactorChangesView += ("," + userId);
                //    factor.FactorChangesView = factor.FactorChangesView.TrimStart(',');
                //}
                //return _FactorRepo.Update2(factor);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> UpdateFactorChangeViewAsync(int factorId, string userId)
        {
            try
            {
                //var factor = await FactorDetailsAsync(factorId);
                //factor.FactorChangesView = factor.FactorChangesView ?? "";
                //if (!factor.FactorChangesView.Contains(userId))
                //{
                //    factor.FactorChangesView += ("," + userId);
                //    factor.FactorChangesView = factor.FactorChangesView.TrimStart(',');
                //}
                //return _FactorRepo.Update2(factor);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAppoitmentChangeView(int factorId, string userId)
        {
            try
            {
                //var factor = await _FactorRepo.GetAllAsync().FirstOrDefaultAsync(p => p.ID == factorId);
                //factor.AppoitmentChangesView = factor.AppoitmentChangesView ?? "";
                //if (!factor.AppoitmentChangesView.Contains(userId))
                //{
                //    factor.AppoitmentChangesView += ("," + userId);
                //    factor.AppoitmentChangesView = factor.AppoitmentChangesView.TrimStart(',');

                //    factor.FactorChangesView = factor.FactorChangesView ?? "";
                //    factor.FactorChangesView += ("," + userId);
                //    factor.FactorChangesView = factor.FactorChangesView.TrimStart(',');
                //}
                //return await _FactorRepo.Update2Async(factor);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdatePaymentChangeView(int factorId, string userId)
        {
            try
            {
                //var factor = await _FactorRepo.GetAllAsync().FirstOrDefaultAsync(p => p.ID == factorId);
                //factor.PaymentChangesView = factor.PaymentChangesView ?? "";
                //if (!factor.PaymentChangesView.Contains(userId))
                //{
                //    factor.PaymentChangesView += ("," + userId);
                //    factor.PaymentChangesView = factor.PaymentChangesView.TrimStart(',');

                //    factor.FactorChangesView = factor.FactorChangesView ?? "";
                //    factor.FactorChangesView += ("," + userId);
                //    factor.FactorChangesView = factor.FactorChangesView.TrimStart(',');
                //}
                //return await _FactorRepo.Update2Async(factor);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateOrderChangeView(int factorId, string userId)
        {
            try
            {
                //var factor = await _FactorRepo.GetAllAsync().FirstOrDefaultAsync(p => p.ID == factorId); factor.OrderChangesView = factor.OrderChangesView ?? "";
                //if (!factor.OrderChangesView.Contains(userId))
                //{
                //    factor.OrderChangesView += ("," + userId);
                //    factor.OrderChangesView = factor.OrderChangesView.TrimStart(',');

                //    factor.FactorChangesView = factor.FactorChangesView ?? "";
                //    factor.FactorChangesView += ("," + userId);
                //    factor.FactorChangesView = factor.FactorChangesView.TrimStart(',');
                //}
                // return await _FactorRepo.Update2Async(factor);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateNoteChangeView(int factorId, string userId)
        {
            try
            {
                //var factor = await _FactorRepo.GetAllAsync().FirstOrDefaultAsync(p => p.ID == factorId);
                //factor.NoteChangesView = factor.NoteChangesView ?? "";
                //if (!factor.NoteChangesView.Contains(userId))
                //{
                //    factor.NoteChangesView += ("," + userId);
                //    factor.NoteChangesView = factor.NoteChangesView.TrimStart(',');

                //    factor.FactorChangesView = factor.FactorChangesView ?? "";
                //    factor.FactorChangesView += ("," + userId);
                //    factor.FactorChangesView = factor.FactorChangesView.TrimStart(',');
                //}
                //return await _FactorRepo.Update2Async(factor);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateGalleryChangeView(int factorId, string userId)
        {
            try
            {
                //var factor = await _FactorRepo.GetAllAsync().FirstOrDefaultAsync(p => p.ID == factorId);
                //factor.GalleryChangesView = factor.GalleryChangesView ?? "";
                //if (!factor.GalleryChangesView.Contains(userId))
                //{
                //    factor.GalleryChangesView += ("," + userId);
                //    factor.GalleryChangesView = factor.GalleryChangesView.TrimStart(',');

                //    factor.FactorChangesView = factor.FactorChangesView ?? "";
                //    factor.FactorChangesView += ("," + userId);
                //    factor.FactorChangesView = factor.FactorChangesView.TrimStart(',');
                //}
                //return await _FactorRepo.Update2Async(factor);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> ResetGalleryChangeView(int factorId, string userId)
        {

            try
            {
                //var factor = await _FactorRepo.GetAllAsync().FirstOrDefaultAsync(p => p.ID == factorId);
                //factor.GalleryChangesView = userId;
                //return await _FactorRepo.Update2Async(factor);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public bool ResetFactorChangeView(int factorId, string userId)
        {
            try
            {
                //var factor = _FactorRepo.FromSql($"SELECT * FROM Factors WHERE ID = {factorId} ;").FirstOrDefault();
                //factor.FactorChangesView = userId;
                //return _FactorRepo.Update2(factor);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> ResetFactorChangeViewAsync(int factorId, string userId)
        {
            try
            {
                //var factor = await _FactorRepo.GetAllAsync().FirstOrDefaultAsync(p => p.ID == factorId);
                //factor.FactorChangesView = userId;
                //return await _FactorRepo.Update2Async(factor);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool ResetAppoitmentChangeView(int factorId, string userId)
        {
            try
            {
                //var factor = _FactorRepo.FromSql($"SELECT * FROM Factors WHERE ID = {factorId} ;").FirstOrDefault();
                //factor.AppoitmentChangesView = userId;
                //return _FactorRepo.Update2(factor);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> ResetPaymentChangeView(int factorId, string userId)
        {
            try
            {
                //var factor = await _FactorRepo.GetAllAsync().FirstOrDefaultAsync(p => p.ID == factorId);
                //factor.PaymentChangesView = userId;
                //return await _FactorRepo.Update2Async(factor);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> ResetOrderChangeView(int factorId, string userId)
        {
            try
            {
                //var factor = await _FactorRepo.GetAllAsync().FirstOrDefaultAsync(p => p.ID == factorId);
                //factor.OrderChangesView = userId;
                //return await _FactorRepo.Update2Async(factor);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> ResetNoteChangeView(int factorId, string userId)
        {
            try
            {
                //var factor = await _FactorRepo.GetAllAsync().FirstOrDefaultAsync(p => p.ID == factorId);
                //factor.NoteChangesView = userId;
                //return await _FactorRepo.Update2Async(factor);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteComment(long id)
        {
            try
            {
                return _factorNoteRepo.Delete(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> DeleteCommentAsync(long id)
        {
            try
            {
                return await _factorNoteRepo.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> IfExistFactorItemImage(string fileName)
        {
            try
            {
                return await _factorItem_ImageRepo.GetAllAsync().AnyAsync(p => p.FileName == fileName);
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public FactorEnt FactorDetailsByPrivateKey(string id)
        {
            try
            {

                var factor = _FactorRepo.FromSql($"SELECT * FROM Factors ;").FirstOrDefault(p => p.PrivateID == id);

                try
                {
                    if (factor != null)
                    {
                        var factorDate = GetFactorPrice(factor.ID);
                        factor.FactorPrice = factorDate.FactorPrice;
                        factor.FactorLaberNumber = factorDate.FactorLaberNumber;
                        factor.FactorInstallTime = factorDate.FactorInstallTime;

                        factor.SUM_QHL = factorDate.SUM_QHL;
                        factor.SUM_HL = factorDate.SUM_HL;
                        factor.MAX_L = factorDate.MAX_L;
                    }

                }
                catch { }
                return factor;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<FactorEnt> FactorDetailsByPrivateKeyAsync(string id)
        {
            try
            {

                var factor = await _FactorRepo.GetAllAsync().FirstOrDefaultAsync(p => p.PrivateID == id);

                try
                {
                    if (factor != null)
                    {
                        var factorDate = await GetFactorPriceAsync(factor.ID);
                        factor.FactorPrice = factorDate.FactorPrice;
                        factor.FactorLaberNumber = factorDate.FactorLaberNumber;
                        factor.FactorInstallTime = factorDate.FactorInstallTime;
                    }

                }
                catch { }
                return factor;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool IfExistImageInFactorItem(string image, long? factor_ItemID)
        {
            try
            {
                var listAll = _factorItem_ImageRepo.GetAll().ToList();
                var list = listAll.Where(p => p.Factor_ItemID == factor_ItemID).ToList();
                var res = _factorItem_ImageRepo.GetAll().Any(p => p.Image == image & p.Factor_ItemID == factor_ItemID);
                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> IfExistImageInFactorItemAsync(string image, long? factor_ItemID)
        {
            try
            {
                var listAll = await _factorItem_ImageRepo.GetAllAsync().ToListAsync();
                var list = listAll.Where(p => p.Factor_ItemID == factor_ItemID).ToList();
                var res = await _factorItem_ImageRepo.GetAllAsync().AnyAsync(p => p.Image == image & p.Factor_ItemID == factor_ItemID);
                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ResetContractChangeView(int factorId, string userId)
        {
            try
            {
                //var factor = _FactorRepo.FromSql($"SELECT * FROM Factors WHERE ID = {factorId} ;").FirstOrDefault();
                //factor.ContractChangesView = userId;
                //return _FactorRepo.Update2(factor);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateContractChangeView(int factorId, string userId)
        {
            try
            {
                //var factor = await _FactorRepo.GetAllAsync().FirstOrDefaultAsync(p => p.ID == factorId);
                //factor.ContractChangesView = factor.ContractChangesView ?? "";
                //if (!factor.ContractChangesView.Contains(userId))
                //{
                //    factor.ContractChangesView += ("," + userId);
                //    factor.ContractChangesView = factor.ContractChangesView.TrimStart(',');

                //    factor.FactorChangesView = factor.FactorChangesView ?? "";
                //    factor.FactorChangesView += ("," + userId);
                //    factor.FactorChangesView = factor.FactorChangesView.TrimStart(',');
                //}
                //return await _FactorRepo.Update2Async(factor);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<CustomerRequestEnt> listCustomerRequest()
        {
            try
            {
                return _customerRequestRepo.GetAll().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ItemModifireAnswerEnt> ListItemModifireAnswerByCustomerRequest(int id)
        {
            try
            {
                return _itemModifireAnswerRepo.GetAll().Where(p => p.CustomerRequestID == id).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool DeleteModifireAnswer(long id)
        {
            try
            {
                return _itemModifireAnswerRepo.Delete(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteCustomerRequest(int id)
        {
            try
            {
                return _customerRequestRepo.Delete(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public CustomerRequestEnt CustomerRequestDetails(int id, long itemId = 0)
        {
            try
            {
                var model = _customerRequestRepo.GetAll().FirstOrDefault(p => p.ID == id);
                model.ItemID = itemId == 0 ? (_customerRequest_itemRepo.GetAll().LastOrDefault(p => p.CustomerRequestID == model.ID)?.ItemID ?? 0) : itemId;

                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ItemModifireAnswerEnt> ListAnswerOfCustomerRequest(int id, long itemId = 0)
        {
            try
            {
                if (itemId == 0)
                    return _itemModifireAnswerRepo.GetAll().Where(p => p.CustomerRequestID == id).OrderBy(p => p.ID).ToList();

                else
                //check this again  //http://localhost:1636/User/ItemRequest/2065?step=7&modifireId=0&itemId=10

                {


                    var ListAllModifireAnswer = ListAnswerOfCustomerRequest(id);

                    var ListModifire = ListItemModifireByItemID(itemId);
                    var ListAnsweredModifire = new List<ItemModifireAnswerEnt>();
                    foreach (var modifire in ListModifire)
                    {


                        if (ListAllModifireAnswer.Any(p => p.ItemModifireID == modifire.ID))
                            ListAnsweredModifire.Add(ListAllModifireAnswer.FirstOrDefault(p => p.ItemModifireID == modifire.ID));
                    }
                    return ListAnsweredModifire;


                }
            }
            catch (Exception ex)
            {
                return new List<ItemModifireAnswerEnt>();
            }
        }

        public async Task<List<ItemModifireAnswerEnt>> ListAnswerOfCustomerRequestAsync(int id, long itemId = 0)
        {
            try
            {
                if (itemId == 0)
                    return await _itemModifireAnswerRepo.GetAllAsync().Where(p => p.CustomerRequestID == id).OrderBy(p => p.ID).ToListAsync();

                else
                //check this again  //http://localhost:1636/User/ItemRequest/2065?step=7&modifireId=0&itemId=10

                {
                    var ListAllModifireAnswer = await ListAnswerOfCustomerRequestAsync(id);

                    var ListModifire = await ListItemModifireByItemIDAsync(itemId);
                    var ListAnsweredModifire = new List<ItemModifireAnswerEnt>();
                    foreach (var modifire in ListModifire)
                    {


                        if (ListAllModifireAnswer.Any(p => p.ItemModifireID == modifire.ID))
                            ListAnsweredModifire.Add(ListAllModifireAnswer.FirstOrDefault(p => p.ItemModifireID == modifire.ID));
                    }
                    return ListAnsweredModifire;


                }
            }
            catch (Exception ex)
            {
                return new List<ItemModifireAnswerEnt>();
            }
        }

        private long GetItemIDByModifireID(long itemModifireID)
        {
            try
            {
                return _item_itemModifireRepo.GetAll().FirstOrDefault(p => p.ItemModifireID == itemModifireID)?.Item_ID ?? 0;
            }
            catch (Exception ex)
            {

                return 0;
            }
        }

        public bool AddLaborCost(LaborCostEnt model)
        {
            try
            {
                return _laborCostRepo.Insert(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> AddLaborCostAsync(LaborCostEnt model)
        {
            try
            {
                return await _laborCostRepo.InsertAsync(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<LaborCostEnt> ListLaborByFactorID(int fid)
        {
            try
            {
                return _laborCostRepo.GetAll().Where(p => p.FactorID == fid).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<LaborCostEnt>> ListLaborByFactorIDAsync(int fid)
        {
            try
            {
                return await _laborCostRepo.GetAllAsync().Where(p => p.FactorID == fid).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool DeleteLaborCost(int id)
        {
            try
            {
                return _laborCostRepo.Delete(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> DeleteLaborCostAsync(int id)
        {
            try
            {
                return await _laborCostRepo.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public LaborCostEnt LaborCostDetails(int id)
        {
            try
            {
                return _laborCostRepo.GetAll().FirstOrDefault(p => p.ID == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<LaborCostEnt> LaborCostDetailsAsync(int id)
        {
            try
            {
                return await _laborCostRepo.GetAllAsync().FirstOrDefaultAsync(p => p.ID == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ItemModifireEnt> ListItemModifireByItemID(long id)
        {
            try
            {
                var listItemItem_Modifire = _item_itemModifireRepo.GetAll();
                var listItem_Modifire = _itemModifiresRepo.GetAll();
                var listModifire = (from iim in listItemItem_Modifire
                                    join im in listItem_Modifire on iim.ItemModifireID equals im.ID
                                    where iim.Item_ID == id
                                    select im).ToList();
                return listModifire;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<ItemModifireEnt>> ListItemModifireByItemIDAsync(long id)
        {
            try
            {
                var listItemItem_Modifire = await _item_itemModifireRepo.GetAllAsync().ToListAsync();
                var listItem_Modifire = await _itemModifiresRepo.GetAllAsync().ToListAsync();
                var listModifire = (from iim in listItemItem_Modifire
                                    join im in listItem_Modifire on iim.ItemModifireID equals im.ID
                                    where iim.Item_ID == id
                                    select im).ToList();
                return listModifire;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool ifAnsweredModifireByCustomerRequest(int customerRequestID, long itemModifireID)
        {
            try
            {
                return _itemModifireAnswerRepo.GetAll().Any(p => p.CustomerRequestID == customerRequestID & p.ItemModifireID == itemModifireID);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> ifAnsweredModifireByCustomerRequestAsync(int customerRequestID, long itemModifireID)
        {
            try
            {
                return await _itemModifireAnswerRepo.GetAllAsync().AnyAsync(p => p.CustomerRequestID == customerRequestID & p.ItemModifireID == itemModifireID);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public ItemModifireAnswerEnt ItemModifireAnswerDetailsByCustomerRequest(int customerRequestID, long itemModifireID)
        {
            try
            {
                return _itemModifireAnswerRepo.GetAll().FirstOrDefault(p => p.CustomerRequestID == customerRequestID & p.ItemModifireID == itemModifireID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ItemModifireAnswerEnt> ItemModifireAnswerDetailsByCustomerRequestAsync(int customerRequestID, long itemModifireID)
        {
            try
            {
                return await _itemModifireAnswerRepo.GetAllAsync().FirstOrDefaultAsync(p => p.CustomerRequestID == customerRequestID & p.ItemModifireID == itemModifireID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool AddCustomerRequest(CustomerRequestEnt model)
        {
            try
            {
                return _customerRequestRepo.Insert2(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditCustomerRequest(CustomerRequestEnt customerRequest)
        {
            try
            {
                return _customerRequestRepo.Update2(customerRequest);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddCustomerRequest_Item(CustomerRequest_ItemEnt model)
        {
            try
            {
                return _customerRequest_itemRepo.Insert2(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<ItemEnt> listItemSelectedOfCustomerRequest(int id)
        {
            try
            {
                return _customerRequest_itemRepo.GetAll().Where(p => p.CustomerRequestID == id).Select(p => p.Item).OrderBy(p => p.ID).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public CustomerRequestEnt CustomerRequestDetailsByFactorId(int id)
        {
            try
            {
                return _customerRequestRepo.GetAll().FirstOrDefault(p => p.FactorID == id);
            }
            catch (Exception ex)
            {
                return new CustomerRequestEnt() { ID = 0 };
            }
        }
        public async Task<CustomerRequestEnt> CustomerRequestDetailsByFactorIdAsync(int id)
        {
            try
            {
                return await _customerRequestRepo.GetAllAsync().FirstOrDefaultAsync(p => p.FactorID == id);
            }
            catch (Exception ex)
            {
                return new CustomerRequestEnt() { ID = 0 };
            }
        }

        public List<CustomerRequest_ItemEnt> listCustomerRequest_Item(int id)
        {
            try
            {
                return _customerRequest_itemRepo.GetAll().Where(p => p.CustomerRequestID == id).ToList();
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<List<CustomerRequest_ItemEnt>> listCustomerRequest_ItemAsync(int id)
        {
            try
            {
                return await _customerRequest_itemRepo.GetAllAsync().Where(p => p.CustomerRequestID == id).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool DeleteCustomerRequestItem(long id)
        {
            try
            {
                var item = _customerRequest_itemRepo.GetAll().FirstOrDefault(p => p.ItemID == id);
                return _customerRequest_itemRepo.Delete2(item.ID);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Factor_ItemEnt> ListAllTaxableFactor_Item()
        {
            try
            {
                return _Factor_ItemRepo.FromSql($"SELECT * FROM Factor_Items WHERE Taxable = 1 ;");
            }
            catch (Exception ex)
            {
                return new List<Factor_ItemEnt>();
            }
        }

        public async Task<List<Factor_ItemEnt>> ListAllTaxableFactor_ItemAsync()
        {
            try
            {
                return await _Factor_ItemRepo.GetAllAsync().Where(p => p.Taxable == true).ToListAsync();
            }
            catch (Exception ex)
            {
                return new List<Factor_ItemEnt>();
            }
        }

        public FactorItemDynamicData GetFactorPrice(int id)
        {
            try
            {
                var listFactorItem = ListFactor_Item(id);
                var data = new FactorItemDynamicData();
                data.FactorPrice = listFactorItem.Sum(p => p.Total);
                data.FactorLaberNumber = listFactorItem.Sum(p => p.LaberNumber);
                data.FactorInstallTime = listFactorItem.Sum(p => p.InstallTime);
                data.SUM_QHL = listFactorItem.Sum(p => p.InstallTime * p.LaberNumber * p.Quantity);
                data.MAX_L = listFactorItem.Max(p => p.LaberNumber);
                if (data.SUM_QHL != 0 & data.MAX_L != 0)
                    data.SUM_HL = (data.SUM_QHL + data.MAX_L - 1) / data.MAX_L;// (SUM_QHL / factor.MAX_L) round up
                return data;
            }
            catch (Exception ex)
            {

                return new FactorItemDynamicData();
            }
        }
        public async Task<FactorItemDynamicData> GetFactorPriceAsync(int id)
        {
            try
            {
                var listFactorItem = await ListFactor_ItemAsync(id);
                var data = new FactorItemDynamicData();
                data.FactorPrice = listFactorItem.Sum(p => p.Total);
                data.FactorLaberNumber = listFactorItem.Sum(p => p.LaberNumber);
                data.FactorInstallTime = listFactorItem.Sum(p => p.InstallTime);

                return data;
            }
            catch (Exception ex)
            {

                return new FactorItemDynamicData();
            }
        }
        public bool AddNoteByPo(string tagProjects, string note, string filePath, string sender)
        {
            try
            {
                var PoList = tagProjects.Replace(" ", "").Split('#');
                foreach (var po in PoList)
                {
                    var factor = FactorDetailsByPONumber(po);
                    if (factor != null)
                        AddFactorNote(note, factor.ID, filePath, sender);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateFactorTax(int factorID, bool IsProjectOrder = false, bool changeFactorPercent = true)
        {
            try
            {
                var factor = (_FactorRepo.GetAll()).FirstOrDefault(p => p.ID == factorID);

                if (factor == null) return false;

                if (IsProjectOrder == false)
                {
                    //Get Tax from city
                    var customerOrderTo = (_customerOrderToRepo.GetAll()).FirstOrDefault(p => p.FactorID == factorID);
                    if (customerOrderTo != null)
                    {
                        customerOrderTo.City = customerOrderTo.City ?? CityDetails(customerOrderTo.CityID);
                        factor.Tax = customerOrderTo.City.Tax;
                    }
                    var UseReseller = GetActiveRessellerPremit(factor.CustomerID);
                    if (UseReseller.isActive)
                    {
                        factor.Tax = 0;//Tax zero in reseller premit
                    }
                }
                // factor.Tax = newTax != 0 ? newTax : factor.Tax;
                var listFactorItem = ListFactor_Item(factorID);
                //  listFactorItem = listFactorItem.Select(p => {p.Quantity return p; }).ToList();
                factor.TaxableFactorPrice = listFactorItem.Where(p => p.Taxable == true).Sum(p => p.Total);

                if (factor.Tax > 0 & factor.TaxableFactorPrice > 0)
                    factor.TaxAmount = (double)(factor.TaxableFactorPrice * factor.Tax) / 100;
                else
                    factor.TaxAmount = 0;


                var listPayments = ConfirmFactorPaymeList(factorID);
                factor.FactorPrice = listFactorItem.Sum(p => p.Total);
                factor.FactorLaberNumber = listFactorItem.Sum(p => p.LaberNumber);
                factor.FactorInstallTime = listFactorItem.Sum(p => p.InstallTime);
                factor.SUM_QHL = listFactorItem.Sum(p => p.InstallTime * p.LaberNumber * p.Quantity);
                factor.MAX_L = listFactorItem.Max(p => p.LaberNumber);
                if (factor.SUM_QHL != 0 & factor.MAX_L != 0)
                    factor.SUM_HL = (factor.SUM_QHL + factor.MAX_L - 1) / factor.MAX_L;// (SUM_QHL / factor.MAX_L) round up
                if (listPayments != null)
                    factor.PaidPrice = listPayments.Sum(p => p.Price);
                factor.modifiedInfo += " ";
                var res = _FactorRepo.Update2(factor);
                if (changeFactorPercent) { if (res) UpdateFactorPaymentPercent(factorID, factor); }

                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public async Task<bool> UpdateFactorTaxAsync(int factorID, bool IsProjectOrder = false, bool changeFactorPercent = true)
        {
            try
            {
                var factor = FactorDetails(factorID);
                if (factor == null) return false;

                if (IsProjectOrder == false)
                {
                    //Get Tax from city
                    var customerOrderTo = await _customerOrderToRepo.GetAllAsync().FirstOrDefaultAsync(p => p.FactorID == factorID);
                    if (customerOrderTo != null)
                    {
                        customerOrderTo.City = customerOrderTo.City ?? await CityDetailsAsync(customerOrderTo.CityID);
                        factor.Tax = customerOrderTo.City.Tax;
                    }
                    var UseReseller = await GetActiveRessellerPremitAsync(factor.CustomerID);
                    if (UseReseller.isActive)
                    {
                        factor.Tax = 0;//Tax zero in reseller premit
                    }
                }
                var listFactorItem = await ListFactor_ItemAsync(factorID);
                factor.TaxableFactorPrice = listFactorItem.Where(p => p.Taxable == true).Sum(p => p.Total);

                if (factor.Tax > 0 & factor.TaxableFactorPrice > 0)
                    factor.TaxAmount = (double)(factor.TaxableFactorPrice * factor.Tax) / 100;
                else
                    factor.TaxAmount = 0;


                var listPayments = await ConfirmFactorPaymeListAsync(factorID);
                factor.FactorPrice = listFactorItem.Sum(p => p.Total);
                factor.FactorLaberNumber = listFactorItem.Sum(p => p.LaberNumber);
                factor.FactorInstallTime = listFactorItem.Sum(p => p.InstallTime);
                factor.SUM_QHL = listFactorItem.Sum(p => p.InstallTime * p.LaberNumber * p.Quantity);
                factor.MAX_L = listFactorItem.Max(p => p.LaberNumber);
                if (factor.SUM_QHL != 0 & factor.MAX_L != 0)
                    factor.SUM_HL = (factor.SUM_QHL + factor.MAX_L - 1) / factor.MAX_L;// (SUM_QHL / factor.MAX_L) round up
                if (listPayments != null)
                    factor.PaidPrice = listPayments.Sum(p => p.Price);
                factor.modifiedInfo += " ";

                //try
                //{
                //    await _FactorRepo.UpdateAsync(factor);
                //}
                //catch { }
                var res = await _FactorRepo.UpdateAsync(factor);
                if (changeFactorPercent) { if (res) await UpdateFactorPaymentPercentAsync(factorID, factor); }

                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateFactorPaymentPercent(int fid, FactorEnt factor = null)
        {
            try
            {
                if (factor == null)
                    factor = FactorDetails(fid);
                if (factor.ThirdPaymentPercent == 0 & factor.FourthPaymentPercent == 0 & factor.PaidPrice > 0)
                {
                    factor.FactorPrice = factor.FactorPrice + factor.TaxAmount;
                    var Minimum = ((factor.MinimumPaymentPercent * factor.FactorPrice) / 100).UptoTwoDecimalPoints();
                    var Second = ((factor.SecondPaymentPercent * factor.FactorPrice) / 100).UptoTwoDecimalPoints();
                    if (factor.PaidPrice == Minimum || factor.PaidPrice == (Minimum + Second))
                    {
                        //Nothing...
                    }
                    else if (factor.PaidPrice < Minimum)
                    {
                        var min = factor.PaidPrice;
                        factor.MinimumPaymentPercent = Math.Round(((min * 100) / factor.FactorPrice), 5);
                        factor.SecondPaymentPercent = 100 - factor.MinimumPaymentPercent;
                    }
                    else if (factor.PaidPrice > Minimum & factor.PaidPrice < (Minimum + Second))
                    {
                        var min = factor.PaidPrice;
                        factor.MinimumPaymentPercent = Math.Round(((min * 100) / factor.FactorPrice), 5);
                        factor.SecondPaymentPercent = 100 - factor.MinimumPaymentPercent;
                    }

                    _FactorRepo.Update(factor);
                    return true;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> UpdateFactorPaymentPercentAsync(int fid, FactorEnt factor = null)
        {
            try
            {
                if (factor == null)
                    factor = await FactorDetailsAsync(fid);

                if (factor.ThirdPaymentPercent == 0 & factor.FourthPaymentPercent == 0 & factor.PaidPrice > 0)
                {
                    factor.FactorPrice = factor.FactorPrice + factor.TaxAmount;
                    var Minimum = ((factor.MinimumPaymentPercent * factor.FactorPrice) / 100).UptoTwoDecimalPoints();
                    var Second = ((factor.SecondPaymentPercent * factor.FactorPrice) / 100).UptoTwoDecimalPoints();

                    if (factor.PaidPrice == Minimum || factor.PaidPrice == (Minimum + Second))
                    {
                        return true;
                    }
                    else if (factor.PaidPrice < Minimum)
                    {
                        var min = factor.PaidPrice;
                        factor.MinimumPaymentPercent = Math.Round(((min * 100) / factor.FactorPrice), 5);
                        factor.SecondPaymentPercent = 100 - factor.MinimumPaymentPercent;
                    }
                    else if (factor.PaidPrice > Minimum & factor.PaidPrice < (Minimum + Second))
                    {
                        var min = factor.PaidPrice;
                        factor.MinimumPaymentPercent = Math.Round(((min * 100) / factor.FactorPrice), 5);
                        factor.SecondPaymentPercent = 100 - factor.MinimumPaymentPercent;
                    }

                    return await _FactorRepo.UpdateAsync(factor);

                }
                return await _FactorRepo.UpdateAsync(factor);

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private List<PaymentEnt> ConfirmFactorPaymeList(int factorID)
        {
            try
            {
                return _paymentRepo.FromSql($"SELECT * FROM Payments  WHERE FactorID = {factorID} ;").Where(p => p.Confirmed).ToList();
            }
            catch (Exception ex)
            {

                return new List<PaymentEnt>();
            }
        }
        private async Task<List<PaymentEnt>> ConfirmFactorPaymeListAsync(int factorID)
        {
            try
            {
                return await _paymentRepo.GetAllAsync().Where(p => p.Confirmed & p.FactorID == factorID).ToListAsync();
            }
            catch (Exception ex)
            {

                return new List<PaymentEnt>();
            }
        }


        public CustomerOrderToEnt CustomerOrderToDeatils(int factorId)
        {
            try
            {
                var customerOrderTo = _customerOrderToRepo.GetAll().FirstOrDefault(p => p.FactorID == factorId);
                if (customerOrderTo == null)
                    return new CustomerOrderToEnt() { City = new CityEnt() { CityName = "" }, CompanyName = "" };
                customerOrderTo.City = _cityRepo.GetAll().Include(p => p.State).FirstOrDefault(p => p.ID == customerOrderTo.CityID);
                return customerOrderTo;
            }
            catch (Exception ex)
            {
                return new CustomerOrderToEnt() { City = new CityEnt() { CityName = "" }, CompanyName = "" };
            }
        }
        public async Task<CustomerOrderToEnt> CustomerOrderToDeatilsAsync(int factorId)
        {
            try
            {
                var customerOrderTo = await _customerOrderToRepo.GetAllAsync().Include(p => p.City).ThenInclude(p => p.State).Where(p => p.FactorID == factorId).FirstOrDefaultAsync();
                if (customerOrderTo == null)
                    return new CustomerOrderToEnt() { City = new CityEnt() { CityName = "" }, CompanyName = "" };


                if (customerOrderTo.City == null)
                    customerOrderTo.City = _cityRepo.GetAll().FirstOrDefault(p => p.ID == customerOrderTo.CityID);
                return customerOrderTo;
            }
            catch (Exception ex)
            {
                return new CustomerOrderToEnt() { City = new CityEnt() { CityName = "" }, CompanyName = "" };
            }
        }

        public async Task<CustomerOrderToEnt> CustomerOrderToDeatilsByIdAsync(int id)
        {
            try
            {
                var customerOrderTo = await _customerOrderToRepo.GetAllAsync().Where(p => p.ID == id).FirstOrDefaultAsync();

                return customerOrderTo;
            }
            catch (Exception ex)
            {
                return new CustomerOrderToEnt() { City = new CityEnt() { CityName = "" }, CompanyName = "" };
            }
        }

        public async Task<CustomerOrderToEnt> CustomerOrderToDeatilsByUserIdAsync(string id)
        {
            try
            {
                var customerOrderTo = await _customerOrderToRepo.GetAllAsync().Where(p => p.UserID == id).FirstOrDefaultAsync();

                return customerOrderTo;
            }
            catch (Exception ex)
            {
                return new CustomerOrderToEnt() { City = new CityEnt() { CityName = "" }, CompanyName = "" };
            }
        }

        public List<CustomerOrderToEnt> ListAllCustomerOrderTo()
        {
            try
            {
                return _customerOrderToRepo.GetAll().Include(p => p.City).ThenInclude(p => p.State).ToList();
            }
            catch (Exception ex)
            {
                return new List<CustomerOrderToEnt>();
            }
        }
        public async Task<List<CustomerOrderToEnt>> ListAllCustomerOrderToAsync()
        {
            try
            {
                return await _customerOrderToRepo.GetAllAsync().Include(p => p.City).ThenInclude(p => p.State).ToListAsync();
            }
            catch (Exception ex)
            {
                return new List<CustomerOrderToEnt>();
            }
        }
        public CityEnt CityDetails(int cityID)
        {
            try
            {
                return _cityRepo.GetAll().Include(p => p.State).FirstOrDefault(p => p.ID == cityID);
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<CityEnt> CityDetailsAsync(int cityID)
        {
            try
            {
                return await _cityRepo.GetAllAsync().Where(p => p.ID == cityID).Include(p => p.State).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<List<CityEnt>> ListCityAsync()
        {
            try
            {
                return (await _cityRepo.GetAllAsync().Include(p => p.State).ToListAsync());
            }
            catch (Exception ex)
            {
                return new List<CityEnt>();
            }
        }
        public IQueryable<CityEnt> ListCity()
        {
            try
            {
                return _cityRepo.GetAllAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<CityEnt>> ListCity_Default_Seattle_Async()
        {
            try
            {
                return await _cityRepo.GetAllAsync().OrderByDescending(p => p.CityName == "Seattle").ToListAsync();
            }
            catch (Exception ex)
            {
                return new List<CityEnt>();
            }
        }

        public bool AddFactorCreaditCard(int fid, string customerID, string cardNumers)
        {
            try
            {
                var factor = _FactorRepo.GetAll().FirstOrDefault(p => p.ID == fid);
                factor.CreditCardCustomerID = customerID;
                factor.CreditCardView = cardNumers;
                return _FactorRepo.Update(factor);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<StateEnt>> ListStateAsync()
        {
            try
            {
                return await _stateRepo.GetAllAsync().ToListAsync();
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public async Task<List<StateEnt>> ListState_Default_WA_Async()
        {
            try
            {
                return await _stateRepo.GetAllAsync().OrderByDescending(p => p.StateName == "WA").ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool ifExistItemInFactorItem(long id)
        {
            try
            {
                return _Factor_ItemRepo.GetAll().Any(p => p.ItemID == id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool IfUseItemModifireInItem(long id)
        {
            try
            {
                return _item_itemModifireRepo.GetAll().Any(p => p.ItemModifireID == id);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<bool> ifExistCustomerInProject(string customerId)
        {
            try
            {
                var List = await _FactorRepo.GetAllAsync().ToListAsync();
                return List.Any(p => p.CustomerID == customerId);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<double> TotalNotPayedAsync(int selectYear)
        {
            try
            {
                var factors = await _FactorRepo.GetAllAsync().Where(p => p.Date.Year == selectYear).ToListAsync();
                var listallItems = await FactorItemListAsync();
                foreach (var item in factors)
                {
                    var factorItems = listallItems.Where(i => i.FacrorID == item.ID);
                    item.FactorPrice = factorItems.Sum(i => i.Total) + item.TaxAmount;
                    item.Remaining = item.FactorPrice - item.PaidPrice;
                }

                return factors.Sum(p => p.Remaining).RoundDecimal();
            }
            catch (Exception ex)
            {

                return 0;
            }
        }

        public async Task<double> TotalNotPayedThisMonthAsync(int selectYear)
        {
            try
            {
                var dateNow = DateTime.Now.SystemTimee(); ;
                var factors = await _FactorRepo.GetAllAsync().Where(p => p.Date.Year == selectYear & p.Date.Month == dateNow.Month).ToListAsync();
                var listallItems = await FactorItemListAsync();
                foreach (var item in factors)
                {
                    var factorItems = listallItems.Where(i => i.FacrorID == item.ID);
                    item.FactorPrice = factorItems.Sum(i => i.Total) + item.TaxAmount;
                    item.Remaining = item.FactorPrice - item.PaidPrice;
                }

                return factors.Sum(p => p.Remaining).RoundDecimal();
            }
            catch (Exception ex)
            {

                return 0;
            }
        }

        public async Task<double> TotalOverDuePaymentAsync(int selectYear)
        {
            try
            {
                var factors = await _FactorRepo.GetAllAsync().Where(p => p.Date.Year == selectYear & p.Status == FactorStatus.Invoice_sent).ToListAsync();
                var listallItems = await FactorItemListAsync();
                foreach (var item in factors)
                {
                    var factorItems = listallItems.Where(i => i.FacrorID == item.ID);
                    item.FactorPrice = factorItems.Sum(i => i.Total) + item.TaxAmount;
                    item.Remaining = item.FactorPrice - item.PaidPrice;
                }

                return factors.Sum(p => p.Remaining).RoundDecimal();
            }
            catch (Exception ex)
            {

                return 0;
            }
        }

        public async Task<double> TotalNotDuePaymentAsync(int selectYear)
        {
            try
            {
                var factors = await _FactorRepo.GetAllAsync().Where(p => p.Date.Year == selectYear & p.Status < FactorStatus.Invoice_sent & p.Status > FactorStatus.Quoted).ToListAsync();
                var listallItems = await FactorItemListAsync();
                foreach (var item in factors)
                {
                    var factorItems = listallItems.Where(i => i.FacrorID == item.ID);
                    item.FactorPrice = factorItems.Sum(i => i.Total) + item.TaxAmount;
                    item.Remaining = item.FactorPrice - item.PaidPrice;
                }

                return factors.Sum(p => p.Remaining).RoundDecimal();
            }
            catch (Exception ex)
            {

                return 0;
            }
        }

        public async Task<double> TotalOverDuePaymentAsync(DateTime startTime, DateTime endTime)
        {
            try
            {
                var factors = await _FactorRepo.GetAllAsync().Where(p => p.Date.Date >= startTime.Date & p.Date.Date <= endTime.Date & p.Status == FactorStatus.Invoice_sent).ToListAsync();
                var listallItems = await FactorItemListAsync();
                foreach (var item in factors)
                {
                    var factorItems = listallItems.Where(i => i.FacrorID == item.ID);
                    item.FactorPrice = factorItems.Sum(i => i.Total) + item.TaxAmount;
                    item.Remaining = item.FactorPrice - item.PaidPrice;
                }

                return factors.Sum(p => p.Remaining);
            }
            catch (Exception ex)
            {

                return 0;
            }
        }

        public async Task<double> TotalNotDuePaymentAsync(DateTime startTime, DateTime endTime)
        {
            try
            {
                var factors = await _FactorRepo.GetAllAsync().Where(p => p.Date.Date >= startTime.Date & p.Date.Date <= endTime.Date & p.Status < FactorStatus.Invoice_sent & p.Status > FactorStatus.Quoted).ToListAsync();
                var listallItems = await FactorItemListAsync();
                foreach (var item in factors)
                {
                    var factorItems = listallItems.Where(i => i.FacrorID == item.ID);
                    item.FactorPrice = factorItems.Sum(i => i.Total) + item.TaxAmount;
                    item.Remaining = item.FactorPrice - item.PaidPrice;
                }

                return factors.Sum(p => p.Remaining);
            }
            catch (Exception ex)
            {

                return 0;
            }
        }

        public async Task<bool> AddCustomerOrderToAsync(CustomerOrderToEnt orderTo)
        {
            try
            {
                return await _customerOrderToRepo.InsertAsync(orderTo);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool EditCustomerOrderto(CustomerOrderToEnt orderTo)
        {
            try
            {
                return _customerOrderToRepo.Update(orderTo);
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public async Task<bool> EditCustomerOrdertoAsync(CustomerOrderToEnt orderTo)
        {
            try
            {
                return await _customerOrderToRepo.UpdateAsync(orderTo);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<bool> EditCustomerOrderto2Async(CustomerOrderToEnt orderTo)
        {
            try
            {
                return await _customerOrderToRepo.Update2Async(orderTo);
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public async Task<List<FactorItem_ImageEnt>> ListUnsortedImageAsync()
        {
            try
            {
                var list = await _factorItem_ImageRepo.GetAllAsync().Where(p => p.FactorID == 0 & p.Factor_ItemID == null).OrderByDescending(p => p.ID).ToListAsync();
                return list;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<List<ReportExpenseDate>> ListReportProjectVSPayment(int thisYear, List<PaymentEnt> paymentList, bool allMonth = true)
        {
            try
            {
                var dateNow = DateTime.Now.SystemTimee();
                var listExpense = await ListAllFactorsAsync();
                var listExpenseIncome = new List<ReportExpenseDate>();
                for (int i = 1; i <= 12; i++)
                {

                    if (allMonth == false) if (dateNow.Year == thisYear & dateNow.SystemTimee().Month < i) break;

                    var monthDate = new DateTime(thisYear, i, 1, 0, 0, 0);
                    listExpenseIncome.Add(new ReportExpenseDate()
                    {
                        Month = monthDate.ToString("MMM"),
                        Value1 = paymentList.Count(p => p.Confirmed && p.PayDate.Year == thisYear & p.PayDate.Month == monthDate.Month).ToString(),

                        Value2 = listExpense.Count(p => p.Date.Year == thisYear & p.Date.Month == monthDate.Month).ToString(),
                    });
                }

                return listExpenseIncome;
            }
            catch (Exception ex)
            {
                return new List<ReportExpenseDate>();
            }
        }

        public async Task<FactorTaskEnt> FactorTaskDetailsAsync(long id)
        {
            try
            {
                return await _factorTaskRepo.GetAllAsync().FirstOrDefaultAsync(p => p.ID == id);
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<bool> AddFactorTaskAsync(FactorTaskEnt model)
        {
            try
            {
                return await _factorTaskRepo.InsertAsync(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<FactorTaskEnt>> ListFactorTaskAsync(string userID = "")
        {
            try
            {
                if (userID == "")
                    return await _factorTaskRepo.GetAllAsync().ToListAsync();
                else
                    return await _factorTaskRepo.GetAllAsync().Where(p => p.EmployeeID == userID).ToListAsync();


            }
            catch (Exception ex)
            {

                return new List<FactorTaskEnt>();
            }
        }

        public async Task<List<FactorTaskEnt>> ListFactorTaskAsync(string userID, DateTime NewStartTime, DateTime NewEndTime)
        {
            try
            {
                var listTask = await _factorTaskRepo.GetAllAsync().Where(p => p.EmployeeID == userID).ToListAsync();
                listTask = listTask.Where(p => (NewStartTime > p.StartDate & NewStartTime < p.EndDate) ||
                                               (NewEndTime < p.EndDate & NewEndTime > p.StartDate) ||
                                               (NewStartTime <= p.StartDate & NewEndTime >= p.EndDate)
                                               ).ToList();
                return listTask;
            }
            catch (Exception ex)
            {
                return new List<FactorTaskEnt>();
            }
        }

        public async Task<List<FactorTaskEnt>> ListDoneFactorTaskAsync(string userID = "")
        {
            try
            {
                if (userID == "")
                    return await _factorTaskRepo.GetAllAsync().Where(p => p.Done).ToListAsync();
                else
                    return await _factorTaskRepo.GetAllAsync().Where(p => p.Done & p.EmployeeID == userID).ToListAsync();
            }
            catch (Exception ex)
            {
                return new List<FactorTaskEnt>();
            }
        }
        public async Task<List<FactorTaskEnt>> ListFactorTaskAsync(int factorID)
        {
            try
            {

                return await _factorTaskRepo.GetAllAsync().Where(p => p.FactorID == factorID).ToListAsync();


            }
            catch (Exception ex)
            {

                return new List<FactorTaskEnt>();
            }
        }

        public async Task<List<FactorTaskEnt>> ListAllFactorTaskAsync()
        {
            try
            {
                return await _factorTaskRepo.GetAllAsync().ToListAsync();
            }
            catch (Exception ex)
            {

                return new List<FactorTaskEnt>();
            }
        }

        public async Task<bool> EditFactorTaskAsync(FactorTaskEnt task)
        {
            try
            {
                return await _factorTaskRepo.UpdateAsync(task);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<List<string>> ListUserHasFactorTaskAsync()
        {
            try
            {
                var allTask = await _factorTaskRepo.GetAllAsync().ToListAsync();
                var userlist = allTask.GroupBy(p => p.EmployeeID)
                       .Select(g => g.First().EmployeeID)
                       .ToList();
                userlist = userlist.OrderByDescending(p => allTask.Count(t => t.EmployeeID == p)).ToList();
                return userlist;

            }
            catch (Exception ex)
            {
                return new List<string>();
            }
        }

        public async Task<List<string>> ListSortedUserByMaxFactorTaskAsync(List<string> userlist)
        {
            try
            {
                var allTask = await _factorTaskRepo.GetAllAsync().ToListAsync();

                userlist = userlist.OrderByDescending(p => allTask.Count(t => t.EmployeeID == p)).ToList();
                return userlist;

            }
            catch (Exception ex)
            {
                return new List<string>();
            }
        }

        public async Task<FactorTaskEnt> GetLastFactorTaskAsync()
        {
            try
            {
                var modelList = await _factorTaskRepo.GetAllAsync().ToListAsync();
                var task = modelList.LastOrDefault();
                if (task == null)
                    task = new FactorTaskEnt()
                    {
                        StartDate = DateTime.Now.SystemTimee(),
                        EndDate = DateTime.Now.SystemTimee().AddHours(1)
                    };

                return task;
            }
            catch (Exception ex)
            {
                return new FactorTaskEnt()
                {
                    StartDate = DateTime.Now.SystemTimee(),
                    EndDate = DateTime.Now.SystemTimee().AddHours(1)
                };
            }
        }

        public async Task<bool> DeleteFactorTaskAsync(long id)
        {
            try
            {
                return await _factorTaskRepo.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> ExistPONumber(int pONumber)
        {
            try
            {
                var find = _FactorRepo.FromSql($"SELECT * FROM Factors WHERE PONumber = {pONumber} ;").FirstOrDefault();
                if (find == null)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }


        public async Task<ResellerPremitStatus> GetActiveRessellerPremitAsync(string customerID, DateTime? now = null)
        {
            try
            {
                if (now == null) now = DateTime.Now.SystemTimee();
                var listReseller = await _resellerPermitRepo.GetAllAsync().Where(p => p.UserID == customerID).ToListAsync();
                var find = listReseller.LastOrDefault(p => p.ExpirationDate > now & p.EffectiveDate < now);
                if (find == null)
                {

                    return new ResellerPremitStatus()
                    {
                        isActive = false,
                        Exist = listReseller.Any(),
                        ResellerPermit = listReseller.Any() ? listReseller.FirstOrDefault().ResellerPermit : "",

                    };
                }
                var resellerPremit = new ResellerPremitStatus()
                {
                    ID = find.ID,
                    EffectiveDate = find.EffectiveDate,
                    ExpirationDate = find.ExpirationDate,
                    File = find.File,
                    EffectiveDatee = find.EffectiveDate.ToString("yyyy/MM/dd"),
                    ExpirationDatee = find.ExpirationDate.ToString("yyyy/MM/dd"),
                    ResellerPermit = find.ResellerPermit,
                    Exist = true,
                    isActive = true,
                };

                return resellerPremit;
            }
            catch (Exception ex)
            {

                return new ResellerPremitStatus()
                {
                    isActive = false,
                    Exist = false

                };
            }
        }
        public ResellerPremitStatus GetActiveRessellerPremit(string customerID, DateTime? now = null)
        {
            try
            {
                if (now == null) now = DateTime.Now.SystemTimee();
                var listReseller = (_resellerPermitRepo.GetAll()).Where(p => p.UserID == customerID).ToList();
                var find = listReseller.LastOrDefault(p => p.ExpirationDate > now & p.EffectiveDate < now);
                if (find == null)
                {

                    return new ResellerPremitStatus()
                    {
                        isActive = false,
                        Exist = listReseller.Any(),
                        ResellerPermit = listReseller.Any() ? listReseller.FirstOrDefault().ResellerPermit : "",

                    };
                }
                var resellerPremit = new ResellerPremitStatus()
                {
                    ID = find.ID,
                    EffectiveDate = find.EffectiveDate,
                    ExpirationDate = find.ExpirationDate,
                    File = find.File,
                    EffectiveDatee = find.EffectiveDate.ToString("yyyy/MM/dd"),
                    ExpirationDatee = find.ExpirationDate.ToString("yyyy/MM/dd"),
                    ResellerPermit = find.ResellerPermit,
                    Exist = true,
                    isActive = true,
                };

                return resellerPremit;
            }
            catch (Exception ex)
            {

                return new ResellerPremitStatus()
                {
                    isActive = false,
                    Exist = false

                };
            }
        }

        public async Task<List<ResellerPermitEnt>> ListAllResellerPremitAsync(string id)
        {
            try
            {
                return await _resellerPermitRepo.GetAllAsync().Where(p => p.UserID == id).OrderByDescending(p => p.ExpirationDate).ToListAsync();
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<bool> DeleteReseller(long id)
        {
            try
            {
                return await _resellerPermitRepo.DeleteAsync(id);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<bool> AddResellerPremitAsync(ResellerPermitEnt model)
        {
            try
            {
                return await _resellerPermitRepo.InsertAsync(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<ResellerPermitEnt> ResellerPremitDetailsAsync(long id)
        {
            try
            {
                return await _resellerPermitRepo.GetAllAsync().FirstOrDefaultAsync(p => p.ID == id);
            }
            catch (Exception ex)
            {

                return new ResellerPermitEnt();
            }
        }

        public ResellerPermitEnt ResellerPremitDetails(long id)
        {
            try
            {
                return (_resellerPermitRepo.GetAll()).FirstOrDefault(p => p.ID == id);
            }
            catch (Exception ex)
            {

                return new ResellerPermitEnt();
            }
        }

        public async Task<bool> AddLastActivityAsync(LastActivityEnt lastActivity)
        {
            try
            {
                return await _lasdtActivirtRepo.Insert2Async(lastActivity);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IQueryable<LastActivityEnt> ListLastActivity()
        {
            try
            {
                return _lasdtActivirtRepo.GetAllAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> DeleteLastActivity(long id)
        {
            try
            {
                return await _lasdtActivirtRepo.DeleteAsync(id);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<bool> AddFactorNoteAsync(FactorNoteEnt factorNote)
        {
            return await AddFactorNoteAsync(factorNote.Note, factorNote.FactorID, factorNote.FilePath, factorNote.modifiedInfo, factorNote.FactorTaskID);
        }
    }
}

