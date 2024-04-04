

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;


namespace Infrastructure.Entity
{
    public class PublicChatEnt : EntityBase<long>
    {

        public string? Note { get; set; }
        public string? TagUsers { get; set; }
        public string? ReadMessage { get; set; }
        public string? TagProjects { get; set; }
        public string? FilePath { get; set; }
        public string? UserID { get; set; }
        public DateTime SendDate { get; set; }


    }
    public class PublicChatViewModel : EntityBase<long>
    {

        public string Note { get; set; }
        public string TagUsers { get; set; }
        public string ReadMessage { get; set; }
        public string TagProjects { get; set; }
        public string FilePath { get; set; }
        public string UserID { get; set; }
        public DateTime SendDate { get; set; }


        public string UserFullName { get; set; }
        public string UserPhoto { get; set; }

        public string Time { get; set; }
        public string Date { get; set; }
        public string Direction { get; set; }

        
        public string SenderMessageColor { get; set; }
        public bool FileExist { get; set; }
        public bool changeDate { get; set; }

        public PublicChatViewModel() {
            changeDate = false;
            Direction = "LeftToRight";//
            SenderMessageColor = "#ffffff";
        }

    }


}