using Infrastructure.Entity;
using Infrastructure.Repository;
using Infrastructure.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Implement
{
    public class SMSService : ISMSService
    {
        IRepositoryBase<SMSAccountEnt, short> _smsAccountRepo;
        IRepositoryBase<SMSContactEnt, long> _smsContactRepo;
        IRepositoryBase<SMSGroupEnt, int> _smsGroupRepo;
        IRepositoryBase<Group_ContactEnt, long> _Group_ContactRepo;
        IRepositoryBase<SMSGroupNoNameEnt, int> _GroupNoNameRepo;
        IRepositoryBase<SendSMSEnt, long> _SendSMSRepo;
        IRepositoryBase<SendSMSGroupEnt, long> _SendSMSGroupRepo;
        IRepositoryBase<SMSDraftEnt, int> _SMSDraftRepo;

        public SMSService(IRepositoryBase<SMSAccountEnt, short> _smsAccountRepo,
            IRepositoryBase<SMSContactEnt, long> _smsContactRepo,
            IRepositoryBase<SMSGroupEnt, int> _smsGroupRepo,
             IRepositoryBase<Group_ContactEnt, long> _Group_ContactRepo,
               IRepositoryBase<SMSGroupNoNameEnt, int> _GroupNoNameRepo,
               IRepositoryBase<SendSMSEnt, long> _SendSMSRepo,
               IRepositoryBase<SendSMSGroupEnt, long> _SendSMSGroupRepo,
                   IRepositoryBase<SMSDraftEnt, int> _SMSDraftRepo
            )
        {
            this._smsAccountRepo = _smsAccountRepo;
            this._smsContactRepo = _smsContactRepo;
            this._smsGroupRepo = _smsGroupRepo;
            this._Group_ContactRepo = _Group_ContactRepo;
            this._GroupNoNameRepo = _GroupNoNameRepo;
            this._SendSMSRepo = _SendSMSRepo;
            this._SendSMSGroupRepo = _SendSMSGroupRepo;
            this._SMSDraftRepo = _SMSDraftRepo;
        }

        public SMSService(IRepositoryBase<SMSAccountEnt, short> _smsAccountRepo,
            IRepositoryBase<SendSMSEnt, long> _SendSMSRepo
         )
        {
            this._smsAccountRepo = _smsAccountRepo;
            this._SendSMSRepo = _SendSMSRepo;
        }

        public SMSAccountEnt AccountDetails(short accountID)
        {
            try
            {
                return _smsAccountRepo.GetAll().Where(p => p.ID == accountID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool UpdateAccount(SMSAccountEnt smsAccount)
        {
            try
            {
                return _smsAccountRepo.Update(smsAccount);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddAccount(SMSAccountEnt item)
        {
            try
            {
                return _smsAccountRepo.Insert(item);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<SMSAccountEnt> ListAllAccount()
        {
            try
            {
                return _smsAccountRepo.GetAll().OrderBy(p => p.UserName).ToList() ;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<SMSAccountEnt> ListActiveAccount()
        {
            try
            {
                return _smsAccountRepo.GetAll().Where(p => p.isActive == true).ToList();
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public bool IFExistDefaultAccount(short id = 0)
        {
            try
            {
                if (id == 0)
                    return _smsAccountRepo.GetAll().Where(p => p.isDefault == true).Any();
                else
                    return _smsAccountRepo.GetAll().Where(p => p.isDefault == true & p.ID != id).Any();
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool DeleteAccount(short id)
        {
            try
            {
                return _smsAccountRepo.Delete(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ifAccountExist(string userName, short id = 0)
        {
            try
            {
                if (id == 0)
                    return _smsAccountRepo.GetAll().Where(p => p.UserName == userName).Any();
                else
                    return _smsAccountRepo.GetAll().Where(p => p.UserName == userName & p.ID != id).Any();
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool EditAccount(SMSAccountEnt item)
        {
            try
            {
                return _smsAccountRepo.Update(item);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public SMSAccountEnt DefaultAccountDetails()
        {
            try
            {
                return _smsAccountRepo.GetAll().Where(p => p.isDefault == true).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<SMSContactEnt> ListAllContact(int id = 0)
        {
            try
            {
                if (id == 0)
                    return (from c in _smsContactRepo.GetAll()
                            select c).ToList();
                else
                    return (from c in _smsContactRepo.GetAll()
                            join gc in _Group_ContactRepo.GetAll() on c.ID equals gc.SMSContactID
                            where gc.SMSGroupID == id
                            select c).ToList();

            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public bool DeleteContact(long id)
        {
            try
            {
                return _smsContactRepo.Delete(id);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public SMSContactEnt ContactDetails(long id)
        {
            try
            {
                return _smsContactRepo.GetAll().Where(p => p.ID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool ifPhoneNumberExist(string phoneNumber, long id)
        {
            try
            {
                if (id == 0)
                    return _smsContactRepo.GetAll().Where(p => p.PhoneNumber == phoneNumber).Any();
                else
                    return _smsContactRepo.GetAll().Where(p => p.PhoneNumber == phoneNumber & p.ID != id).Any();
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddContact(SMSContactEnt item)
        {
            try
            {

                return _smsContactRepo.Insert(item);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditContact(SMSContactEnt item)
        {
            try
            {
                return _smsContactRepo.Update(item);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<SMSGroupEnt> ListAllGroup()
        {
            try
            {
                return _smsGroupRepo.GetAll().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool DeleteGroup(int id)
        {
            try
            {
                return _smsGroupRepo.Delete(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }





        public bool AddGroup(SMSGroupEnt item)
        {
            try
            {
                return _smsGroupRepo.Insert(item);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditGroup(SMSGroupEnt item)
        {
            try
            {
                return _smsGroupRepo.Update(item);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public SMSGroupEnt GroupDetails(int id)
        {
            try
            {
                return _smsGroupRepo.GetAll().Where(p => p.ID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool ifGroupNameExist(string Name, int id = 0)
        {
            try
            {
                if (id == 0)
                    return _smsGroupRepo.GetAll().Where(p => p.Name == Name).Any();
                else
                    return _smsGroupRepo.GetAll().Where(p => p.Name == Name & p.ID != id).Any();
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public long SumNumberOfGroupContact(int id)
        {
            try
            {
                return _Group_ContactRepo.GetAll().Where(p => p.SMSGroupID == id).ToList().Count();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public bool IsContactInGroup(long contactID, int groupID)
        {
            try
            {
                return _Group_ContactRepo.GetAll().Where(p => p.SMSContactID == contactID & p.SMSGroupID == groupID).Any();
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddContactToGroup(long contactID, int groupID)
        {
            var gc = new Group_ContactEnt()
            {
                SMSContactID = contactID,
                SMSGroupID = groupID
            };

            if (!IsContactInGroup(contactID, groupID))
                return _Group_ContactRepo.Insert(gc);
            else
                return true;
        }

        public bool DeleteContactFromGroup(long contactID, int groupID)
        {
            var gc = _Group_ContactRepo.GetAll().Where(p => p.SMSContactID == contactID & p.SMSGroupID == groupID).FirstOrDefault();

            if (gc != null)
                return _Group_ContactRepo.Delete(gc.ID);
            else
                return true;
        }

        public List<SMSGroupEnt> ListGroupForContact(long contactID)
        {
            try
            {
                return (from g in _smsGroupRepo.GetAll()
                        join gc in _Group_ContactRepo.GetAll() on g.ID equals gc.SMSGroupID
                        where gc.SMSContactID == contactID
                        select g).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<SMSGroupNoNameEnt> ListAllGroupNoName()
        {
            try
            {
                return _GroupNoNameRepo.GetAll().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public long SumNumberOfGroupNoNameContact(int id)
        {
            try
            {
                return -10;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public bool DeleteGroupNoName(int id)
        {
            try
            {
                return _GroupNoNameRepo.Delete(id);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public SMSGroupNoNameEnt GroupNoNameDetails(int id)
        {
            try
            {
                return _GroupNoNameRepo.GetAll().Where(p => p.ID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool ifGroupNoNameNameExist(string name, int id = 0)
        {
            try
            {
                if (id == 0)
                    return _GroupNoNameRepo.GetAll().Where(p => p.Name == name).Any();
                else
                    return _GroupNoNameRepo.GetAll().Where(p => p.Name == name & p.ID != id).Any();
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddGroupNoName(SMSGroupNoNameEnt model)
        {
            try
            {
                return _GroupNoNameRepo.Insert(model);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool EditGroupNoName(SMSGroupNoNameEnt model)
        {
            try
            {
                return _GroupNoNameRepo.Update(model);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public SMSAccountEnt AccountDetailsByNumber(string senderNumber)
        {
            try
            {
                return _smsAccountRepo.GetAll().Where(p => p.PhoneNumber == senderNumber.ToString()).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool AddSendSMS(SendSMSEnt item)
        {
            try
            {
                return _SendSMSRepo.Insert(item);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateSendSMS(SendSMSEnt sendSMS)
        {
            try
            {
                return _SendSMSRepo.Update(sendSMS);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<SendSMSEnt> ListSMSSent()
        {
            try
            {
                return _SendSMSRepo.GetAll().Where(p => p.isSent == true).OrderByDescending(p => p.ID).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string ContactDetailsByPhoneNumber(string phoneNumber)
        {
            try
            {
                return _smsContactRepo.GetAll().Where(p => p.PhoneNumber == phoneNumber).FirstOrDefault().FullName;
            }
            catch (Exception ex)
            {

                return "--";
            }
        }

        public SendSMSEnt SMSSentDetails(long id)
        {
            try
            {
                return _SendSMSRepo.GetAll().Where(p => p.ID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public SendSMSEnt SendSMSDetails(long id)
        {
            try
            {
                return _SendSMSRepo.GetAll().Where(p => p.ID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {

                return new SendSMSEnt();
            }
        }

        public SendSMSEnt SendSMSDetailsBygroupmid(string groupmid, string number)
        {
            try
            {
                return _SendSMSRepo.GetAll().Where(p => p.groupmid == groupmid & p.Sender == number).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public SMSGroupNoNameEnt SMSGroupNoNameDetails(long groupID)
        {
            try
            {
                return _GroupNoNameRepo.GetAll().Where(p => p.ID == groupID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<SMSDraftEnt> ListAllDraft()
        {
            try
            {
                return _SMSDraftRepo.GetAll().OrderBy(P => P.Title).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool DeleteDraft(int id)
        {
            try
            {
                return _SMSDraftRepo.Delete(id);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public SMSDraftEnt DraftDetails(int id)
        {
            try
            {
                return _SMSDraftRepo.GetAll().Where(p => p.ID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public bool AddDraft(SMSDraftEnt item)
        {
            try
            {
                return _SMSDraftRepo.Insert(item);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool EditDraft(SMSDraftEnt item)
        {
            try
            {
                return _SMSDraftRepo.Update(item);
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
