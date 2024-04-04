using AutoMapper;
using Infrastructure.Entity;
using Interface.Data;
using Interface.Models.Factor;
using Interface.Models.Payment;
using Interface.Models.Plaid;
using Interface.Models.Setting;

namespace Interface.Models
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {


            CreateMap<User, ApplicationUser>().ReverseMap();
            //   CreateMap<User, ApplicationUser>().ReverseMap();
            CreateMap<ApplicationUser, User>().ReverseMap();

            CreateMap<appUser, ApplicationUser>().ReverseMap();
            CreateMap<ApplicationUser, appUser>().ReverseMap();

            CreateMap<Factor_ItemEnt, Factor_ItemModel>().ReverseMap();
            CreateMap<Factor_ItemModel, Factor_ItemEnt>().ReverseMap();

            CreateMap<JobTypeModel, JobTypeEnt>().ReverseMap();
            CreateMap<JobTypeEnt, JobTypeModel>().ReverseMap();

            CreateMap<EmailSettingModel, EmailSettingEnt>().ReverseMap();
            CreateMap<EmailSettingEnt, EmailSettingModel>().ReverseMap();

            CreateMap<Factor_ItemEnt, FactorItemReport>().ReverseMap();
            CreateMap<FactorItemReport, Factor_ItemEnt>().ReverseMap();

            CreateMap<ToolsModel, ToolsEnt>().ReverseMap();
            CreateMap<ToolsEnt, ToolsModel>().ReverseMap();

            CreateMap<OrderModel, OrderEnt>().ReverseMap();
            CreateMap<OrderEnt, OrderModel>().ReverseMap();

            CreateMap<PaymentModel, PaymentEnt>().ReverseMap();
            CreateMap<PaymentEnt, PaymentModel>().ReverseMap();

            CreateMap<FactorModel, FactorEnt>().ReverseMap();
            CreateMap<FactorEnt, FactorModel>().ReverseMap();



            CreateMap<FactorTaskViewModel, FactorTaskEnt>().ReverseMap();
            CreateMap<FactorTaskEnt, FactorTaskViewModel>().ReverseMap();

            CreateMap<RequestEstimateAppointmentEnt, RequestEstimateAppointmentModel>().ReverseMap();

            CreateMap<RequestEstimateAppointmentModel, RequestEstimateAppointmentEnt>().ReverseMap();

            CreateMap<RequestInstallerAppointmentEnt, RequestInstallerAppointmentModel>().ReverseMap();

            CreateMap<RequestInstallerAppointmentModel, RequestInstallerAppointmentEnt>().ReverseMap();



            CreateMap<RequestInstallerAppointmentEnt, RequestEstimateAppointmentModel>().ReverseMap();

            CreateMap<RequestEstimateAppointmentModel, RequestInstallerAppointmentEnt>().ReverseMap();



            CreateMap<FactorItem_ImageEnt, FactorItem_ImageModel>().ReverseMap();

            CreateMap<FactorItem_ImageModel, FactorItem_ImageEnt>().ReverseMap();




            CreateMap<ItemModifireModel, ItemModifireEnt>().ReverseMap();

            CreateMap<ItemModifireEnt, ItemModifireModel>().ReverseMap();


            CreateMap<PaymentModel, EstimatePaymentModel>().ReverseMap();

            CreateMap<EstimatePaymentModel, PaymentModel>().ReverseMap();



            CreateMap<User, Client>().ReverseMap();

            CreateMap<Client, User>().ReverseMap();

            CreateMap<ItemModel, ItemEnt>().ReverseMap();

            CreateMap<ItemEnt, ItemModel>().ReverseMap();


            CreateMap<Appt_Time, InstallerAppointmentEnt>().ReverseMap();

            CreateMap<InstallerAppointmentEnt, Appt_Time>().ReverseMap();

            CreateMap<Appt_Time, EstimateAppointmentEnt>().ReverseMap();

            CreateMap<EstimateAppointmentEnt, Appt_Time>().ReverseMap();

            CreateMap<EmailSettingEnt, EmailSettingModel>().ReverseMap();

            CreateMap<EmailSettingModel, EmailSettingEnt>().ReverseMap();


            CreateMap<WorkSchedulingModel, WorkSchedulingEnt>().ReverseMap();

            CreateMap<WorkSchedulingEnt, WorkSchedulingModel>().ReverseMap();

            CreateMap<FactorItemReport, Factor_ItemEnt>().ReverseMap();

            CreateMap<Factor_ItemEnt, FactorItemReport>().ReverseMap();

            CreateMap<SubmitSignEnt, PaymentModel>().ReverseMap();

            CreateMap<PaymentModel, SubmitSignEnt>().ReverseMap();


            CreateMap<UnsortedGallery, FactorItem_ImageEnt>().ReverseMap();
            CreateMap<FactorItem_ImageEnt, UnsortedGallery>().ReverseMap();

            CreateMap<FactorStatusViewModel, FactorModel>().ReverseMap();
            CreateMap<FactorModel, FactorStatusViewModel>().ReverseMap();

            CreateMap<EmployeeUser, ApplicationUser>().ReverseMap();
            CreateMap<ApplicationUser, EmployeeUser>().ReverseMap();

            CreateMap<PlaidTransactionViewModel, PlaidTransactionEnt>().ReverseMap();
            CreateMap<PlaidTransactionEnt, PlaidTransactionViewModel>().ReverseMap();

            CreateMap<PlaidAccountViewModel, PlaidAccountEnt>().ReverseMap();
            CreateMap<PlaidAccountEnt, PlaidAccountViewModel>().ReverseMap();


            CreateMap<TimeCardModel, TimeCardEnt>().ReverseMap();
            CreateMap<TimeCardEnt, TimeCardModel>().ReverseMap();

            CreateMap<Interface.Data.ApplicationRole, Interface.Models.MyRole>().ReverseMap();
            CreateMap<Interface.Models.MyRole, Interface.Data.ApplicationRole>().ReverseMap();

            CreateMap<ExpenseModel, ExpenseEnt>().ReverseMap();
            CreateMap<ExpenseEnt, ExpenseModel>().ReverseMap();

            CreateMap<UserApp, ApplicationUser>().ReverseMap();
            CreateMap<ApplicationUser, UserApp>().ReverseMap();


            CreateMap<Factor_ItemEnt, Factor_ItemReportViewmodel>().ReverseMap();
            CreateMap<Factor_ItemReportViewmodel, Factor_ItemEnt>().ReverseMap();


            CreateMap<PaymentModelApp, PaymentEnt>().ReverseMap();
            CreateMap<PaymentEnt, PaymentModelApp>().ReverseMap();

            CreateMap<FactorNoteEnt, NoteApplicationModel>().ReverseMap();
            CreateMap<NoteApplicationModel, FactorNoteEnt>().ReverseMap();


            CreateMap<TaskEnt, TaskViewModel>().ReverseMap();
            CreateMap<TaskViewModel, TaskEnt>().ReverseMap();

            CreateMap<InstallerAppointmentEnt, InstallerAppointmentViewModel>().ReverseMap();
            CreateMap<InstallerAppointmentViewModel, InstallerAppointmentEnt>().ReverseMap();


            CreateMap<EstimateAppointmentEnt, InstallerAppointmentEnt>().ReverseMap();
            CreateMap<InstallerAppointmentEnt, EstimateAppointmentEnt>().ReverseMap();

            CreateMap<ResellerPremitViewModel, ResellerPermitEnt>().ReverseMap();
            CreateMap<ResellerPermitEnt, ResellerPremitViewModel>().ReverseMap();

            CreateMap<FactorEnt, FactorEnt>().ForMember(p => p.ID, x => x.Ignore());
            CreateMap<Factor_ItemEnt, Factor_ItemEnt>().ForMember(p => p.ID, x => x.Ignore());

            CreateMap<FactorItem_ImageEnt, FactorItem_ImageEnt>().ForMember(p => p.ID, x => x.Ignore());



            CreateMap<PaymentRefundModel, PaymentEnt>().ReverseMap();
            CreateMap<PaymentEnt, PaymentRefundModel>().ReverseMap();


    CreateMap<ItemModifireModel, ItemModifireEnt>().ReverseMap();
            CreateMap<ItemModifireEnt, ItemModifireModel>().ReverseMap();


    CreateMap<CustomerRequestEnt, CustomerRequestModel>().ReverseMap();
            CreateMap<CustomerRequestModel, CustomerRequestEnt>().ReverseMap();


        }
    }
}
