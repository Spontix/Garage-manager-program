using System;
using System.Collections.Generic;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public class Garage 
    {
        // $G$ CSS-025 (-3) Symbols are not spaced properly.
        private readonly Dictionary<string,VehicleInGarage>r_AllVehiclesInGarage;

        public Garage()
        {
            r_AllVehiclesInGarage = new Dictionary<string, VehicleInGarage>();
        }

        public Dictionary<string, VehicleInGarage> AllVehiclesInGarage
        {
            get
            {
                return r_AllVehiclesInGarage;
            }
        }

        public bool AddCarToGarage(string i_LicensePlateNumber, VehicleInGarage i_newVehicleToAdd)
        { 
            bool isVehicleInGarage =false;

            if(r_AllVehiclesInGarage.ContainsKey(i_LicensePlateNumber))
            {
                i_newVehicleToAdd.VehicleStatus = eStateInGarage.inReplacement;
                isVehicleInGarage = true;
            }
            else
            {
                r_AllVehiclesInGarage.Add(i_LicensePlateNumber, i_newVehicleToAdd);
            }

            return isVehicleInGarage;
        }

        public List<string> GetListOfVehiclesLicensePlateByStatus(eStateInGarage i_Status)
        {
            List<string> listOfAllVehiclesInState = new List<string> { };
            Dictionary<string, VehicleInGarage>.ValueCollection vehicles = r_AllVehiclesInGarage.Values;

            foreach(VehicleInGarage vehicle in vehicles)
            {
                if(vehicle.VehicleStatus.Equals(i_Status))
                {
                    listOfAllVehiclesInState.Add(vehicle.StoredVehicle.LicensePlate);
                }
            }

            return listOfAllVehiclesInState;
        }

        public List<string> GetAllVehiclesLicensePlate()
        {
            List<string> listOfVehiclesLicensePlate = new List<string> { };

            listOfVehiclesLicensePlate.AddRange(GetListOfVehiclesLicensePlateByStatus(eStateInGarage.Complete));
            listOfVehiclesLicensePlate.AddRange(GetListOfVehiclesLicensePlateByStatus(eStateInGarage.inReplacement));
            listOfVehiclesLicensePlate.AddRange(GetListOfVehiclesLicensePlateByStatus(eStateInGarage.Paid));

            return listOfVehiclesLicensePlate;
        }

        public void UpdateVehiclesState(string i_LicensePlateNumber, StateInGarage i_NewState)
        {
            VehicleInGarage vehicleToUpdateStatus;

            if(!r_AllVehiclesInGarage.TryGetValue(i_LicensePlateNumber, out vehicleToUpdateStatus))
            {
                throw new ArgumentException("Unfortunately the current vehicle is not found in the garage system.");
            }

            vehicleToUpdateStatus.VehicleStatus = i_NewState.CurrentState;
        }

        public void FillAirToMaximum(string i_LicensePlate)
        {
            VehicleInGarage vehicleToUpdate;

            if(!r_AllVehiclesInGarage.TryGetValue(i_LicensePlate, out vehicleToUpdate))
            {
                throw new FormatException("Can't find vehicle. Please insert a valid license plate.");
            }

            foreach ( Wheel wheel in vehicleToUpdate.StoredVehicle.WheelsList)
            {
                wheel.fillAir((float)wheel.MaxAirPressure);
            }
        }

        public void FillTank(string i_LicensePlate, FuelType i_FuelType, float i_Amount)
        {
            VehicleInGarage vehicleTofill;

            if(!r_AllVehiclesInGarage.TryGetValue(i_LicensePlate, out vehicleTofill))
            {
                throw new FormatException("Can't find vehicle. Please insert a valid license plate.");
            }

            if (vehicleTofill.StoredVehicle.FuelType != i_FuelType.m_TankFuel)
            {
                throw new ArgumentException("Wrong input. Please fill you tank using " + vehicleTofill.StoredVehicle.FuelType);
            }

            vehicleTofill.StoredVehicle.FillTank(i_Amount);
        }

        public void ChargeElectricVehicle(string i_licensePlateNumber, float i_timeToChargeBattery)
        {
            FuelType fuel = new FuelType();

            fuel.m_TankFuel = eFuelType.Electricity;
            FillTank(i_licensePlateNumber, fuel, i_timeToChargeBattery);
        }

        public string ShowDetailsOfVehicle(string i_LicensePlateNumber)
        {
            VehicleInGarage requiredVehicle;

            if(!r_AllVehiclesInGarage.TryGetValue(i_LicensePlateNumber, out requiredVehicle))
            {
                throw new ArgumentException("Vehicle not found!");
            }

            return requiredVehicle.ToString();
        }
    }
}
