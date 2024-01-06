using Bonyan.BNB.AspNetCore.Mvc;
using Bonyan.BNB.DDD.Application.Dtos;
using Bonyan.BNB.Identity.Application.Contracts.Users;
using Bonyan.BNB.Identity.Application.Contracts.Users.Dtos;

namespace Bonyan.BNB.Identity.Api.Controllers;


public  class UserController : BnbCrudController<IUserAppService,UserDto,UserDto,Guid,PagedAndSortedResultRequestDto,UserCreateDto,UserUpdateDto>
{
    public UserController(IUserAppService service) : base(service)
    {
    }
}