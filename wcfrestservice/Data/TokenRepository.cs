using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epiworx.WcfRestService.Data
{
    public class TokenRepository
    {
        private SecurityEntities DataContext { get; set; }

        public TokenRepository()
        {
            this.DataContext = new SecurityEntities();
        }

        public Token GetToken(string key)
        {
            return this.DataContext.Tokens
                .Where(row => row.Key == key)
                .FirstOrDefault();
        }

        public void UpdateToken(Token token)
        {
            this.DataContext.SaveChanges();
        }

        public void AddToken(Token token)
        {
            this.DataContext.Tokens.AddObject(token);
            this.DataContext.SaveChanges();
        }

        public void DeleteToken(Token token)
        {
            this.DataContext.Tokens.DeleteObject(token);
            this.DataContext.SaveChanges();
        }
    }
}