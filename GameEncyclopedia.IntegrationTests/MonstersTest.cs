using GameEncyclopedia.Dtos;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;

namespace GameEncyclopedia.IntegrationTests {
    public class MonstersTest {
        [Test]
        public async Task Get_Monsters_ReturnsOk_AndJsonArray() {
            await using var factory = new WebApplicationFactory<Program>();
            using var client = factory.CreateClient();

            var response = await client.GetAsync("/api/Monsters");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var monsters = await response.Content.ReadFromJsonAsync<List<MonsterResponse>>();
            Assert.That(monsters, Is.Not.Null);
        }
    }
}
