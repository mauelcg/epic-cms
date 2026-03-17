// -------------------------------------------------------------------------------------------------
// <copyright file="EmployeeBlock.cs" company="Mark Lemuel Genita">
// Copyright (c) Mark Lemuel Genita. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace AlloyTraining.Models.Blocks;

[ContentType(DisplayName = "Employee", GUID = "d1e8e5b9-9c3a-4f0b-8c7e-2a1b2c3d4e5f", Description = "An employee info in the CRM.", GroupName = SiteGroupNames.Customer, Order = 200)]
public class EmployeeBlock : BlockData
{
    public virtual string FirstName { get; set; }
    public virtual string LastName { get; set; }
}
