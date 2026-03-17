// -------------------------------------------------------------------------------------------------
// <copyright file="EmployeePageValidator.cs" company="Mark Lemuel Genita">
// Copyright (c) Mark Lemuel Genita. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------------------------

using AlloyTraining.Models.Pages;
using EPiServer.Validation;

namespace AlloyTraining.Business.Validation;

public class EmployeePageValidator : IValidate<EmployeePage>
{
    public IEnumerable<ValidationError> Validate(EmployeePage instance)
    {
        if (instance.Name.Length < 5)
        {
            yield return new ValidationError
            {
                ErrorMessage = "Name must be at least 5 characters long.",
                Severity = ValidationErrorSeverity.Warning,
            };
        }

        if (instance.Name.Contains("bad"))
        {
            yield return new ValidationError
            {
                ErrorMessage = "You cannot use the word 'bad' in the name.",
                Severity = ValidationErrorSeverity.Error,
            };
        }

        if (instance.HireDate < instance.BirthDate)
        {
            yield return new ValidationError
            {
                ErrorMessage = "Hire date cannot be before birth date.",
                PropertyName = "HireDate",
                Severity = ValidationErrorSeverity.Warning,
                RelatedProperties = new[] { "BirthDate" }
            };
        }
    }
}
