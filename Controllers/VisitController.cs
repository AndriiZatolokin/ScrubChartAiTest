using MediatR;
using Microsoft.AspNetCore.Mvc;
using ScrubChartAiTest.Commands;
using ScrubChartAiTest.Models;
using ScrubChartAiTest.Queries;
using ScrubChartAiTest.RequestModel;

namespace ScrubChartAiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VisitController : ControllerBase
    {
        private readonly IMediator mediator;
        public VisitController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Visit>>> GetVistiListAsync()
        {
            var result = await mediator.Send(new GetVisitListQuery());

            return Ok(result);
        }

        [HttpGet("Id")]
        public async Task<ActionResult<Visit>> GetVisitByIdAsync(int id)
        {
            var result = await mediator.Send(new GetVisitByIdQuery() { Id = id });

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("PatientName")]
        public async Task<ActionResult<Visit>> GetVisitByPatientNameAsync(string patientName)
        {
            var result = await mediator.Send(new GetVisitByPatientNameQuery() { PatientName = patientName });

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("Date")]
        public async Task<ActionResult<Visit>> GetVisitByDateAsync(DateTime dateTime)
        {
            var result = await mediator.Send(new GetVisitByDateQuery() { DateTime = dateTime });

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Visit>> UpdateVisitAsync(UpdateVisitRequest visit)
        {
            var result = await mediator.Send(new UpdateVisitCommand(
                visit.Id,
                visit.StartDate,
                visit.EndDate,
                visit.PatientId,
                visit.PatientName,
                visit.DoctorId));

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<int>> AddVisitAsync(AddVisitRequest visit)
        {
            var result = await mediator.Send(new CreateVisitCommand(
                visit.StartDate,
                visit.EndDate,
                visit.PatientId,
                visit.PatientName,
                visit.DoctorId));

            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<int>> DeleteVisitAsync(int Id)
        {
            var result =  await mediator.Send(new DeleteVisitCommand() { Id = Id });

            if (result == 0)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
