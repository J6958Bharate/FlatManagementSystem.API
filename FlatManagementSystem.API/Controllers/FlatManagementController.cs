using CarServicesApi.CustomExceptions;
using FlatManagementSystem.API.Models;
using FlatManagementSystem.API.Services;
using FlightBookingSystem.API.CustomException;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlatManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlatManagementController : ControllerBase
    {
        private readonly IFlatSystemService _FlatSystemService;
        public FlatManagementController(IFlatSystemService FlatSystemService)
        {
            _FlatSystemService = FlatSystemService;
        }




        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user")]
        [HttpGet]
        [Route("GetAllFlatType")]
        public async Task<ActionResult> GetAllFlatTypes()
        {
            try
            {
                var data = await _FlatSystemService.GetFlatTypes();
                return Ok(data);
            }
            catch (SqlException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception e)
            {
                return BadRequest(new { error = e.Message });
            }
        }
        [HttpGet]
        [Route("GetAllLocations")]
        public async Task<ActionResult> GetAllLocations()
        {
            try
            {
                var data = await _FlatSystemService.GetAllLocation();
                return Ok(data);
            }
            catch (SqlException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception e)
            {
                return BadRequest(new { error = e.Message });
            }
        }

        [HttpPost("AddBuildingDetails")]

        public async Task<ActionResult<int>> AddBuildingDetails(Building building)
        {
            try
            {
                var addBuildingDetails = await _FlatSystemService.AddBuilding(building);
                if (addBuildingDetails > 0)
                {
                    return Created("AddBuilding", new { success = "Data Added successfully" });
                }
                else
                {
                    return BadRequest(new { error = "data not added" });
                }

                
            }
            catch (SqlException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { falied = ex.Message });
            }   
        }

        [HttpPost("AddUserDetails")]

        public async Task<ActionResult<int>> AddUserDetails(User user)
        {
            try
            {
                var addUserDetails = await _FlatSystemService.AddUser(user);
                if (addUserDetails>0)
                {
                    return Created("AddUser", new { success = "Data Added successfully" });
                }
                else
                {
                    return BadRequest(new { error = "data not added" });
                }


            }
            catch (SqlException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { falied = ex.Message });
            }
        }

        [HttpPost("AddOwnerDetails")]

        public async Task<ActionResult<int>> AddOwnerDetails(Admin owner)
        {
            try
            {
                var addOwnerDetails = await _FlatSystemService.AddOwner(owner);
                if (addOwnerDetails > 0)
                {
                    return Created("AddOwner", new { success = "Data Added successfully" });
                }
                else
                {
                    return BadRequest(new { error = "data not added" });
                }

               
            }
            catch (SqlException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { falied = ex.Message });
            }
        }


        [HttpGet]
        [Route("GetAllBuildings")]
        public async Task<ActionResult> GetAllBuildings()
        {
            try
            {
                var data = await _FlatSystemService.GetAllBuildings();
                return Ok(data);
            }
            catch (SqlException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception e)
            {
                return BadRequest(new { error = e.Message });
            }
        }
        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<ActionResult> GetAllUsers()
        {
            try
            {
                var data = await _FlatSystemService.GetUserDetails();
                return Ok(data);
            }
            catch (SqlException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception e)
            {
                return BadRequest(new { error = e.Message });
            }
        }
        [HttpGet]
        [Route("GetAllOwners")]
        public async Task<ActionResult> GetAllOwners()
        {
            try
            {
                var data = await _FlatSystemService.GetAllOwners();
                return Ok(data);
            }
            catch (SqlException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception e)
            {
                return BadRequest(new { error = e.Message });
            }
        }

        [HttpGet("GetBuildingsbyOwner/{id}")]
       
        public async Task<ActionResult<Building>> GetBuildingsbyOwner(int id)
        {
            try
            {
                var checkId = await _FlatSystemService.GetBuildingByOwner(id);

                if (checkId == null)
                {
                    return NotFound();
                }

                return Ok(checkId);
            }
            catch (InvalidIdException ex)
            {
                return BadRequest(new { failed = ex.Message });
            }
            catch (SqlException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { falied = ex.Message });
            }
        }

        [HttpDelete]
        [Route("DeleteBuilding")]
        public async Task<ActionResult> DeleteBuilding(int buildingId)
        {
            try
            {
                int Status = await _FlatSystemService.DeleteBuilding(buildingId);
                if (Status > 0)
                {
                    return Ok(new { sucess = "Data deleted from table" });
                }
                else
                {
                    return BadRequest(new { error = "Error!!Data not deleted from table" });
                }
            }
            catch (SqlCustomException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (SqlException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message }); ;
            }
        }

        [HttpDelete]
        [Route("DeleteOwner")]
        public async Task<ActionResult> DeleteOwner(int ownerId)
        {
            try
            {
                int Status = await _FlatSystemService.DeleteOwnerDetail(ownerId);
                if (Status > 0)
                {
                    return Ok(new { sucess = "Data deleted from table" });
                }
                else
                {
                    return BadRequest(new { error = "Error!!Data not deleted from table" });
                }
            }
            catch (SqlException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message }); ;
            }
        }

        [HttpPut]
        [Route("UpdateBuilding")]
        public async Task<ActionResult> UpdateBuilding([FromBody] Building building, int buildingId)
        {
            try
            {
                var rowAffected = await _FlatSystemService.UpdateBuilding(building, buildingId);
                if (rowAffected !=null)
                {

                    return Created("UpdateBuilding", new { success = "Data updated successfully" });


                }
                else
                {
                    return BadRequest(new { error = "data not updated" });
                }
            }
            catch (SqlException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<ActionResult> UpdateUser([FromBody] User user, int userId)
        {
            try
            {
                var rowAffected = await _FlatSystemService.UpdateUser(user, userId);
                if (rowAffected != null)
                {

                    return Created("UpdateUser", new { success = "Data updated successfully" });


                }
                else
                {
                    return BadRequest(new { error = "data not updated" });
                }
            }
            catch (SqlException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("GetBuildingsbyId/{id}")]
    

        public async Task<ActionResult<Building>> GetBuildingsbyId(int id)
        {
            try
            {
                var checkId = await _FlatSystemService.GetBuildingById(id);

                if (checkId == null)
                {
                    return NotFound();
                }

                return Ok(checkId);
            }
            catch (InvalidIdException ex)
            {
                return BadRequest(new { failed = ex.Message });
            }
            catch (SqlException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { falied = ex.Message });
            }
        }

    }
}
