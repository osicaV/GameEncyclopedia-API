using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace GameEncyclopedia.IntegrationTests {
    public class MonstersTest {
        [Test]
        public async Task Get_Monsters_ReturnsOk() {
            await using var factory = new WebApplicationFactory<Program>();
            using var client = factory.CreateClient();

            var response = await client.GetAsync("/api/Monsters");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
