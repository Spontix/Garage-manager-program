using System;
using System.Collections.Generic;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Vehicles
{
    public abstract class Vehicle
    {
        // $G$ DSN-005 (-5) This property should have been read-only.
        protected string m_ModuleName;
        protected string m_LicensePlate;
        protected float m_PercentageOfEnergyLeft;
        protected Wheel[] m_WheelsList; 
        protected float m_MaxValueOfTank;
        protected float m_CurrentValueOfTank;
        protected eFuelType m_FuelType;

        protected Vehicle(string i_ModuleName, string i_LicensePlateNumber, float i_CurrentAmountOfTank)
        {
            m_ModuleName = i_ModuleName;
            m_LicensePlate = i_LicensePlateNumber;
            m_CurrentValueOfTank = i_CurrentAmountOfTank;
        }

        
        public string LicensePlate
        {
            get
            {
                return this.m_LicensePlate;
            }
        }

        public eFuelType FuelType
        {
            get
            {
                return this.m_FuelType;
            }
        }

        public string ModuleName
        {
            get
            {
                return this.m_ModuleName;
            }
        }

        public float MaxValueOfTank
        {
            get
            {
                return this.m_MaxValueOfTank;
            }
        }


        public Wheel[] WheelsList
        {
            get
            {
                return m_WheelsList;
            }
        }

        public float CurrentValueOfTank
        {
            get
            {
                return this.m_CurrentValueOfTank;
            }

        }

        public void FillTank(float i_AddToTank)
        {

            if(i_AddToTank + m_CurrentValueOfTank > m_MaxValueOfTank)
            {
                throw new ValueOutOfRangeException(m_CurrentValueOfTank, m_MaxValueOfTank, 1);
            }

            m_CurrentValueOfTank += i_AddToTank;
        }

        public override string ToString()
        {
            string wheelString = "";

            foreach(Wheel currentWheel in m_WheelsList)
            {
                wheelString = wheelString + currentWheel.ToString();
            }
            return string.Format(@"
2. License plate: {0}
3. Module name: {1}
4. Wheels details:
************ {2}
************
", this.LicensePlate, this.ModuleName, wheelString);
        }

        // $G$ DSN-999 (-3) Why static? it's not object-oriented.
        internal static void AddWheelsAndWheelsManufactureToList(List<string> i_ListOfVariables,
            List<Object> i_ListOfAllNeededObjectToCreate, int i_NumberOfWheels, int i_IndexToStartFrom,
            eMaxAirPressure i_MaxAirPresure)
        {
            float singleWheelAirPressure;
            float[] wheelsAirPressure = new float[i_NumberOfWheels];

            i_ListOfAllNeededObjectToCreate.Add(i_ListOfVariables[i_IndexToStartFrom]);
            for (int i = i_IndexToStartFrom + 1, j = 0; i < i_NumberOfWheels + i_IndexToStartFrom + 1; ++i, ++j)
            {
                singleWheelAirPressure = float.Parse(i_ListOfVariables[i]);
                if (singleWheelAirPressure > (int)i_MaxAirPresure)
                {
                    throw new ValueOutOfRangeException(singleWheelAirPressure, (int)i_MaxAirPresure, "Air");
                }

                wheelsAirPressure[j] = singleWheelAirPressure;
            }

            i_ListOfAllNeededObjectToCreate.Add(wheelsAirPressure);
        }

        public static List<Object> MembersCheck(List<string> i_ListOfVariables, eTypeOfVehicle i_TypeOfVehicle)
        {
            List<Object>            listOfAllTheMemberOfTheNeededObjectToCreate = new List<object> { };
            string                  moduleName;
            float                   currentValueOfTank;

            moduleName = i_ListOfVariables[0];
            listOfAllTheMemberOfTheNeededObjectToCreate.Add(moduleName);
            currentValueOfTank = float.Parse(i_ListOfVariables[1]);
            listOfAllTheMemberOfTheNeededObjectToCreate.Add(currentValueOfTank);
            if (currentValueOfTank > MaxAmountOfFuel.Parse(TypeOfVehicle.Parse(i_TypeOfVehicle)))
            {
                throw new ValueOutOfRangeException(currentValueOfTank, MaxAmountOfFuel.Parse(
                    TypeOfVehicle.Parse(i_TypeOfVehicle)), "Fuel / Electric power" );
            }

            return listOfAllTheMemberOfTheNeededObjectToCreate;
        }

        public static void GetListOfDataMembers(ref List<string> io_DataMemberList)
        {
            io_DataMemberList.Add("Module Name");
            io_DataMemberList.Add("Current value in tank");
        }

    }
}
