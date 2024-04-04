

namespace Infrastructure.Entity
{
   
    public class RolePermisionEnt : EntityBase<int>
    {
        public string? RoleID { get; set; }
        public string? ActionCategory { get; set; }
        public string? ActionName { get; set; }
        public bool Read { get; set; }
        public bool Write { get; set; }
        public bool Delete { get; set; }

    }


    public enum ActionType
    {
        UnKnow = 0,
        Add = 1,
        Delete = 2,
        Read = 3,
        System = 4,
        Write = 5,

    }



}