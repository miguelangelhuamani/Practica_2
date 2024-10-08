﻿using System;
using System.Diagnostics.Metrics;
using static System.Collections.Specialized.BitVector32;

namespace Practica_2
{
    class PoliceCar : RegisteredVehicle
    {
        //constant string as TypeOfVehicle wont change allong PoliceCar instances
        private bool isPatrolling;
        private PoliceStation? policeStation;
        private SpeedRadar? speedRadar;
        private string? infractor_plate;
        private bool chasing;


        public PoliceCar(string plate) : base("Police Car", plate)
        {
            isPatrolling = false;
            chasing = false;
            infractor_plate = null;
        }

        public void SetRadar(SpeedRadar radar)
        {
            speedRadar = radar;
            Console.WriteLine(WriteMessage($"has implemented a radar"));

        }

        public void UseRadar(Vehicle vehicle)

        {
            if (!isPatrolling)
            {
                Console.WriteLine(WriteMessage("is not patrolling"));
            }

            else if (speedRadar == null)
            {
                Console.WriteLine(WriteMessage("has no radar assigned"));
            }

            else
            {
                speedRadar.TriggerRadar(vehicle);
                string measurement = speedRadar.GetLastReading();
                Console.WriteLine(WriteMessage($"Triggered radar. Result: {measurement}"));

                if (vehicle.GetSpeed() > speedRadar.legalSpeed)
                {
                    // Verificamos si la estación de policía ha sido asignada
                    if (policeStation != null)
                    {
                        policeStation.ActivateAlert(vehicle.GetPlate());
                    }
                    else
                    {
                        Console.WriteLine(WriteMessage("has no police station assigned."));
                    }

                }
            }
        }


        public void SetStation(PoliceStation p)
        {
            policeStation = p;
        }

        public void SetInfractorPlate(string inf_plate)
        {
            Console.WriteLine(WriteMessage($"has received the alert for vehicle with plate {inf_plate}"));
            infractor_plate = inf_plate;
            SetChasing();
        }

        public string GetInfractorPlate()
        {
            return infractor_plate ?? "No infractor plate registered";
        }


        public void SetChasing()
        {
            chasing = true;
            Console.WriteLine(WriteMessage($"is chasing vehicle with plate: {infractor_plate}"));
        }


        public bool IsPatrolling()
        {
            return isPatrolling;
        }

        public void StartPatrolling()
        {
            if (!isPatrolling)
            {
                isPatrolling = true;
                Console.WriteLine(WriteMessage("started patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("is already patrolling."));
            }
        }

        public void EndPatrolling()
        {
            if (isPatrolling)
            {
                isPatrolling = false;
                Console.WriteLine(WriteMessage("stopped patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("was not patrolling."));
            }
        }

        public void PrintRadarHistory()
        {
            if (speedRadar == null)
            {
                Console.WriteLine(WriteMessage("has no radar assigned. Cannot print speed history."));
                return;
            }

            Console.WriteLine(WriteMessage("Report radar speed history:"));
            foreach (float speed in speedRadar.SpeedHistory)
            {
                Console.WriteLine($"{speed} km/h");
            }
        }



    }
}