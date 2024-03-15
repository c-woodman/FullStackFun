using APIFun.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIFun.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BowlersController : ControllerBase
    {

        private IBowlerRepository _bowlerRepository;
        public BowlersController(IBowlerRepository temp) {
            _bowlerRepository = temp;
        }

        [HttpGet]
        public IEnumerable<Object> Get()
        {
            var joinedData = (from bowler in _bowlerRepository.Bowlers
                              join team in _bowlerRepository.Teams on bowler.TeamID equals team.TeamID
                              where team.TeamName == "Marlins" | team.TeamName == "Sharks" 
                              select new
                              {
                                  BowlerID = bowler.BowlerID,
                                  BowlerFirstName = bowler.BowlerFirstName,
                                  BowlerMiddleInit = bowler.BowlerMiddleInit, 
                                  BowlerLastName = bowler.BowlerLastName,
                                  TeamName = team.TeamName,
                                  BowlerAddress = bowler.BowlerAddress,
                                  BowlerCity = bowler.BowlerCity,
                                  BowlerState = bowler.BowlerState,
                                  BowlerZip = bowler.BowlerZip,
                                  BowlerPhoneNumber = bowler.BowlerPhoneNumber
                              }).ToArray();

            return joinedData;
        }
    }
}
