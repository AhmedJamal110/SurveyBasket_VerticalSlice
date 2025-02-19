
using System.Security.Claims;

namespace SurveyBasket_VerticalSlice.Features.Questions.GetAvaliableQuestions;

public class GetAvaliableQuestionEndpoint : BaseController
{
    public GetAvaliableQuestionEndpoint(ControllerParamters controllerParamters) : base(controllerParamters)
    {
    }

    [HttpGet]
    public async Task<ActionResult> GetAll(int pollId)
    {

        //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userId = "346b8c46-f7c1-4246-bcea-c418ca0b1139";
        var result = await _Sender.Send(new GetAvaliableQuestionsQuery(pollId, userId));

            if(result.IsSuccess) 
                return Ok(result.Value);

        return result.Error.Equals(VoteErrors.DuplicatedVoted)
                        ? result.ToProblem(StatusCodes.Status409Conflict)
                        : result.ToProblem(StatusCodes.Status404NotFound);

    }   

}
