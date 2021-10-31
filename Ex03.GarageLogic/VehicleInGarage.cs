using Ex03.GarageLogic.Vehicles;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public class VehicleInGarage
    {

        private readonly Vehicle r_StoredVehicle;
        private readonly VehicleOwner r_Owner;
        private eStateInGarage m_VehicleStatus;

        public VehicleInGarage(Vehicle i_VehicleToStore, VehicleOwner i_VehicleOwner)
        {
            r_StoredVehicle = i_VehicleToStore;
            r_Owner = i_VehicleOwner;
            m_VehicleStatus = eStateInGarage.inReplacement;
        }

        public Vehicle StoredVehicle
        {
            get
            {
                return this.r_StoredVehicle;
            }
        }

        public eStateInGarage VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }
            set
            {
                m_VehicleStatus = value;
            }
        }

        public override string ToString()
        {
            return string.Format(@"Full details of the vehicle owner:
Owner name: {0}
Owner phone: {1}
Status in garage: {2}

Printing full vehicle details:
{3}", this.r_Owner.OwnerName, this.r_Owner.OwnerPhoneNumber, this.VehicleStatus, this.StoredVehicle);
        }
    }
}