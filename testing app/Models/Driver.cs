using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing_app.Models
{
    public enum InsuranceType { Comprehensive, ThirdParty }
    public class Driver : IQuote
    {
        public decimal VehicleValue { get; set; }
        public DateTime DOB { get; set; }
        public InsuranceType InsuranceType { get; set; }
        public int PenaltyPoints { get; set; }


        public Driver() { }

        // points cannot be below zero or over 12
        public decimal CalculatePenaltyFee()
        {
            int points = PenaltyPoints;
            decimal charge = 0m;

            if (points < 0 || points > 12)
            {
                charge = -1;
            }
            else if (points == 0)
            {
                charge = 0;
            }
            else if (points <= 4)
            {
                charge = 100;
            }
            else if (points <= 7)
            {
                charge = 200;
            }
            else if (points <= 10)
            {
                charge = 300;
            }
            else if (points <= 12)
            {
                charge = 400;
            }

            return charge;
        }

        public decimal CalculatePremium(DateTime currentDate)
        {
            decimal basicPremium;
            int age = GetAge(currentDate, DOB);
            if (InsuranceType == InsuranceType.Comprehensive) {
                basicPremium = 0.04m;
            }
            else
            {
                basicPremium = 0.025m;
            }
            
            if(age >= 18 && age <= 25)
            {
                basicPremium += 0.1m;
            }
            return basicPremium;
        }

        public decimal CalculateQuote(DateTime currentDate)
        {
            decimal result;
            if (GetAge(currentDate, DOB) >= 18 && CalculatePenaltyFee() != -1)
            {
                result = (CalculatePremium(currentDate) * VehicleValue) + CalculatePenaltyFee();
            } 
            else
            {
                result = -1;
            }
            return result;
        }

        public int GetAge(DateTime currentDate, DateTime DOB)
        {
            int age = currentDate.Year - DOB.Year;
            if (DOB > currentDate.AddYears(-age))
            {
                age--;
            }
            return age;
        }
    }
}
