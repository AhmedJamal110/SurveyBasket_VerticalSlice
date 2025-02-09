using SurveyBasket_VerticalSlice.Features.Polls.IsPollExist;

namespace SurveyBasket_VerticalSlice.Features.Questions.CreateQuestion
{
    public class CreateQuestionHandler : BaseRequestHandler<CreateQuestionCommand, Result<CreateQuestionResponse>>
    {
        private readonly IGenericRepository<Question> _questionRepo;

        public CreateQuestionHandler(RequestParameters parameters , IGenericRepository<Question> questionRepo) : base(parameters)
        {
            _questionRepo = questionRepo;
        }

        public override async Task<Result<CreateQuestionResponse>> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            var isPollExist = await _sender.Send(new IsPollExistQuery(ques => ques.Id == request.PollId));
              if (!isPollExist)
                  return Result.Failure<CreateQuestionResponse>(PollError.PollNotFound);


            var isQuestionExist = await _questionRepo.IsEntityExsit(ques => ques.Content == request.Request.Content && ques.PollId == request.PollId);
                  if(isQuestionExist)
                       return Result.Failure<CreateQuestionResponse>(QuestionError.QuestionlDeplucated);

            var questionInDb = request.Adapt<Question>();
                 questionInDb.PollId = request.PollId;

            //request.Answers.forEach(ans => questionInDb.Answers.Add(new Answer { Content = ans });

            await _questionRepo.AddAsync(questionInDb);

            return Result.Success(questionInDb.Adapt<CreateQuestionResponse>());


        }
    }
}
