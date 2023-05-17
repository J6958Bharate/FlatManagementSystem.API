
using FlatManagementSystem.API.Custom_Exception;
using FlatManagementSystem.API.Models;
using FlatManagementSystem.API.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlatManagementSystem.API.Services
{
    public class FlatSystemService : IFlatSystemService
    {

        private readonly IFlatSystemRepo _flatSystemRepo;

        private readonly ILogger _logger;
        public FlatSystemService(IFlatSystemRepo flatSystemRepo, ILogger<FlatSystemService> logger)
        {
            _flatSystemRepo = flatSystemRepo;
            _logger = logger;


        }
        public async Task<int> AddBuilding(Building building)
        {
            try
            {
                if (building.TotalFlatCount == 0)
                {
                    throw new InvalidFlatCountException("Flat count cannot be zero");
                }
                return await _flatSystemRepo.AddBuilding(building);
            }
            catch (Exception ex)
            {

                Exception exception = (ex.InnerException != null) ? ex.InnerException : ex;

                //logging error in console,debug and file
                _logger.LogError(1, exception, "There was an exception in AddBuilding {Time}", DateTime.Now);

                throw new InvalidFlatCountException(ex.Message);
            }
        }

        public async Task<int> AddOwner(Admin owner)
        {
            try
            {
                return await _flatSystemRepo.AddOwner(owner);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<int> AddUser(User user)
        {

            try
            {

                return await _flatSystemRepo.AddUser(user);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<int> DeleteBuilding(int buildingId)
        {

            try
            {
                return await _flatSystemRepo.DeleteBuilding(buildingId);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<int> DeleteOwnerDetail(int ownerId)
        {
            try
            {
                return await _flatSystemRepo.DeleteOwnerDetail(ownerId);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Building>> GetAllBuildings()
        {
            try
            {
                return await _flatSystemRepo.GetAllBuildings();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Location>> GetAllLocation()
        {

            try
            {
                return await _flatSystemRepo.GetAllLocation();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Admin>> GetAllOwners()
        {
            try
            {
                return await _flatSystemRepo.GetAllOwners();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<dynamic>> GetUserDetails()
        {
            try
            {
                return await _flatSystemRepo.GetUserDetails();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<List<FlatType>> GetFlatTypes()
        {
            try
            {
                return await _flatSystemRepo.GetFlatTypes();
            }
            catch (Exception ex)
            {
               
                throw new Exception(ex.Message);
            }
        }

        public async Task<Building> UpdateBuilding(Building building, int buildingId)
        {
            try
            {
                return await _flatSystemRepo.UpdateBuilding(building,buildingId);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<User> UpdateUser(User user, int id)
        {
            try
            {
                return await _flatSystemRepo.UpdateUser(user,id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Building> GetBuildingByOwner(int id)
        {
            try
            {
                return await _flatSystemRepo.GetBuildingByOwner(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Building> GetBuildingById(int id)
        {
            try
            {
                return await _flatSystemRepo.GetBuildingById(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
