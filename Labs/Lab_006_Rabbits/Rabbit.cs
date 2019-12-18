using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_006_Rabbits
{
    class Rabbit
    {

        public Rabbit(string RabbitName, int RabbitAge)
        {
            this.RabbitName = RabbitName;
            this.RabbitAge = RabbitAge;
        }
        public int RabbitId { get; set; }
        public string RabbitName { get; set; }
        public int RabbitAge { get; set; }
    }


}
