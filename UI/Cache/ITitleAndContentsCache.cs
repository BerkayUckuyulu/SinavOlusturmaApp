using Entities;
using UI.Models;

namespace UI.Cache
{
    public interface ITitleAndContentsCache
    {
        List<TitleAndContent> TitleCache();
    }
}