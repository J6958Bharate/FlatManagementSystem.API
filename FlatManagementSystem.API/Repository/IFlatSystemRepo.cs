using FlatManagementSystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlatManagementSystem.API.Repository
{
  public  interface IFlatSystemRepo
    {
        Task<int> AddOwner(Admin owner);

        Task<int> DeleteOwnerDetail(int ownerId);

        Task<int> AddBuilding(Building building);
        Task<Building> UpdateBuilding(Building building, int buildingId);
        Task<int> DeleteBuilding(int buildingId);

        Task<int> AddUser(User user);
        Task<User> UpdateUser(User user, int id);

        Task<IEnumerable<dynamic>> GetUserDetails();

        Task<List<Building>> GetAllBuildings();
        Task<Building> GetBuildingByOwner(int id);
        Task<List<Admin>> GetAllOwners();

        Task<List<Location>> GetAllLocation();

        Task<List<FlatType>> GetFlatTypes();

        Task<Building> GetBuildingById(int id);
    }
}
