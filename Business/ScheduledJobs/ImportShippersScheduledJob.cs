// -------------------------------------------------------------------------------------------------
// <copyright file="ImportShippersScheduledJob.cs" company="Mark Lemuel Genita">
// Copyright (c) Mark Lemuel Genita. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------------------------

using AlloyTraining.Features.NorthwindConnection.Entities;
using AlloyTraining.Models.Pages;
using EPiServer.DataAccess;
using EPiServer.PlugIn;
using EPiServer.Scheduler;
using EPiServer.Security;
using EPiServer.Web;

namespace AlloyTraining.Business.ScheduledJobs;

[ScheduledPlugIn(DisplayName = "Import Shippers", SortIndex = -1)]
public class ImportShippersScheduledJob : ScheduledJobBase
{
    private bool _stopSignaled;
    private readonly NorthwindContext _db;
    private readonly IContentRepository _repo;
    private readonly ISiteDefinitionRepository _siteDefinitionRepo;
    public ImportShippersScheduledJob(NorthwindContext db, IContentRepository repo, ISiteDefinitionRepository siteDefinitionrepo)
    {
        _repo = repo;
        _db = db;
        _siteDefinitionRepo = siteDefinitionrepo;
    }

    public ImportShippersScheduledJob()
    {
        IsStoppable = true;
    }

    public override void Stop() => _stopSignaled = true;

    public override string Execute()
    {
        var site = _siteDefinitionRepo.List().FirstOrDefault();
        if (site == null)
        {
            return "Error: No site definition found.";
        }

        // Provide explicit 'Current' page context to be used by ContentReference.StartPage as background jobs do not have this context
        SiteDefinition.Current = site;

        int shippersImported = 0;
        var startPage = _repo.Get<StartPage>(ContentReference.StartPage);
        var existingShippers = _repo.GetChildren<ShipperPage>(startPage.Shippers);
        var existingIDs = existingShippers.Select(s => s.ShipperID).ToArray();
        var shippers = _db.Shippers.Where(s => !existingIDs.Contains(s.ShipperID));
        foreach (Shipper item in shippers)
        {
            var newshipper = _repo.GetDefault<ShipperPage>(startPage.Shippers);

            newshipper.Name = item.CompanyName;
            newshipper.ShipperID = item.ShipperID;
            newshipper.CompanyName = item.CompanyName;
            newshipper.Phone = item.Phone;
            _repo.Save(newshipper, SaveAction.Publish, AccessLevel.NoAccess);
            shippersImported++;
            if (_stopSignaled)
            {
                return "'Import Shippers' job was stopped.";
            }
        }

        if (shippersImported == 0)
        {
            return "No new shippers to import.";
        }
        else
        {
            return string.Format("Successfully imported {0} shippers.", shippersImported);
        }
    }
}
