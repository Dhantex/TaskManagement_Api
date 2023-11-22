using AutoFixture;
using TaskManagement.Domain;
using TaskManagement.Infrastructure.Persistence;

namespace TaskManagement.Application.UniTest.Mocks
{
    public static class MockGenericTaskRepository
    {
        public static void AddDataGenericTaskRepository(TaskManagerDbContext taskManagerDbContext)
        {

            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var genericTask = fixture.CreateMany<GenericTask>().ToList();

            genericTask.Add(fixture.Build<GenericTask>()
                .With(tr => tr.CreatedBy, "System")
                .Create()
            );


            var category = fixture.CreateMany<Category>().ToList();

            category.Add(fixture.Build<Category>()
                .With(tr => tr.CreatedBy, "System")
                .Create()
            );

            var statusType = fixture.CreateMany<StatusType>().ToList();

            statusType.Add(fixture.Build<StatusType>()
                .With(tr => tr.CreatedBy, "System")
                .Create()
            );

            taskManagerDbContext.GenericTasks!.AddRange(genericTask);
            taskManagerDbContext.StatusTypes!.AddRange(statusType);
            taskManagerDbContext.SaveChangesAsync();

            foreach (var task in genericTask)
            {
                var GenericTaskCategory = fixture.Build<GenericTaskCategory>()
                    .With(c => c.GenericTaskId, task.Id)
                    .Create();

                var GenericTaskStatusType = fixture.Build<GenericTaskStatusType>()
                    .With(s => s.GenericTaskId, task.Id)
                    .Create();

                taskManagerDbContext.GenericTaskCategories!.Add(GenericTaskCategory);
                taskManagerDbContext.GenericTaskStatusTypes!.Add(GenericTaskStatusType);
            }


            taskManagerDbContext.GenericTasks!.AddRange(genericTask);
            taskManagerDbContext.SaveChangesAsync();
        }
    }
}
