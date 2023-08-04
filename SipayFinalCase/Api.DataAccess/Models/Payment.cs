using Api.Base.BaseModel;

namespace Api.DataAccess.Models
{
    public class Payment : IdBaseModel
    {
        public int UserId { get; set; }

        public string PaymentAmount { get; set; }

        public virtual User User { get; set; }
    }
}
