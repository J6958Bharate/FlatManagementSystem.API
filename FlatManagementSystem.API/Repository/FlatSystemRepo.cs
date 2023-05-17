using CarServicesApi.CustomExceptions;
using FlatManagementSystem.API.Models;
using FlightBookingSystem.API.CustomException;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlatManagementSystem.API.Repository
{
    public class FlatSystemRepo : IFlatSystemRepo
    {

        private readonly FlatManagementSystemContext _managementSystemContext;
        public FlatSystemRepo(FlatManagementSystemContext managementSystemContext)
        {
            _managementSystemContext = managementSystemContext;
        }

        /// <summary>
        /// Adding data in building table
        /// </summary>
        /// <param name="building"></param>
        /// <returns> Building Id</returns>
        public async Task<int> AddBuilding(Building building)
        {
            var addDetails = await _managementSystemContext.Buildings.AddAsync(building);

            await _managementSystemContext.SaveChangesAsync();

            return building.BuildingId;
        }


        /// <summary>
        /// Adding Details of owner
        /// </summary>
        /// <param name="owner"></param>
        /// <returns>Owner Id</returns>
        public async Task<int> AddOwner(Admin owner)
        {
            var addDetails = await _managementSystemContext.Admins.AddAsync(owner);

            await _managementSystemContext.SaveChangesAsync();

            return owner.OwnerId;
        }

        /// <summary>
        /// Adding User Details
        /// </summary>
        /// <param name="user"></param>
        /// <returns> user id</returns>
        public async Task<int> AddUser(User user)
        {
            var addDetails = await _managementSystemContext.Users.AddAsync(user);

            await _managementSystemContext.SaveChangesAsync();

            return user.UserId;
        }

        /// <summary>
        /// Deleting building details
        /// </summary>
        /// <param name="buildingId"></param>
        /// <returns>Building id which deleted from database</returns>
        public async Task<int> DeleteBuilding(int buildingId)
        {
            var buildingDetails = _managementSystemContext.Buildings.FirstOrDefault(e => e.BuildingId == buildingId);

            if (buildingDetails == null)
            {
                throw new InvalidIdException("entered Id is Invalid");
            }

            _managementSystemContext.Buildings.Remove(buildingDetails);


            await _managementSystemContext.SaveChangesAsync();

            return buildingDetails.BuildingId;
        }

        /// <summary>
        /// Deleting Owner details
        /// </summary>
        /// <param name="ownerId"></param>
        /// <returns>Id of deleted owner</returns>
        public async Task<int> DeleteOwnerDetail(int ownerId)
        {
            var deleteOwnerDetails = _managementSystemContext.Admins.FirstOrDefault(e => e.OwnerId == ownerId);

            if (deleteOwnerDetails == null)
            {
                throw new InvalidIdException("entered Id is Invalid");
            }

            _managementSystemContext.Admins.Remove(deleteOwnerDetails);


            await _managementSystemContext.SaveChangesAsync();

            return deleteOwnerDetails.OwnerId;
        }

        /// <summary>
        /// Get all building details
        /// </summary>
        /// <returns></returns>
        public async Task<List<Building>> GetAllBuildings()
        {
            try
            {
                return await _managementSystemContext.Buildings.ToListAsync();
            }
            catch (SqlException e)
            {
                throw new SqlCustomException("data not found", e);
            }
        }

      
        /// <summary>
        /// Get all owner details
        /// </summary>
        /// <returns></returns>
        public async Task<List<Admin>> GetAllOwners()
        {
            try
            {
                return await _managementSystemContext.Admins.ToListAsync();
            }
            catch (SqlException e)
            {
                throw new SqlCustomException("data not found", e);
            }
        }

        /// <summary>
        /// display User details 
        /// </summary>
        /// <returns>User information</returns>
        public async Task<IEnumerable<dynamic>> GetUserDetails()
        {

            var details = (from f in _managementSystemContext.Users
                           join t in _managementSystemContext.FlatTypes
                            on f.FlatTypeId equals t.FlatTypeId
                           join s in _managementSystemContext.Locations
                           on f.LocationId equals s.LocationId
                           select new
                           {
                               UserId = f.UserId,
                               UserName = f.UserName,
                               Location = f.Location.Name,
                               flatType = f.FlatType.TypeName
                               
                           }


                           ).ToListAsync();

            return await details;
        }
        public async Task<List<Location>> GetAllLocation()
        {
            try
            {
                return await _managementSystemContext.Locations.ToListAsync();
            }
            catch (SqlException e)
            {
                throw new SqlCustomException("data not found", e);
            }
        }

        /// <summary>
        /// Getting flat type
        /// </summary>
        /// <returns></returns>
        public async Task<List<FlatType>> GetFlatTypes()
        {
            try
            {
                return await _managementSystemContext.FlatTypes.ToListAsync();
            }
            catch (SqlException e)
            {
                throw new SqlCustomException("data not found", e);
            }
        }

        /// <summary>
        /// updating details of building
        /// </summary>
        /// <param name="building"></param>
        /// <param name="buildingId"></param>
        /// <returns>Id of updated building</returns>
        public async Task<Building> UpdateBuilding(Building building, int buildingId)
        {
            var checkId = await _managementSystemContext.Buildings.FirstOrDefaultAsync(e => e.BuildingId == buildingId);

            if (checkId == null)
            {
                throw new InvalidIdException("Entered Id is Invalid");
            }

            checkId.Name = building.Name;
            checkId.TotalFlatCount = building.TotalFlatCount;
            checkId.Location = building.Location;
            checkId.OwnerId = building.OwnerId;
            
            

            await _managementSystemContext.SaveChangesAsync();

            return checkId;
        }

        /// <summary>
        /// Updating user details
        /// </summary>
        /// <param name="user"></param>
        /// <param name="id"></param>
        /// <returns>Id of updated user</returns>
        public async Task<User> UpdateUser(User user, int id)
        {
            var checkId = await _managementSystemContext.Users.FirstOrDefaultAsync(e => e.UserId == id);

            if (checkId == null)
            {
                throw new InvalidIdException("Entered Id is Invalid");
            }

            checkId.UserName = user.UserName;
            checkId.FlatTypeId = user.FlatTypeId;
            checkId.LocationId = user.LocationId;
            checkId.OwnerId = user.OwnerId;



            await _managementSystemContext.SaveChangesAsync();

            return checkId;
        }

        /// <summary>
        /// Get Buildings all building of particular owner
        /// </summary>
        /// <param name="id"></param>
        /// <returns>all the building of that owner</returns>
        public async Task<Building> GetBuildingByOwner(int id)
        {
            var buildings = await _managementSystemContext.Buildings.FirstOrDefaultAsync(e => e.OwnerId == id);

            if (buildings == null)
            {
                throw new InvalidIdException("Buildings not available for this Id");
            }

            return buildings;
        }

        public async Task<Building> GetBuildingById(int id)
        {
            var buildings = await _managementSystemContext.Buildings.FirstOrDefaultAsync(e => e.BuildingId == id);

            if (buildings == null)
            {
                throw new InvalidIdException("entered Id is Invalid");
            }

            return buildings;
        }
    }
}
