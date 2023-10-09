using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
        

    public class AccountController : Controller
    {



        public AccountController()
    {
     
    }


      
        public IActionResult GoogleLogin()
        {
            var properties = new AuthenticationProperties { 
                RedirectUri = Url.Action("GoogleResponse"), 
                 Items =
                {
                    { "prompt", "select_account" } // Esto fuerza la selección de cuenta de Google
                }
            };

            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }


public async Task<IActionResult> GoogleResponse()
{
    var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);



    var claims = result.Principal.Identities.FirstOrDefault()
                .Claims.Select(claim => new
                {
                    claim.Type,
                    claim.Value
                });

    


        return Ok(claims);


        }
    }



    }
