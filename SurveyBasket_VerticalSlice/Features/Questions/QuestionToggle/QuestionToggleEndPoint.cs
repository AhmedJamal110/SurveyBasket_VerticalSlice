
namespace SurveyBasket_VerticalSlice.Features.Questions.QuestionToggle;

public class QuestionToggleEndPoint : BaseController
{
    public QuestionToggleEndPoint(ControllerParamters controllerParamters) : base(controllerParamters)
    {
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int pollId, int id)
    {
        var result = await _Sender.Send(new QuestionToggleComman(pollId, id));
            
        return result.IsSuccess ? Ok(result) : result.ToProblem(StatusCodes.Status404NotFound);
             
    }
}
