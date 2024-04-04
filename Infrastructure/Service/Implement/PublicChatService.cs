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
    public class PublicChatService : IPublicChatService
    {
        IRepositoryBase<PublicChatEnt, long> _PublicChatRepo;



        public PublicChatService(IRepositoryBase<PublicChatEnt, long> _PublicChatRepo)
        {
            this._PublicChatRepo = _PublicChatRepo;
        }

        public bool AddPublicChat(PublicChatEnt item)
        {
            try
            {
                item.ReadMessage = item.TagUsers;
                return _PublicChatRepo.Insert(item);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool DeletePublicChat(long id)
        {
            try
            {
                return _PublicChatRepo.Delete(id);

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool EditPublicChat(PublicChatEnt item)
        {
            try
            {
                return _PublicChatRepo.Update(item);
            }
            catch (Exception ex)
            {

                return false;
            }
        }


        public PublicChatEnt PublicChatDetails(long id)
        {
            try
            {
                return _PublicChatRepo.GetAll().Where(p => p.ID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public List<PublicChatEnt> ListPublicChats(int skip, int take)
        {
            try
            {
                var count = PublicChatsCount();
                if (skip + take > count)
                    take = count - skip;
                return _PublicChatRepo.FromSql($"SELECT * FROM PublicChats ORDER BY ID DESC    OFFSET  {skip} ROWS    FETCH NEXT {take} ROWS ONLY; ");
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public List<PublicChatEnt> SearchPublicChats(string search)
        {
            try
            {


                return _PublicChatRepo.FromSql($"SELECT * FROM PublicChats WHERE LOWER(Note) LIKE LOWER('%{search} ROWS    FETCH NEXT ");
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public int PublicChatsCount()
        {
            try
            {
                return _PublicChatRepo.FromSql($"SELECT * FROM PublicChats ").Count();

            }
            catch (Exception ex)
            {

                return 10000;
            }
        }

        public List<PublicChatEnt> ListPublicChats()
        {
            try
            {
                return _PublicChatRepo.GetAll().ToList().Select(p => { p.Note = p.Note ?? ""; return p; }).ToList();
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public bool ReadMyMessage(string userName)
        {
            try
            {
                var name = userName.Trim(' ').Trim(' ').Replace(' ', '_');
                var readMessaes = _PublicChatRepo.GetAll().Where(p => !string.IsNullOrEmpty(p.ReadMessage));
                foreach (var item in readMessaes)
                {
                    item.ReadMessage = item.ReadMessage.Replace("@" + name, "");

                    _PublicChatRepo.Update(item);
                }
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
