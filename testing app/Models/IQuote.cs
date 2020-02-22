using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing_app.Models
{
    public interface IQuote
    {
        int GetAge(DateTime currentDate, DateTime DOB);

        decimal CalculatePenaltyFee();

        decimal CalculatePremium();

        decimal CalculateQuote();
    }
}
