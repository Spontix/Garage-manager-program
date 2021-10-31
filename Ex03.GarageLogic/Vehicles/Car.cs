using System;
using System.Collections.Generic;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Vehicles
{
    internal abstract class Car : Vehicle
    {
        protected CarColor m_ColorOfCar;
        protected NumberOfDoors m_NumOfDoors;

        protected Car(string i_ModuleName, string i_LicensePlateNumber, float i_CurrentAmountInTank
            , CarColor i_CarColor, NumberOfDoors i_NumOfDoor, float[] i_WheelsCurrentPressure, string i_WheelManufacturerName)
            : base(i_ModuleName, i_LicensePlateNumber, i_CurrentAmountInTank)
        {
            m_ColorOfCar = i_CarColor; 
            m_NumOfDoors = i_NumOfDoor;

            m_WheelsList = new Wheel[(int)eNumOfWheels.Car];
            for(int i = 0; i < (int)eNumOfWheels.Car; ++i)
            {
                m_WheelsList[i] = new Wheel((i + 1), i_WheelManufacturerName, i_WheelsCurrentPressure[i], eMaxAirPressure.Car);
            }
        }

        public NumberOfDoors NumOfDoors
        {
            get
            {
                return m_NumOfDoors;
            }
        }

        public CarColor ColorOfCar
        {
            get
            {
                return m_ColorOfCar;
            }
        }

        public override string ToString()
        {
            string printingCar = base.ToString() + string.Format(@"5) Color: {0}
6) Number of doors: {1}
", this.ColorOfCar, this.NumOfDoors);

            return printingCar;
        }

        public new static void GetListOfDataMembers(ref List<string> io_DataMemberList)
        {
            Vehicle.GetListOfDataMembers(ref io_DataMemberList);
            io_DataMemberList.Add(@"Car color :
1. Red
2. Silver
3. White
4. Black");
            io_DataMemberList.Add("Number of doors beteemn 2 and 5:");
            io_DataMemberList.Add("Wheels manufacturer name:");
            for(int i = 1; i <= (int)eNumOfWheels.Car; ++i)
            {
                io_DataMemberList.Add("Current air pressure of wheel number " + i +"is"+":");
            }
        }

        public static void MembersCheck(List<string> i_ListOfVariables, List<Object> i_ListOfAllTheMemberOfTheNeededObjectToCreate,
            int i_IndexToStartFrom)
        {
            CarColor carColor;
            NumberOfDoors numberOfDoors;

            carColor = CarColor.Parse(i_ListOfVariables[i_IndexToStartFrom]);
            i_ListOfAllTheMemberOfTheNeededObjectToCreate.Add(carColor);
            numberOfDoors = NumberOfDoors.Parse(i_ListOfVariables[i_IndexToStartFrom + 1]);
            i_ListOfAllTheMemberOfTheNeededObjectToCreate.Add(numberOfDoors);
        }

    }
}
