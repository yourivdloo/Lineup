using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lineup.ViewModels;
using Logics.Entities;
using Logics.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Data.Enums;

namespace Lineup.Controllers
{
    [Authorize]
    public class FormationController : Controller
    {
        private readonly IFormationService _FormationService;
        private readonly IPlayerService _PlayerService;

        public FormationController(IFormationService formationService, IPlayerService playerService)
        {
            _FormationService = formationService;
            _PlayerService = playerService;
        }

        [HttpGet]
        public async Task<IActionResult> AddFormation(int teamId)
        {
            List<Player> players = new List<Player>();
            players = await _PlayerService.GetAllPlayers(teamId);

            //check if the team has at least 11 players
            if (players.Count >= 11)
            {
                List<Position> positions = new List<Position>();
                foreach (Position position in Enum.GetValues(typeof(Position)))
                {
                    positions.Add(position);
                }
                return View(new FormationViewModel { Players = players, Positions = positions, TeamId = teamId });
            }
            return RedirectToAction("Teamhome", "Team", new { id = teamId });
        }

        [HttpPost]
        public async Task<IActionResult> AddFormation(FormationViewModel model)
        {
            List<Player> players = await _PlayerService.GetAllPlayers(model.TeamId);
            model.Players = players;
            model.Positions = GetAllPositions();

            if (ModelState.IsValid)
            {
                List<Position> submittedPositions = new List<Position>();
                foreach (var player in players)
                {
                    Position position = (Position)Enum.Parse(typeof(Position), Request.Form[player.Id.ToString()], true);
                    submittedPositions.Add(position);
                    
                }
                var errors = _FormationService.CheckFormation(submittedPositions);
                //check if there are exactly 11 field players and only 1 keeper
                if (errors.Count == 0)
                {
                        Formation formation = new Formation()
                        {
                            Name = model.Name,
                            TeamId = model.TeamId
                        };
                        int id = await _FormationService.AddFormation(formation);
                        foreach (var player in players)
                        {
                            Position position = (Position)Enum.Parse(typeof(Position), Request.Form[player.Id.ToString()], true);
                            PlayerPosition pp = new PlayerPosition()
                            {
                                PlayerId = player.Id,
                                Position = position,
                                FormationId = id
                            };
                            await _FormationService.AddPlayerPosition(pp);
                        }
                        return RedirectToAction("TeamHome", "Team", new { id = model.TeamId });
                }
                foreach (var error in errors)
                {
                    ModelState.AddModelError("", error);
                }
                
                return View(model);
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Formation(int id)
        {
            List<PlayerPosition> playerPositions = await _FormationService.GetAllPlayerPositions(id);
            Formation formation = await _FormationService.GetFormation(id);
            return View(new FormationViewModel() { Id = id, Name = formation.Name, PlayerPositions = playerPositions, TeamId = formation.TeamId });
        }

        [HttpGet]
        public async Task<IActionResult> DeleteFormation(int id, int teamId)
        {
            await _FormationService.DeleteFormation(id);
            return RedirectToAction("TeamHome", "Team", new { Id = teamId});
        }

        [HttpGet]
        public async Task<IActionResult> EditFormation(int id)
        {
            List<PlayerPosition> playerPositions = await _FormationService.GetAllPlayerPositions(id);
            Formation formation = await _FormationService.GetFormation(id);
            List<Position> positions = new List<Position>();
            foreach (Position position in Enum.GetValues(typeof(Position)))
            {
                positions.Add(position);
            }
            return View(new FormationViewModel() { Id = id, Name = formation.Name, PlayerPositions = playerPositions, Positions = positions, TeamId = formation.TeamId });
        }

        [HttpPost]
        public async Task<IActionResult> EditFormation(FormationViewModel model)
        {
            List<PlayerPosition> playerPositions = await _FormationService.GetAllPlayerPositions(model.Id);
            model.PlayerPositions = playerPositions;
            model.Positions = GetAllPositions();
            if (ModelState.IsValid)
            {
                List<Player> players = await _PlayerService.GetAllPlayers(model.TeamId);
                List<Position> submittedPositions = new List<Position>();
                foreach (var player in players)
                {
                    Position position = (Position)Enum.Parse(typeof(Position), Request.Form[player.Id.ToString()], true);
                    submittedPositions.Add(position);

                }
                var errors = _FormationService.CheckFormation(submittedPositions);

                if (errors.Count == 0)
                {
                    Formation formation = new Formation()
                    {
                        Id = model.Id,
                        TeamId = model.TeamId,
                        Name = model.Name
                    };
                    await _FormationService.EditFormation(formation);

                    foreach (var pp in playerPositions)
                    {
                        Position position = (Position)Enum.Parse(typeof(Position), Request.Form[pp.PlayerId.ToString()], true);
                        PlayerPosition playerPosition = new PlayerPosition()
                        {
                            Id = pp.Id,
                            PlayerId = pp.PlayerId,
                            Position = position,
                            FormationId = model.Id

                        };
                        await _FormationService.EditPlayerPosition(playerPosition);
                    }
                    return RedirectToAction("TeamHome", "Team", new { id = model.TeamId });
                }
                foreach (var error in errors)
                {
                    ModelState.AddModelError("", error);
                }

                return View(model);
            }
            return View(model);
        }

        public List<Position> GetAllPositions()
        {
            List<Position> positions = new List<Position>();
            foreach (Position position in Enum.GetValues(typeof(Position)))
            {
                positions.Add(position);
            }
            return positions;
        }
    }
}
