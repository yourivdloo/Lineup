using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logics.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Data.DbContext;
using System.Threading.Tasks;
using Data.Repositories;
using Logics.Entities;
using Data.Enums;
using Data.Dtos;

namespace Logics.Services.Tests
{
    [TestClass()]
    public class FormationServiceTests
    {
        private FormationService _formationService;

        public async Task CreateDatabase()
        {
            var options = new DbContextOptionsBuilder<LineupDbContext>()
                .UseInMemoryDatabase(databaseName: "LineupTestDb")
                .EnableSensitiveDataLogging()
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;

            var dbContext = new LineupDbContext(options);

            if (await dbContext.Formations.CountAsync() <= 0)
            {
                //FORMATION 1
                FormationDto formation1 = new FormationDto()
                {
                    id = 1,
                    Name = "Test-1",
                    TeamId = 1
                };
                dbContext.Formations.Add(formation1);
                for (int i = 1; i < 11; i++)
                {
                    PlayerPositionDto pp = new PlayerPositionDto()
                    {
                        FormationId = formation1.id,
                        PlayerId = i,
                        id = i,
                        position = (Position)i
                    };
                    dbContext.PlayerPositions.Add(pp);
                }

                //FORMATION 2
                FormationDto formation2 = new FormationDto()
                {
                    id = 2,
                    Name = "Test-2",
                    TeamId = 1
                };
                dbContext.Formations.Add(formation2);
                for (int i = 1; i < 11; i++)
                {
                    PlayerPositionDto pp = new PlayerPositionDto()
                    {
                        FormationId = formation2.id,
                        PlayerId = i,
                        id = i + 11,
                        position = (Position)i
                    };
                    dbContext.PlayerPositions.Add(pp);
                }

                //FORMATION 3
                FormationDto formation3 = new FormationDto()
                {
                    id = 3,
                    Name = "Test-3",
                    TeamId = 1
                };
                dbContext.Formations.Add(formation3);
                for (int i = 1; i < 11; i++)
                {
                    PlayerPositionDto pp = new PlayerPositionDto()
                    {
                        FormationId = formation3.id,
                        PlayerId = i,
                        id = i + 22,
                        position = (Position)i
                    };
                    dbContext.PlayerPositions.Add(pp);
                }

                await dbContext.SaveChangesAsync();
            }
            var formationRepository = new FormationRepository(dbContext);
            _formationService = new FormationService(formationRepository);
        }

        [TestMethod()]
        public async Task GetAllFormationsTest()
        {
            //Arrange
            await CreateDatabase();
            int teamId = 1;
            List<Formation> formations = new List<Formation>();

            //Act
            formations = await _formationService.GetAllFormations(teamId);

            //Assert
            Assert.AreEqual(3, formations.Count);
        }

        [TestMethod()]
        public async Task AddFormationTest()
        {
            //Arrange
            await CreateDatabase();
            Formation formation = new Formation()
            {
                Name = "Test-4",
                TeamId = 1,
            };
            Formation f = new Formation();

            //Act
            int id = await _formationService.AddFormation(formation);

            //Assert
            formation.Id = id;
            f = await _formationService.GetFormation(id);
            Assert.AreEqual(f.Id, formation.Id);
            Assert.AreEqual(f.Name, formation.Name);
            Assert.AreEqual(f.TeamId, formation.TeamId);
        }

        [TestMethod()]
        public async Task AddPlayerPositionTest()
        {
            //Arrange
            await CreateDatabase();
            PlayerPosition playerPosition = new PlayerPosition()
            {
                FormationId = 4,
                PlayerId = 1,
                Position = Position.Centreback
            };
            PlayerPosition pp = new PlayerPosition();

            //Act
            int id = await _formationService.AddPlayerPosition(playerPosition);

            //Assert
            playerPosition.Id = id;
            pp = await _formationService.GetPlayerPosition(id);
            Assert.AreEqual(pp.Id, playerPosition.Id);
            Assert.AreEqual(pp.Position, playerPosition.Position);
            Assert.AreEqual(pp.PlayerId, playerPosition.PlayerId);
            Assert.AreEqual(pp.FormationId, playerPosition.FormationId);
        }

        [TestMethod()]
        public async Task DeleteFormationTest()
        {
            //Arrange
            await CreateDatabase();
            int teamId = 1;
            int id = 4;

            //Act
            await _formationService.DeleteFormation(id);

            //Assert
            List<Formation> formations = await _formationService.GetAllFormations(teamId);
            Assert.AreEqual(3, formations.Count);
        }
    }
}