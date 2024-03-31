using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BUCustomValidation;

public class FluentValidationValidator : ComponentBase
{
    [CascadingParameter] private EditContext? EditContext { get; set; }

    [Parameter] public Type? ValidatorType { get; set; }

    private IValidator? _validator;
    private ValidationMessageStore _validationMessageStore;

    [Inject] private IServiceProvider _serviceProvider { get; set; }

    public override async Task SetParametersAsync(ParameterView parameters)
    {
        // Keep a reference to the original values so we can check if they have changed
        var previousEditContext = EditContext;
        var previousValidatorType = ValidatorType;

        await base.SetParametersAsync(parameters);

        if (EditContext is null)
            throw new NullReferenceException(
                $"{nameof(FluentValidationValidator)} must be placed within an {nameof(EditForm)}");

        if (ValidatorType is null)
            throw new NullReferenceException($"{nameof(ValidatorType)} must be specified");

        if (!typeof(IValidator).IsAssignableFrom(ValidatorType))
            throw new ArgumentException($"{ValidatorType.Name} must implement {typeof(IValidator).FullName}");

        if (ValidatorType != previousValidatorType)
            ValidatorTypeChanged();

        // If the EditForm.Model changes then we get a new EditContext
        // and need to hook it up
        if (EditContext != previousEditContext)
            EditContextChanged();
    }

    private void ValidatorTypeChanged()
    {
        _validator = (IValidator?) _serviceProvider.GetService(ValidatorType!);
    }

    void EditContextChanged()
    {
        _validationMessageStore = new ValidationMessageStore(EditContext!);
        HookUpEditContextEvents();
    }

    private void HookUpEditContextEvents()
    {
        EditContext!.OnValidationRequested += ValidationRequested;
        EditContext.OnFieldChanged += FieldChanged;
    }

    async void ValidationRequested(object? sender, ValidationRequestedEventArgs args)
    {
        _validationMessageStore.Clear();
        var validationContext = new ValidationContext<object>(EditContext!.Model);
        var result = await _validator!.ValidateAsync(validationContext);
        AddValidationResult(EditContext.Model, result);
    }

    async void FieldChanged(object? sender, FieldChangedEventArgs args)
    {
        var fieldIdentifier = args.FieldIdentifier;
        _validationMessageStore.Clear(fieldIdentifier);

        var propertiesToValidate = new[] { fieldIdentifier.FieldName };
        var fluentValidationContext = new ValidationContext<object>(
            instanceToValidate: fieldIdentifier.Model,
            propertyChain: new FluentValidation.Internal.PropertyChain(),
            validatorSelector: new FluentValidation.Internal.MemberNameValidatorSelector(propertiesToValidate));

        var result = await _validator!.ValidateAsync(fluentValidationContext);

        AddValidationResult(fieldIdentifier.Model, result);
    }

    void AddValidationResult(object model, ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors)
        {
            var fieldIdentifier = new FieldIdentifier(model, error.PropertyName);
            _validationMessageStore.Add(fieldIdentifier, error.ErrorMessage);
        }

        EditContext!.NotifyValidationStateChanged();
    }
}
