using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManager_CarsDB
{
    class Car
    {
        public string Mark { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public Car() { }
        public Car(string mark, string model, int year)
        {
            Mark = mark;
            Model = model;
            Year = year;
        }
    }
}
