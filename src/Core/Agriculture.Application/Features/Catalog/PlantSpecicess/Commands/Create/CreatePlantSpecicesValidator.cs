using FluentValidation;

namespace Agriculture.Application.Features.Catalog.PlantSpecicess.Commands.Create
{
    public class CreatePlantSpecicesValidator
        : AbstractValidator<CreatePlantSpecicesCommand>
    {
        public CreatePlantSpecicesValidator()
        {
            RuleFor(x => x.Body.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");

            RuleFor(x => x.Body.ScientificName)
                .NotEmpty().WithMessage("Scientific name is required.")
                .MaximumLength(100).WithMessage("Scientific name must not exceed 100 characters.");

            RuleFor(x => x.Body.Description)
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.")
                .When(x => !string.IsNullOrEmpty(x.Body.Description));

            RuleFor(x => x.Body.GrowDays)
                .GreaterThan(0).WithMessage("Grow days must be greater than 0.");

            RuleFor(x => x.Body.HarvestDays)
                .GreaterThan(0).WithMessage("Harvest days must be greater than 0.");

            RuleFor(x => x.Body.WaterIntervalHours)
                .GreaterThan(0).WithMessage("Water interval hours must be greater than 0.");

            RuleFor(x => x.Body.SunlightLevel)
                .GreaterThanOrEqualTo(0).WithMessage("Sunlight level must be greater than or equal to 0.");

            RuleFor(x => x.Body.TemperatureMin)
                .LessThanOrEqualTo(x => x.Body.TemperatureMax).WithMessage("Minimum temperature must be less than or equal to maximum temperature.");
                
            RuleFor(x => x.Body.TemperatureMax)
                .GreaterThanOrEqualTo(x => x.Body.TemperatureMin).WithMessage("Maximum temperature must be greater than or equal to minimum temperature.");
        }
    }
}
