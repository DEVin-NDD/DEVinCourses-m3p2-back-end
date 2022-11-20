using NDDTraining.Domain.DTOS;

namespace NDDTraining.Domain.Models;

public class CompletedModule
{
    public virtual int Id { get; set; }
    public int ModuleId { get; set; }
    public int RegistrationId { get; set; }
    public virtual Module Module { get; set; }
    public virtual Registration Registration { get; set; }

    public CompletedModule()
    {

    }

    public CompletedModule(CompletedModuleDTO completedModule)
    {
        Id = completedModule.Id;
        ModuleId = completedModule.ModuleId;
        RegistrationId = completedModule.RegistrationId;
    }
}
