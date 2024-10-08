﻿namespace Practica_2
{
    class Taxi : RegisteredVehicle
    {
        //constant string as TypeOfVehicle wont change allong PoliceCar instances.
        private bool isCarryingPassengers;
        private City? city;

        public Taxi(string plate) : base("Taxi", plate)
        {
            //Values of atributes are set just when the instance is done if not needed before.
            isCarryingPassengers = false;
            SetSpeed(45.0f);
        }

        public void SetCity(City? c)
        {
            city = c;

            if (c == null)
            {
                Console.WriteLine(WriteMessage("unregistered from any city."));
            }
            else
            {
                Console.WriteLine(WriteMessage($"registered in {c.GetName()}."));
            }
        }

        public void StartRide()
        {
            if (!isCarryingPassengers)
            {
                isCarryingPassengers = true;
                SetSpeed(100.0f);
                Console.WriteLine(WriteMessage("starts a ride."));
            }
            else
            {
                Console.WriteLine(WriteMessage("is already in a ride."));
            }
        }

        public void StopRide()
        {
            if (isCarryingPassengers)
            {
                isCarryingPassengers = false;
                SetSpeed(45.0f);
                Console.WriteLine(WriteMessage("finishes ride."));
            }
            else
            {
                Console.WriteLine(WriteMessage("is not on a ride."));
            }
        }
    }
}