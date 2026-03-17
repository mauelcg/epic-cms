// -------------------------------------------------------------------------------------------------
// <copyright file="ContactBlock.cs" company="Mark Lemuel Genita">
// Copyright (c) Mark Lemuel Genita. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace AlloyTraining.Models.Blocks;

[ContentType(DisplayName = "Contact", GUID = "d1c8e5b9-9c3a-4f0b-8c7e-2a1b2c3d4e5f", Description = "A customer contact in the CRM.", GroupName = SiteGroupNames.Customer, Order = 200)]
public class ContactBlock : BlockData
{
    public virtual string FirstName { get; set; }
}
