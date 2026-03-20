// -------------------------------------------------------------------------------------------------
// <copyright file="FAQItemPage.cs" company="Mark Lemuel Genita">
// Copyright (c) Mark Lemuel Genita. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace AlloyTraining.Models.Pages
{
    [ContentType(DisplayName = "FAQ Item", Description = "A data page for a FAQ item (cannot be created by editors).", AvailableInEditMode = false)]
    public class FAQItemPage : PageData
    {
        [Display(Name = "Question", Order = 10)]
        public virtual XhtmlString Question { get; set; }

        [Display(Name = "Answer", Order = 20)]
        public virtual XhtmlString Answer { get; set; }
    }
}
