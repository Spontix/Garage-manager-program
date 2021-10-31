using System.Collections.Generic;
using System;
using Ex03.GarageLogic.Enums;

// $G$ DSN-999 (-7) fuel car and electric car the same and differ by the engine type

namespace Ex03.GarageLogic.Vehicles
{
    internal class FuelCar : Car
    {
        public FuelCar(string i_ModuleName, string i_LicensePlateNumber, float i_CurrentAmountOfTank,
            CarColor i_CarColor, NumberOfDoors i_NumOfDoors, float[] i_WheelsCurrentPressure, string i_WheelManufacturerName)
            :base(i_ModuleName, i_LicensePlateNumber, i_CurrentAmountOfTank, i_CarColor,
                 i_NumOfDoors, i_WheelsCurrentPressure, i_WheelManufacturerName)
        {
            this.m_MaxValueOfTank = MaxAmountOfFuel.Parse(TypeOfVehicle.Parse(eTypeOfVehicle.FuelCar));
            this.m_PercentageOfEnergyLeft = m_CurrentValueOfTank / m_MaxValueOfTank;
            this.m_FuelType = eFuelType.Octan95;
        }

        public override string ToString() 
        {
            string returnedString = "1. Vehicle type: FuelCar";

            returnedString += base.ToString() + string.Format(@"7. Fuel type: {0}
8. Current amount of fuel: {1}
9. Max amount of fuel: {2}", this.FuelType, this.CurrentValueOfTank, this.MaxValueOfTank);

            return returnedString;
        }

        public static List<Object> ChangeTypeInFuelCar(List<string> i_ListOfVariables)
        {
            List<Object> listOfAllTheMemberOfTheNeededObjectToCreate = null;

            listOfAllTheMemberOfTheNeededObjectToCreate = Vehicle.MembersCheck(i_ListOfVariables, eTypeOfVehicle.FuelCar);
            Car.MembersCheck(i_ListOfVariables, listOfAllTheMemberOfTheNeededObjectToCreate, 2);
            Vehicle.AddWheelsAndWheelsManufactureToList(i_ListOfVariables, listOfAllTheMemberOfTheNeededObjectToCreate, (int)eNumOfWheels.Car,
                4, eMaxAirPressure.Car);

            return listOfAllTheMemberOfTheNeededObjectToCreate;
        }

    }
}
