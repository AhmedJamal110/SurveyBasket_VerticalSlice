
namespace SurveyBasket_VerticalSlice.Features.Questions.UpdateQuestion;

public class UpdateQuestionEndPoint : BaseController
{
    public UpdateQuestionEndPoint(ControllerParamters controllerParamters) : base(controllerParamters)
    {
    }


    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id , int pollid , [FromBody] UpdateQuestionRequest request)
    {
       var result = await _Sender.Send(new UpdateQuestionComand(pollid , id , request));

        return result.IsSuccess ? Ok(result.Value) : result.ToProblem(StatusCodes.Status404NotFound);
    }

}
