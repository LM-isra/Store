using System.Security.Claims;
using AutoMapper;
using Cannabis.Api.Dtos;
using Cannabis.Api.Errors;
using Cannabis.Api.Extensions;
using Cannabis.Core.Entities.Identity;
using Cannabis.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cannabis.Api.Controllers;

public class AccountController : BaseApiController
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;

    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService, IMapper mapper)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
        _mapper = mapper;
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<UserDto>> GetCurrentUser()
    {
        var user = await _userManager.FindByEmailFromClaimsPrinciple(User);
        return new UserDto
        {
            Email = user.Email,
            Token = _tokenService.CreateToken(user),
            DisplayName = user.DisplayName
        };
    }

    [HttpGet("emailExists")]
    public async Task<ActionResult<bool>> CheckEmailExistsAsync([FromQuery] string email)
        => await _userManager.FindByEmailAsync(email) != null;
    
    [HttpGet("address")]
    public async Task<ActionResult<AddressDto>> GetUserAddress()
    {
        var user = await  _userManager.FindByUserByClaimsPrincipleWithAddressAsync(User);
        return _mapper.Map<Address, AddressDto>(user.Address);
    }

    [Authorize]
    [HttpPut("address")]
    public async Task<ActionResult<AddressDto>> UpdateUserAddress(AddressDto address)
    {
        var user = await  _userManager.FindByUserByClaimsPrincipleWithAddressAsync(User);
        user.Address = _mapper.Map<AddressDto, Address>(address);
        
        var result = await _userManager.UpdateAsync(user);
        return result.Succeeded 
            ? Ok(_mapper.Map<Address, AddressDto>(user.Address)) 
            : BadRequest("Problem updating the user");
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
        var user = await _userManager.FindByEmailAsync(loginDto.Email);
        if (user == null) return Unauthorized(new ApiResponse(401));

        var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
        if (!result.Succeeded) return Unauthorized(new ApiResponse(401));

        return new UserDto
        {
            Email = user.Email,
            Token = _tokenService.CreateToken(user),
            DisplayName = user.DisplayName
        };
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
        if(CheckEmailExistsAsync(registerDto.Email).Result.Value) 
            return new BadRequestObjectResult(new ApiValidationErrorResponse { Errors = new [] {"Email address is in use"}});

        var user = new AppUser
        {
            DisplayName = registerDto.DisplayName,
            Email = registerDto.Email,
            UserName = registerDto.Email
        };

        var result = await _userManager.CreateAsync(user, registerDto.Password);
        if (!result.Succeeded) return BadRequest(new ApiResponse(400));

        return new UserDto
        {
            DisplayName = user.DisplayName,
            Token = _tokenService.CreateToken(user),
            Email = user.Email,
        };
    }
}