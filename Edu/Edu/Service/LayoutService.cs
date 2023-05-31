using Edu.DAL;
using Edu.Service.Interface;
using Edu.ViewModels;
using NuGet.Configuration;
using System.Collections.Generic;

namespace Edu.Service
{
    public class LayoutService : ILayoutService
    {
        private readonly AppDbContext _context;
        public LayoutService(AppDbContext context)
        {
            _context = context;
        }
        public LayoutVM GetLayoutProperties()
        {
            Dictionary<string, string> settings = _context.Settings.AsEnumerable().ToDictionary(m => m.Key, m => m.Value);

            LayoutVM layout = new()
            {
                Settings = settings
            };

            return layout;
        }
    }
}
