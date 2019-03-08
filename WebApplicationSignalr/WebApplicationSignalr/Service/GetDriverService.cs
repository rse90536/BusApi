using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationSignalr.Models;

namespace WebApplicationSignalr.App_Start.Service
{
    public class GetDriverService
    {
        rse90536Entities busdriverEntities = new rse90536Entities();
        #region 找車牌
        public int getbn(string account)
        {
            member mem = busdriverEntities.member.FirstOrDefault(d => d.account == account);
            if (mem == null)
                return 0;
            else
                return mem.busnumbr;
        }
        #endregion
        //#region 找路線
        //public member getrd(string account)
        //{
        //    return busdriverEntities.member.FirstOrDefault(d => d.busnumber.Equals(account));
        //}
        //#endregion
        #region 找到對的車牌
        public int findBn(string Account)
        {
            int Busnum = getbn(Account);
            return Busnum;
        }
        #endregion
    }
}