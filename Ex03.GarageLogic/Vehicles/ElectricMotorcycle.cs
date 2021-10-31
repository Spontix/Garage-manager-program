using System;
using System.Collections.Generic;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Vehicles
{
    internal class ElectricMotorcycle : Motorcycle
    {
        public ElectricMotorcycle(string i_ModuleName, string i_LicensePlateNumber, LicenseType i_TypeLicese,
            float i_CurrentValueOfTank, string i_WheelManufactureName, float[] i_WheelsCurrentPressure, int i_EngineVolume  )
            :base(i_ModuleName, i_LicensePlateNumber, i_CurrentValueOfTank, i_TypeLicese, i_EngineVolume, i_WheelsCurrentPressure, i_WheelManufactureName )
        {
            this.m_MaxValueOfTank = MaxAmountOfFuel.Parse(TypeOfVehicle.Parse(eTypeOfVehicle.ElectricMotorcycle));
            this.m_PercentageOfEnergyLeft = this.m_CurrentValueOfTank / this.m_MaxValueOfTank;
            this.m_FuelType = eFuelType.Electricity;
        }

        public override string ToString()
        {
            string          returnedString = "1. Vehicle type: ElectricMotorcycle";

            returnedString += base.ToString() + string.Format(@"7) Time left for engine power: {0}
8) Max engine power:: {1} ", this.CurrentValueOfTank, this.MaxValueOfTank);

            return returnedString;
        }

        public static List<Object> ChangeTypeInElectricMotorcycle(List<string> i_ListOfVariables)
        {
            List<Object>        listOfAllTheMemberOfTheNeededObjectToCreate = new List<object> ();

            listOfAllTheMemberOfTheNeededObjectToCreate = Vehicle.MembersCheck(i_ListOfVariables, eTypeOfVehicle.ElectricMotorcycle);
            Motorcycle.MembersCheck(i_ListOfVariables, listOfAllTheMemberOfTheNeededObjectToCreate, 2);
            Vehicle.AddWheelsAndWheelsManufactureToList(i_ListOfVariables, listOfAllTheMemberOfTheNeededObjectToCreate, (int)eNumOfWheels.Motorcycle,
                 4 ,eMaxAirPressure.Motorcycle);

            return listOfAllTheMemberOfTheNeededObjectToCreate;
        }

    }
}
