namespace ParkingManager_CarsDB
{
    class Car
    {
        public int ID { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public Car() { }
        public Car(int id, string mark, string model, int year)
        {
            ID = id;    
            Mark = mark;
            Model = model;
            Year = year;
        }
    }
}
