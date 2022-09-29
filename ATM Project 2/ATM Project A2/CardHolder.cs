using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Project_A2
{
    public class CardHolder
    {
        string firstName;
        string lastName;
        public string cardNumber;
        public int pin;
        float balance;

        public string GetFirstName() => firstName;
        public void SetFirstName(string newFirstName) => firstName = newFirstName;
        public string GetLastName() => lastName;
        public void SetLastName(string newLastName) => lastName = newLastName;
        public string GetCardNumber() => cardNumber;
        public void SetCardNumber(string newCardNumber) => cardNumber = newCardNumber;
        public int GetPin() => pin;
        public void SetPin(int newPin) => pin = newPin;
        public float GetBalance() => balance;
        public void SetBalance(float newBalance) => balance = newBalance;
        


        public CardHolder(string firstName, string lastName, string cardNumber, int pin, float balance)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.cardNumber = cardNumber;
            this.pin = pin;
            this.balance = balance;
        }
    }
}
