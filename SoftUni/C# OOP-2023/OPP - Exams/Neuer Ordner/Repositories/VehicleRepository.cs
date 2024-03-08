using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories
{
    public class VehicleRepository : IRepository<IVehicle>
    {
        private List<IVehicle> vehicle;

        public VehicleRepository()
        {
            vehicle = new List<IVehicle>();
        }
        public void AddModel(IVehicle model) => vehicle.Add(model);

        public IVehicle FindById(string identifier) => vehicle.FirstOrDefault(v => v.LicensePlateNumber == identifier);

        public IReadOnlyCollection<IVehicle> GetAll() => vehicle;

        public bool RemoveById(string identifier) => vehicle.Remove(this.FindById(identifier));
    }
}
