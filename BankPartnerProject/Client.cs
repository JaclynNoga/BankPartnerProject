using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankPartnerProject
{
    class Client
    {
        //FIELDS
        private string clientName;
        private int accountNum;
        private Random rand = new Random();

        //PROPERTIES
        public string ClientName { get; set; }
        public int AccountNum { get; set; }

        //CONSTRUCTOR
        public Client()
        {
            this.ClientName = "Julia Goolia";
            this.AccountNum = RandomGenerator();
        }

        //METHOD
        public int RandomGenerator()    //returns some 5 digit number
        {
            int randAccountNum = rand.Next(10000, 99999);
            return randAccountNum;
        }
    }
}
