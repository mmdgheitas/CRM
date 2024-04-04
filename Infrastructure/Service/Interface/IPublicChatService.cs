using Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Interface
{
    public interface IPublicChatService
    {
        List<PublicChatEnt> ListPublicChats(int skip,int take);
        List<PublicChatEnt> ListPublicChats();
        bool DeletePublicChat(long id);
        PublicChatEnt PublicChatDetails(long id);
        bool AddPublicChat(PublicChatEnt item);
        bool EditPublicChat(PublicChatEnt item);
        int PublicChatsCount();
        List<PublicChatEnt> SearchPublicChats(string search);
        bool ReadMyMessage(string userName);
    }
}
