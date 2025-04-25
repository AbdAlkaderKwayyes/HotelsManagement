using Domain.Enums;

namespace Domain.Models
{
    public class Payment
    {
        public int Id { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime CreatedDate { get; set; }


        public int BookingId { get; set; }


        //بفرض هنا أن طريقة الدفع الافتراضية هي cash
        public PaymentWay paymentWay = PaymentWay.Cash;
    }
}
