using AutoMapper;
using Canki.Common.DTOs.User;
using Canki.Common.Models;
using Canki.Model.Entities;
using Canki.Service.Repository.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Canki.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<WebApiResponse<List<UserResponse>>>> GetUsers()
        {
            var userResult = _mapper.Map<List<UserResponse>>(await _userRepository.TableNoTracking.ToListAsync());
            if (userResult.Count>0)
            {
                return new WebApiResponse<List<UserResponse>>(true,"Succes",userResult);
            }
            return new WebApiResponse<List<UserResponse>>(false, "Error");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<UserResponse>>> GetUser(Guid id)
        {
            var userResult = _mapper.Map<UserResponse>(await _userRepository.GetById(id));
            if (userResult!=null)
            {
                return new WebApiResponse<UserResponse>(true, "Succes", userResult);
            }
            return new WebApiResponse<UserResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<UserResponse>>> PostUser(UserRequest request)
        {
            var user = _mapper.Map<User>(request);

            var insertResult = await _userRepository.Add(user);
            if (insertResult != null)
            {
                return new WebApiResponse<UserResponse>(true, "Succes", _mapper.Map<UserResponse>(insertResult));
            }
            return new WebApiResponse<UserResponse>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<UserResponse>>> PutUser(Guid id,UserRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                User entity = await _userRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _userRepository.Update(entity);
                if (updateResult != null)
                {
                    UserResponse rm = _mapper.Map<UserResponse>(updateResult);
                    return new WebApiResponse<UserResponse>(true, "Success", rm);
                }
                return new WebApiResponse<UserResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<UserResponse>>> DeleteUser(Guid id)
        {
            User entity = await _userRepository.GetById(id);
            if (entity != null)
            {
                if (await _userRepository.Remove(entity))
                    return new WebApiResponse<UserResponse>
                        (true, "Success", _mapper.Map<UserResponse>(entity));
                else
                    return new WebApiResponse<UserResponse>(false, "Error");
            }
            return new WebApiResponse<UserResponse>(false, "Error");
        }
        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _userRepository.Activate(id);
            if (result)
                    return new WebApiResponse<bool>(true, "Success",true);

            return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactivate")]
        public async Task<ActionResult<WebApiResponse<List<UserResponse>>>> GetActive()
        {
            var userResult = _mapper.Map<List<UserResponse>>(await _userRepository.GetActive().ToListAsync()); 
            if (userResult.Count>0)
            {
                return new WebApiResponse<List<UserResponse>>(true, "Succes", userResult);
            }
            return new WebApiResponse<List<UserResponse>>(false, "Error");
        }

    }
}
