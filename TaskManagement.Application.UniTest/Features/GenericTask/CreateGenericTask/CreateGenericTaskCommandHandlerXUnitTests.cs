using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using TaskManagement.Application.Features.GenericTasks.Commands.CreateGenericTask;
using TaskManagement.Application.Mappings;
using TaskManagement.Application.Models.GenericTask;
using TaskManagement.Application.UniTest.Mocks;
using TaskManagement.Infrastructure.Repositories;
using Xunit;

namespace TaskManagement.Application.UniTest.Features.GenericTask.CreateGenericTask
{
    public class CreateGenericTaskCommandHandlerXUnitTests
    {

        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<ILogger<CreateGenericTaskCommandHandler>> _logger;

        public CreateGenericTaskCommandHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _logger = new Mock<ILogger<CreateGenericTaskCommandHandler>>();


            MockGenericTaskRepository.AddDataGenericTaskRepository(_unitOfWork.Object.TaskManagerDbContext);
        }

        [Fact]
        public async Task CreateGenericTaskCommand_InputGenericTask_ReturnsEntity()
        {
            var fakeCategoryId = _unitOfWork.Object.TaskManagerDbContext.Categories.FirstOrDefault().Id;
            var fakeStatusTypeId = _unitOfWork.Object.TaskManagerDbContext.StatusTypes!.FirstOrDefault().Id;


            var genericTaskInput = new CreateGenericTaskCommand
            {
                Name = "Task to Test",
                Description = "Descriptions To Test",
                DueDate = DateTime.Now,
                CategoryId = fakeCategoryId,
                StatusTypeId = fakeStatusTypeId
            };


        var handler = new CreateGenericTaskCommandHandler(_unitOfWork.Object, _mapper,_logger.Object);
            var result = await handler.Handle(genericTaskInput, CancellationToken.None);

            result.ShouldBeOfType<GenericTaskDto>();
        }
    }
}
