using Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Interface
{
    public interface ISMSService
    {
        bool UpdateAccount(SMSAccountEnt smsAccount);
        SMSAccountEnt AccountDetails(short accountID);
        bool AddAccount(SMSAccountEnt item);
        List<SMSAccountEnt> ListAllAccount();
        List<SMSAccountEnt> ListActiveAccount();
        bool IFExistDefaultAccount(short id);
        bool DeleteAccount(short id);
        bool ifAccountExist(string userName, short iD);
        bool EditAccount(SMSAccountEnt item);
        SMSAccountEnt DefaultAccountDetails();
       List<SMSContactEnt> ListAllContact(int id = 0);
        bool DeleteContact(long id);
        SMSContactEnt ContactDetails(long id);
        bool ifPhoneNumberExist(string phoneNumber, long iD);
        bool AddContact(SMSContactEnt item);
        bool EditContact(SMSContactEnt item);
        List<SMSGroupEnt> ListAllGroup();
        bool DeleteGroup(int id);
        SMSGroupEnt GroupDetails(int id);
        bool ifGroupNameExist(string phoneNumber, int id = 0);
        bool AddGroup(SMSGroupEnt item);
        bool EditGroup(SMSGroupEnt item);
        long SumNumberOfGroupContact(int id);
        bool IsContactInGroup(long contactID, int groupID);
        bool AddContactToGroup(long contactID, int groupID);
        bool DeleteContactFromGroup(long contactID, int groupID);
        List<SMSGroupEnt> ListGroupForContact(long contactID);
        List<SMSGroupNoNameEnt> ListAllGroupNoName();
        long SumNumberOfGroupNoNameContact(int id);
        bool DeleteGroupNoName(int id);
        SMSGroupNoNameEnt GroupNoNameDetails(int id);
        bool ifGroupNoNameNameExist(string name, int id = 0);
        bool AddGroupNoName(SMSGroupNoNameEnt model);
        bool EditGroupNoName(SMSGroupNoNameEnt model);
        SMSAccountEnt AccountDetailsByNumber(string senderNumber);

        bool AddSendSMS(SendSMSEnt item);
        bool UpdateSendSMS(SendSMSEnt sendSMS);
        List<SendSMSEnt> ListSMSSent();
        string ContactDetailsByPhoneNumber(string value);
        SendSMSEnt SMSSentDetails(long id);
        SendSMSEnt SendSMSDetails(long id);
        SendSMSEnt SendSMSDetailsBygroupmid(string usergroupid, string number);
        SMSGroupNoNameEnt SMSGroupNoNameDetails(long groupID);
       List<SMSDraftEnt> ListAllDraft();
        bool DeleteDraft(int id);
        SMSDraftEnt DraftDetails(int id);
        bool AddDraft(SMSDraftEnt item);
        bool EditDraft(SMSDraftEnt item);
    }
}
