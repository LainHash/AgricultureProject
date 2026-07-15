using System;
using System.Collections.Generic;
using System.Text;

namespace Agriculture.Application.Models.Messages
{
    public static class Error<TEntity> where TEntity : class
    {
        public static string NotFound = $"{typeof(TEntity).Name} not found.";

        public static string NotYetDeleted = $"{typeof(TEntity).Name} not yet deleted.";

        public static string AlreadyDeleted = $"{typeof(TEntity).Name} already deleted.";

        public static string AlreadyAdded = $"{typeof(TEntity).Name} already added.";

        public static string OutOfStock = $"{typeof(TEntity).Name} out of stock.";
    }
}
