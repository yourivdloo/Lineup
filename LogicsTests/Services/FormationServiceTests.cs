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

        public async Task CreateService()
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
            await CreateService();
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
            await CreateService();
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
            await CreateService();
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
            await CreateService();
            int teamId = 1;
            int id = 4;

            //Act
            await _formationService.DeleteFormation(id);

            //Assert
            List<Formation> formations = await _formationService.GetAllFormations(teamId);
            Assert.AreEqual(3, formations.Count);
        }

        [TestMethod()]
        public async Task EditFormationTest()
        {
            //Arrange
            await CreateService();
            Formation formation = new Formation()
            {
                Id = 1,
                Name = "Changed",
                TeamId = 1
            };

            //Act
            await _formationService.EditFormation(formation);

            //Assert
            Formation f = await _formationService.GetFormation(formation.Id);
            Assert.AreEqual(formation.Id, f.Id);
            Assert.AreEqual(formation.Name, f.Name);
        }

        [TestMethod()]
        public async Task EditPlayerPositionTest()
        {
            //Arrange
            await CreateService();
            PlayerPosition playerPosition = new PlayerPosition()
            {
                Id = 1,
                FormationId = 1,
                PlayerId = 1,
                Position = Position.Leftwing
            };

            //Act
            await _formationService.EditPlayerPosition(playerPosition);

            //Assert
            PlayerPosition pp = await _formationService.GetPlayerPosition(playerPosition.Id);
            Assert.AreEqual(playerPosition.Id, pp.Id);
            Assert.AreEqual(playerPosition.PlayerId, pp.PlayerId);
            Assert.AreEqual(playerPosition.Position, pp.Position);
        }

        [TestMethod()]
        public async Task GetAllPlayerPositionsTest()
        {
            //Arrange
            await CreateService();
            int formationId = 2;
            List<PlayerPosition> expectedPlayerPositions = new List<PlayerPosition>();
            for (int i = 1; i < 11; i++)
            {
                PlayerPosition pp = new PlayerPosition()
                {
                    FormationId = formationId,
                    PlayerId = i,
                    Id = i + 11,
                    Position = (Position)i
                };
                expectedPlayerPositions.Add(pp);
            }

            //Act
            List<PlayerPosition> playerPositions = await _formationService.GetAllPlayerPositions(formationId);

            //Assert
            Assert.AreEqual(expectedPlayerPositions.Count, playerPositions.Count);
            Assert.AreEqual(expectedPlayerPositions[0].Id, playerPositions[0].Id);
            Assert.AreEqual(expectedPlayerPositions[4].Id, playerPositions[4].Id);
        }

        [TestMethod()]
        public async Task GetPlayerPositionTest()
        {
            //Arrange
            await CreateService();
            int playerPositionId = 6;

            //Act
            PlayerPosition playerPosition = await _formationService.GetPlayerPosition(playerPositionId);

            //Assert
            Assert.AreEqual(6, playerPosition.Id);
            Assert.AreEqual(6, playerPosition.PlayerId);
            Assert.AreEqual(1, playerPosition.FormationId);
        }

        [TestMethod()]
        public async Task GetFormationTest()
        {
            //Arrange
            await CreateService();
            int formationId = 2;

            //Act
            Formation formation = await _formationService.GetFormation(formationId);

            //Assert
            Assert.AreEqual("Test-2", formation.Name);
            Assert.AreEqual(formationId, formation.Id);
        }

        [TestMethod()]
        public async Task CheckFormationTest()
        {
            //Arrange
            await CreateService();
            List<Position> positions = new List<Position>();
            for (int i = 0; i < 11; i++)
            {
                positions.Add(Position.Substitute);
            }

            //Act
            List<string> errors = _formationService.CheckFormation(positions);

            //Assert
            Assert.AreEqual(2, errors.Count);
            Assert.AreEqual("You need exactly 11 field players", errors[0]);
            Assert.AreEqual("You need exactly 1 goalkeeper", errors[1]);
        }

        [TestMethod()]
        public async Task CheckFormationTest1()
        {
            //Arrange
            await CreateService();
            List<Position> positions = new List<Position>();
            for (int i = 0; i < 10; i++)
            {
                positions.Add(Position.Substitute);
            }
            positions.Add(Position.Goalkeeper);

            //Act
            List<string> errors = _formationService.CheckFormation(positions);

            //Assert
            Assert.AreEqual(1, errors.Count);
            Assert.AreEqual("You need exactly 11 field players", errors[0]);
        }

        [TestMethod()]
        public async Task CheckFormationTest2()
        {
            //Arrange
            await CreateService();
            List<Position> positions = new List<Position>();
            for (int i = 0; i < 11; i++)
            {
                positions.Add(Position.Striker);
            }

            //Act
            List<string> errors = _formationService.CheckFormation(positions);

            //Assert
            Assert.AreEqual(1, errors.Count);
            Assert.AreEqual("You need exactly 1 goalkeeper", errors[0]);
        }

        [TestMethod()]
        public async Task CheckFormationTest3()
        {
            //Arrange
            await CreateService();
            List<Position> positions = new List<Position>();
            for (int i = 0; i < 10; i++)
            {
                positions.Add(Position.Striker);
            }
            positions.Add(Position.Goalkeeper);

            //Act
            List<string> errors = _formationService.CheckFormation(positions);

            //Assert
            Assert.AreEqual(0, errors.Count);
        }
    }
}