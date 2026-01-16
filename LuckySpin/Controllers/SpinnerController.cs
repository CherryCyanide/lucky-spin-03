using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
//DONE: import the LuckySpin.Models namespace into the Controller with a "using" command
using LuckySpin.Models;


namespace LuckySpin.Controllers
{
    public class SpinnerController : Controller
    {
        //DONE: DIJ Part 1: Declare a private Spin field to hold the injected Spin object
        private Spin spin;
        
        //DONE: DIJ Part 2: Update the constructor to accept a Spin object as a parameter (see TODO above well)
        public SpinnerController(Spin newSpin)
        {
            //DONE: DIJ Part 3: Receive an injected Spin object and store it in the private _spin field
            spin = newSpin;

        }
        /***
        * Controller Actions - GET and POST
        * *  Index Action - displays the Player form using the Index View
        * *  Spin Action - displays the Spin View with the results of a Spin
        **/
        [HttpGet] //NOTE:This method is called by the browser's GET request for the URL http://localhost:XXXX/Spinner/Index
        public IActionResult Index()
        {
            //DONE: Set a breakpoint on the following line of code and run the app in Debug mode
            return View();
        }

        [HttpPost] //POST for Index gathers the Player info collected by the form 
        public IActionResult Index(int Luck)
        {
            
            //NOTE: At this point, the _spin object has already been created by DIJ and contains random Numbers
            //.     We only need to use the Player's form data to create a Player object and pass it to the Spin action 
            //DONE: Use the data from the form to create a new Player object assigning the luck value from the form
            Player player = new Player();
            player.Luck = Luck;
            //DONE: Set a breakpoint on the following line of code and run the app in Debug mode
            //DONE: Instead of returning a View, the code below should "RedirectToAction" to the Spin Action
            //      Be sure to pass the Player object to the Spin action
            return RedirectToAction("Spin", player);
        }

        /***
         * Spin Action - receives a Player object and displays the Spin View after adjusting the Spin object
         * to include the Player's Luck value
         **/
        [HttpGet] //NOTE: this method is called by the RedirectToAction method, not a browser request
        //DONE: Adjust the Spin action [GET] to accept a Player object as a parameter
        public IActionResult Spin(Player player)
        {
            //NOTE: At this point, the _spin object has already been created by DIJ and contains random Numbers
            //DONE: Use the the player's luck info to set the _spin object's Luck property appropriately
            spin.Luck = player.Luck;
            //DONE: Set a breakpoint on the following line of code and run the app in Debug mode
            return View(spin); //DONE: Pass the adjusted local _spin object to the Spin View for display
        }
    }
}