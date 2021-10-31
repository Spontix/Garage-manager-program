using System;
using System.Collections.Generic;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageLogic.Factory
{
    public abstract class VehicleFactory
    {
        public static List<string> GetAllVehicleNames()
        {
            List<string> vehicleNames = new List<string>();

            // $G$ CSS-018 (-3) You should have used enumerations values here.
            vehicleNames.Add("Fuel Motorcycle");
            vehicleNames.Add("Electric Motorcycle");
            vehicleNames.Add("Fuel Car");
            vehicleNames.Add("Electric Car");
            vehicleNames.Add("Truck");

            return vehicleNames;
        }

        public static List<string> ConvertUserChoiceToTypeOfVehicle(TypeOfVehicle i_UserChoiceForVehicle)
        {
            List<string> vehicleDataMembers = new List<string> ();

            switch (i_UserChoiceForVehicle.CarTypeChosen)
            {
                case eTypeOfVehicle.FuelMotorcycle:
                    {
                        FuelMotorcycle.GetListOfDataMembers(ref vehicleDataMembers);
                        break;
                    }
                case eTypeOfVehicle.ElectricMotorcycle:
                    {
                        ElectricMotorcycle.GetListOfDataMembers(ref vehicleDataMembers);
                        break;
                    }
                case eTypeOfVehicle.FuelCar:
                    {
                        FuelCar.GetListOfDataMembers(ref vehicleDataMembers);
                        break;
                    }
                case eTypeOfVehicle.ElectricCar:
                    {
                        ElectricCar.GetListOfDataMembers(ref vehicleDataMembers);
                        break;
                    }
                case eTypeOfVehicle.Truck:
                    {
                        Truck.GetListOfDataMembers(ref vehicleDataMembers);
                        break;
                    }
            }

            return vehicleDataMembers;
        }

        public static VehicleInGarage CreateVehicle(ref VehicleOwner i_Owner, List<string> i_VehicleInformation, TypeOfVehicle i_TypeOfVehicle, string i_LicincePlate)
        {
            List<Object> listOfMembers = null;
            Vehicle theChosenVehicle = null;
            VehicleInGarage vehicleToGarage;

            switch (i_TypeOfVehicle.CarTypeChosen)
            {
                case eTypeOfVehicle.FuelMotorcycle:
                    {
                        listOfMembers = FuelMotorcycle.ChangeTypeInFuelMotorcycle(i_VehicleInformation);
                        theChosenVehicle = new FuelMotorcycle((string)listOfMembers[0], i_LicincePlate, 
                            (LicenseType)listOfMembers[2]  , (float)listOfMembers[1], (string)listOfMembers[4],
                            (float[])listOfMembers[5], (int)listOfMembers[3]);
                        break;
                    }
                case eTypeOfVehicle.ElectricMotorcycle:
                    {
                        listOfMembers = ElectricMotorcycle.ChangeTypeInElectricMotorcycle(i_VehicleInformation);
                        theChosenVehicle = new ElectricMotorcycle((string)listOfMembers[0], i_LicincePlate, 
                            (LicenseType)listOfMembers[2]  , (float)listOfMembers[1], (string)listOfMembers[4],
                            (float[])listOfMembers[5], (int)listOfMembers[3]);
                        break;
                    }
                case eTypeOfVehicle.FuelCar:
                    {
                        listOfMembers = FuelCar.ChangeTypeInFuelCar(i_VehicleInformation);
                        theChosenVehicle = new FuelCar((string)listOfMembers[0], i_LicincePlate,
                            (float)listOfMembers[1], (CarColor)listOfMembers[2], (NumberOfDoors)listOfMembers[3],
                            (float[])listOfMembers[5], (string)listOfMembers[4]);
                        break;
                    }
                case eTypeOfVehicle.ElectricCar:
                    {
                        listOfMembers = ElectricCar.ChangeType(i_VehicleInformation);
                        theChosenVehicle = new FuelCar((string)listOfMembers[0], i_LicincePlate,
                            (float)listOfMembers[1], (CarColor)listOfMembers[2], (NumberOfDoors)listOfMembers[3],
                            (float[])listOfMembers[5], (string)listOfMembers[4]);
                        break;
                    }
                case eTypeOfVehicle.Truck:
                    {
                        listOfMembers = Truck.ChangeTypeInTruck(i_VehicleInformation);
                        theChosenVehicle = new Truck((string)listOfMembers[0], i_LicincePlate,
                            (float)listOfMembers[1], (bool)listOfMembers[2], (float)listOfMembers[3],
                            (float[])listOfMembers[6], (string)listOfMembers[4]);

                        break;
                    }
            }

            vehicleToGarage = new VehicleInGarage(theChosenVehicle, i_Owner);

            return vehicleToGarage;
        }
    }
}