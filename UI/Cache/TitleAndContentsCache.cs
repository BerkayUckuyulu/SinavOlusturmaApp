using Business.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using UI.Models;

namespace UI.Cache
{
    public class TitleAndContentsCache : ITitleAndContentsCache
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ITitleService _titleService;

        public TitleAndContentsCache(IMemoryCache memoryCache, ITitleService titleService)
        {
            _memoryCache = memoryCache;
            _titleService = titleService;
        }

        public List<TitleAndContent> TitleCache()
        {

            const string key = "titles";
            
            List<TitleAndContent>? titlesAndContents = null;
            if (_memoryCache.TryGetValue(key, out object list))
            {
                titlesAndContents = (List<TitleAndContent>)list;
                
            }


            else
            {
                
                titlesAndContents = _titleService.GetTitles();
                
                _memoryCache.Set(key, titlesAndContents, new MemoryCacheEntryOptions{
                    AbsoluteExpiration = DateTime.UtcNow.AddMinutes(30),
                    Priority=CacheItemPriority.Normal
                });
                
            }
            return titlesAndContents;

        }


    }

}


