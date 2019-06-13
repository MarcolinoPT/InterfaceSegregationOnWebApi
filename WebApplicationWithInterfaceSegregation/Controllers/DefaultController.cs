namespace WebApplicationWithInterfaceSegregation.Controllers
{
    using System.Web.Http;
    using WebApplicationWithInterfaceSegregation.Services;
    using Xunit;

    public class DefaultController : ApiController
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        public DefaultController(IReader reader, IWriter writer)
        {
            Assert.True(object.ReferenceEquals(reader, writer));
            this.reader = reader ?? throw new System.ArgumentNullException(nameof(reader));
            this.writer = writer ?? throw new System.ArgumentNullException(nameof(writer));
        }

        // GET: api/Default
        [HttpGet]
        public IHttpActionResult Get()
        {
            return base.Ok(this.reader.GetValues());
        }

        // POST: api/Default
        [HttpPost]
        public IHttpActionResult Post([FromBody]string[] values)
        {
            return base.Created(
                location: "api/Default",
                content: this.writer.WriteValues(values));
        }
    }
}
