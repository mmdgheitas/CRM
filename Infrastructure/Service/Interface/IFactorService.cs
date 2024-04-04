﻿using Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Interface
{
    public interface IFactorService
    {
        Task<bool> ifExistCustomerInProject(string customerId);

        IQueryable<FactorEnt> ListAllFactors(bool reloadFactorPrice = false);
        Task<List<FactorEnt>> ListAllFactorsAsync(bool reloadFactorPrice = false);
        Task<bool> DeleteFactorAsync(int id);
        FactorEnt FactorDetails(int id);
        Task<FactorEnt> FactorDetailsAsync(int id);
        bool AddFactor(FactorEnt item);
        Task<bool> AddFactorAsync(FactorEnt item);
        bool EditFactor(FactorEnt item, FactorEnt oldFactor = null, string date = "");
        Task<bool> EditFactorAsync(FactorEnt item, FactorEnt oldFactor = null, string date = "");
        bool UpdateFactor(FactorEnt item);
        Task<bool> UpdateFactorAsync(FactorEnt item);
        bool IfExistCustomer(string id);
        bool IfUsedVandorsFactor_item(int id);
        Task<int> GetLastFactorNumber(DateTime now);
        List<Factor_ItemEnt> ListFactor_Item(int id);
        Task<List<Factor_ItemEnt>> ListFactor_ItemAsync(int id);
        Task<List<Factor_ItemEnt>> ListFactorItemAsync(int id);
        List<Factor_ItemEnt> ListAllFactor_Item();
        Task<FactorTaskEnt> FactorTaskDetailsAsync(long id);
        Task<List<Factor_ItemEnt>> ListAllFactor_ItemAsync();
        Task<bool> AddFactor_ItemAsync(Factor_ItemEnt modelItem);
       bool AddFactor_Item(Factor_ItemEnt modelItem);

        bool DeleteFactorProduct(int id);
        Factor_ItemEnt FactorProductDetails(int id);
        bool IfUsedShippingsFactor_item(int id);
        List<ItemCategoryEnt> ListItemCategory();
        Task<List<ItemCategoryEnt>> ListItemCategoryAsync();
        bool IfUsedItemCategory(int id);
        bool DeleteItemCategory(int id);
        ItemCategoryEnt ItemCategoryDetails(int id);
        bool AddItemCategory(ItemCategoryEnt model);
        List<ItemEnt> ListAllItem();
        bool EditItemCategory(ItemCategoryEnt model);
        List<ItemEnt> ListItem();
        Task<List<ItemEnt>> ListItemAsync();
        bool IFExistItemCategoryName(string name, int id = 0);
        List<ItemModifireEnt> ListItemModifire();
        Task<List<ItemModifireEnt>> ListItemModifireAsync();
        bool DeleteItemModifire(long id);
        bool ifExistItemInFactorItem(long id);
        ItemModifireEnt ItemModifireDetails(long id);
        Task<ItemModifireEnt> ItemModifireDetailsAsync(long id);
        bool IFExistItemModifireName(string name, long id = 0);
        Task<FactorTaskEnt> GetLastFactorTaskAsync();

        bool AddItemModifire(ItemModifireEnt model);
        string DeleteItem(long id);
        bool EditItemModifire(ItemModifireEnt model);
        bool ifExistModofiresName(string name, long id);
        List<ItemModifireEnt> ListModifires();
        ItemEnt ItemDetails(long id);
        bool IsModifireInItem(long modifireId, long itemId);
        Task<bool> IsModifireInItemAsync(long modifireId, long itemId);
        int Item_ModifirePriority(long modifireId, long itemId);
        Task<int> Item_ModifirePriorityAsync(long modifireId, long itemId);
        bool IfExistItemName(string name, long id = 0);
        bool AddItem(ItemEnt model);
        bool EditItem(ItemEnt model);
        bool AddModifireToItem(long modifireId, long itemId, int priority);
        bool DeleteModofireFromItem(long modifireId, long itemId);
        bool UpdateModifireToItem(long modifireId, long itemId, int priority);
        List<ItemModifireEnt> ListItemModifireByCategoryID(int id);
        double GetLastItemNumber(int factorId);
        Task<double> GetLastItemNumberAsync(int factorId);
        List<FactorEnt> ListFactors(string id = "", bool reloadFactorPrice = true);
        Task<List<FactorEnt>> ListFactorsAsync(string id = "", int take = 0, bool reloadFactorPrice = true);
        List<FactorEnt> ListFactors(int skip, int take, bool reloadFactorPrice = true);
        Task<bool> AddFactorTaskAsync(FactorTaskEnt model);
        bool DeleteFactorItem(long id);
        Task<bool> DeleteFactorItemAsync(long id);
        Factor_ItemEnt FactorItemDetails(long id);
        Task<Factor_ItemEnt> FactorItemDetailsAsync(long id);
        Task<bool> EditFactorItemAsync(Factor_ItemEnt model);
        Task<bool> EditFactorItem2Async(Factor_ItemEnt model);
        bool ResetAllFactorItem(int id, int ponumber);
        bool AddItemModifireAnswer(ItemModifireAnswerEnt model);
        Task<bool> AddItemModifireAnswerAsync(ItemModifireAnswerEnt model);
        bool UpdateFactorItem(Factor_ItemEnt factorItem);
        Task<bool> UpdateFactorItemAsync(Factor_ItemEnt factorItem);
        bool ifAnsweredModifire(long factorItemId, long ItemModifireId);
        Task<bool> ifAnsweredModifireAsync(long factorItemId, long ItemModifireId);
        ItemModifireAnswerEnt ItemModifireAnswerDetails(long id);
        ItemModifireAnswerEnt ItemModifireAnswerDetails(long factorItemId, long ItemModifireId);
        Task<ItemModifireAnswerEnt> ItemModifireAnswerDetailsAsync(long factorItemId, long ItemModifireId);
        bool EditItemModifireAnswer(ItemModifireAnswerEnt answerModel);
        Task<bool> EditItemModifireAnswerAsync(ItemModifireAnswerEnt answerModel);
        bool UpdateFactorItem_ItemText(long factorItemId);
        Task<bool> UpdateFactorItem_ItemTextAsync(long factorItemId);
        List<Factor_ItemEnt> ListTaxableFactor_Item(int iD);
        bool AddFActorItemImage(FactorItem_ImageEnt fileModel);
        Task<bool> AddFActorItemImageAsync(FactorItem_ImageEnt fileModel);
        Task<List<Factor_ItemEnt>> ListAllTaxableFactor_ItemAsync();
        List<FactorItem_ImageEnt> ListFActorItemImage(long id);
        Task<List<FactorItem_ImageEnt>> ListFActorItemImageAsync(long id);
        List<FactorItem_ImageEnt> ListFactorImage(int factorID);
        Task<List<FactorItem_ImageEnt>> ListFactorImageAsync(int factorID);
        FactorEnt FactorDetailsByRequestID(long id);
        Task<FactorEnt> FactorDetailsByRequestIDAsync(long id);
        List<Factor_ItemEnt> FactorItemList();
        Task<List<Factor_ItemEnt>> FactorItemListAsync();
        bool DeleteFactorItemFile(long id);
        Task<bool> DeleteFactorItemFileAsync(long id);
        FactorItem_ImageEnt FactorItemImageDetails(long id);
        Task<FactorItem_ImageEnt> FactorItemImageDetailsAsync(long id);
        Task<bool> UpdateFactorItemFileAsync(FactorItem_ImageEnt itemImage);
        bool UpdateFactorItemImage(FactorItem_ImageEnt model);
        Task<bool> UpdateFactorItemImageAsync(FactorItem_ImageEnt model);
        bool IsCommericalFactor(int jobId);

        Task<int> GenetateNewPONumberAsync(DateTime now);
        Task<double> GenerateItemNumber(FactorEnt factor);
        List<FactorItem_ImageEnt> ListFactorImageRemoveFromItem(int factorid);
        Task<List<FactorItem_ImageEnt>> ListFactorImageRemoveFromItemAsync(int factorid);
        CustomerOrderToEnt OrderToDetailsBtFactorID(int id);
        Task<CustomerOrderToEnt> OrderToDetailsBtFactorIDAsync(int id);
        bool AddOrderTo(CustomerOrderToEnt orderTo);
        Task<bool> IfExistImageInAnotherFactor(string image, int factorID);
        bool IfExistImageInAnotherItem(string photo, long iD);
        bool AddFactorNote(string text, int factorId, string filePath = "", string userSender = "");
        Task<bool> AddFactorNoteAsync(string text, int? factorId, string filePath = "", string userSender = "", long factorTask = 0);
        Task<bool> AddFactorNoteAsync(FactorNoteEnt factorNote);
        List<FactorNoteEnt> ListFactorNotes(int id);
        Task<List<FactorNoteEnt>> ListFactorNotesAsync(int id, long factorTaskID = 0);
        bool isInstallerInFactor(string installerId, int factorId);
        Task<bool> isInstallerInFactorAsync(string installerId, int factorId);
        bool AddFactorInstaller(string insallerId, int factorID);
        Task<bool> AddFactorInstallerAsync(string insallerId, int factorID);
        bool DeleteFactorInstaller(string installerId, int factorID);
        Task<bool> DeleteFactorInstallerAsync(string installerId, int factorID);
        FactorEnt FactorDetailsByPONumber(int PoNumber);

        bool UpdateFactorChangeView(int factorId, string userId);
        Task<bool> UpdateFactorChangeViewAsync(int factorId, string userId);
        Task<List<CityEnt>> ListCityAsync();
        IQueryable<CityEnt> ListCity();
        Task<List<CityEnt>> ListCity_Default_Seattle_Async();
        Task<List<StateEnt>> ListStateAsync();
        Task<List<StateEnt>> ListState_Default_WA_Async();
        Task<bool> UpdateAppoitmentChangeView(int factorId, string userId);
        Task<bool> UpdatePaymentChangeView(int factorId, string userId);
        Task<bool> UpdateOrderChangeView(int factorId, string userId);
        Task<bool> UpdateNoteChangeView(int factorId, string userId);
        Task<bool> UpdateGalleryChangeView(int factorId, string userId);

        bool ResetFactorChangeView(int factorId, string userId);
        Task<bool> ResetFactorChangeViewAsync(int factorId, string userId);
        bool ResetAppoitmentChangeView(int factorId, string userId);
        Task<bool> ResetPaymentChangeView(int factorId, string userId);
        Task<bool> ResetOrderChangeView(int factorId, string userId);
        Task<bool> ResetNoteChangeView(int factorId, string userId);
        Task<bool> ResetGalleryChangeView(int factorId, string userId);
        bool DeleteComment(long id);
        Task<bool> DeleteCommentAsync(long id);
        Task<bool> IfExistFactorItemImage(string fileName);
        FactorEnt FactorDetailsByPrivateKey(string id);
        Task<FactorEnt> FactorDetailsByPrivateKeyAsync(string id);
        bool IfExistImageInFactorItem(string image, long? factor_ItemID);
        Task<bool> IfExistImageInFactorItemAsync(string image, long? factor_ItemID);
        bool ResetContractChangeView(int factorId, string userId);
        Task<bool> UpdateContractChangeView(int factorId, string userId);
        List<CustomerRequestEnt> listCustomerRequest();
        List<ItemModifireAnswerEnt> ListItemModifireAnswerByCustomerRequest(int id);
        bool DeleteModifireAnswer(long id);
        bool DeleteCustomerRequest(int id);
        CustomerRequestEnt CustomerRequestDetails(int id, long itemId = 0);
        List<ItemModifireAnswerEnt> ListAnswerOfCustomerRequest(int crid, long ItemId = 0);
        Task<List<ItemModifireAnswerEnt>> ListAnswerOfCustomerRequestAsync(int crid, long ItemId = 0);

        bool AddLaborCost(LaborCostEnt model);
        Task<bool> AddLaborCostAsync(LaborCostEnt model);
        List<LaborCostEnt> ListLaborByFactorID(int fid);
        Task<List<LaborCostEnt>> ListLaborByFactorIDAsync(int fid);
        bool DeleteLaborCost(int id);
        Task<bool> DeleteLaborCostAsync(int id);
        LaborCostEnt LaborCostDetails(int id);
        Task<LaborCostEnt> LaborCostDetailsAsync(int id);
        List<ItemModifireEnt> ListItemModifireByItemID(long id);
        Task<List<ItemModifireEnt>> ListItemModifireByItemIDAsync(long id);
        bool ifAnsweredModifireByCustomerRequest(int customerRequestID, long itemModifireID);
        Task<bool> ifAnsweredModifireByCustomerRequestAsync(int customerRequestID, long itemModifireID);
        ItemModifireAnswerEnt ItemModifireAnswerDetailsByCustomerRequest(int customerRequestID, long itemModifireID);
        Task<ItemModifireAnswerEnt> ItemModifireAnswerDetailsByCustomerRequestAsync(int customerRequestID, long itemModifireID);
        bool AddCustomerRequest(CustomerRequestEnt model);
        bool EditCustomerRequest(CustomerRequestEnt customerRequest);
        bool AddCustomerRequest_Item(CustomerRequest_ItemEnt model);
        List<ItemEnt> listItemSelectedOfCustomerRequest(int id);
        CustomerRequestEnt CustomerRequestDetailsByFactorId(int id);
        Task<CustomerRequestEnt> CustomerRequestDetailsByFactorIdAsync(int id);
        List<CustomerRequest_ItemEnt> listCustomerRequest_Item(int id);
        Task<List<CustomerRequest_ItemEnt>> listCustomerRequest_ItemAsync(int id);
        bool DeleteCustomerRequestItem(long id);
        FactorItemDynamicData GetFactorPrice(int id);
        bool AddNoteByPo(string tagProjects, string note, string filepath, string sender);
        bool ExistAnyPendingItemInFactor(int factorId);
        Task<bool> ExistAnyPendingItemInFactorAsync(int factorId);
        bool UpdateFactorTax(int factorID, bool IsProjectOrder = false, bool changeFactorPercent = true);
        Task<bool> UpdateFactorTaxAsync(int factorID, bool IsProjectOrder = false, bool changeFactorPercent = true);
  

        bool UpdateFactorPaymentPercent(int fid, FactorEnt factor = null);//If exist factor send. then send factorId
        Task<bool> UpdateFactorPaymentPercentAsync(int fid, FactorEnt factor = null);//If exist factor send. then send factorId
        CustomerOrderToEnt CustomerOrderToDeatils(int factorId);
        Task<bool> ExistPONumber(int pONumber);
        Task<CustomerOrderToEnt> CustomerOrderToDeatilsAsync(int factorId);
        Task<CustomerOrderToEnt> CustomerOrderToDeatilsByIdAsync(int id);
        Task<CustomerOrderToEnt> CustomerOrderToDeatilsByUserIdAsync(string id);
        List<CustomerOrderToEnt> ListAllCustomerOrderTo();
        Task<List<CustomerOrderToEnt>> ListAllCustomerOrderToAsync();
        CityEnt CityDetails(int cityID);
        Task<CityEnt> CityDetailsAsync(int cityID);
        bool AddFactorCreaditCard(int fid, string customerID, string cardNumers);
        bool IfUseItemModifireInItem(long id);
        Task<double> TotalNotPayedAsync(int selectYear);
        Task<double> TotalNotPayedThisMonthAsync(int selectYear);
        Task<double> TotalOverDuePaymentAsync(int selectYear);//Remaining balance that project status invoiced
        Task<double> TotalNotDuePaymentAsync(int selectYear);
        Task<double> TotalOverDuePaymentAsync(DateTime startTime, DateTime endTime);
        Task<double> TotalNotDuePaymentAsync(DateTime startTime, DateTime endTime);
        Task<bool> AddCustomerOrderToAsync(CustomerOrderToEnt orderTo);
        Task<bool> EditCustomerOrdertoAsync(CustomerOrderToEnt orderTo);
        Task<bool> EditCustomerOrderto2Async(CustomerOrderToEnt orderTo);
        bool EditCustomerOrderto(CustomerOrderToEnt orderTo);
        Task<List<FactorItem_ImageEnt>> ListUnsortedImageAsync();
        Task<List<ReportExpenseDate>> ListReportProjectVSPayment(int selectYear, List<PaymentEnt> paymentList, bool allMonth = true);
        Task<List<FactorTaskEnt>> ListFactorTaskAsync(string userID = "");
        Task<List<FactorTaskEnt>> ListFactorTaskAsync(string userID, DateTime startTime, DateTime endTime);
        Task<List<string>> ListUserHasFactorTaskAsync();
        Task<List<string>> ListSortedUserByMaxFactorTaskAsync(List<string> userlist);
        Task<List<FactorTaskEnt>> ListDoneFactorTaskAsync(string userID = "");

        Task<List<FactorTaskEnt>> ListFactorTaskAsync(int factorID);

        Task<bool> EditFactorTaskAsync(FactorTaskEnt task);

        Task<bool> DeleteFactorTaskAsync(long id);



        Task<ResellerPremitStatus> GetActiveRessellerPremitAsync(string customerID, DateTime? now = null);
        ResellerPremitStatus GetActiveRessellerPremit(string customerID, DateTime? now = null);
        Task<List<ResellerPermitEnt>> ListAllResellerPremitAsync(string id);
        Task<bool> DeleteReseller(long id);
        Task<bool> AddResellerPremitAsync(ResellerPermitEnt model);
        Task<ResellerPermitEnt> ResellerPremitDetailsAsync(long id);
        ResellerPermitEnt ResellerPremitDetails(long id);
        Task<bool> AddLastActivityAsync(LastActivityEnt lastActivity);
        IQueryable<LastActivityEnt> ListLastActivity();
        Task<bool> DeleteLastActivity(long id);
    }
}