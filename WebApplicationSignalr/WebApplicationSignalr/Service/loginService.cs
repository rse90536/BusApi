using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using WebApplicationSignalr.Models;

namespace WebApplicationSignalr.App_Start.Service
{
    public class loginService
    {
        rse90536Entities busdriverEntities = new rse90536Entities();
        private readonly IUnitOfWork UnitOfWork;

        #region 帳號搜尋
        public member getmem(string account)
        {
            return busdriverEntities.member.FirstOrDefault(d => d.account == account);
        }

        #endregion
        #region 車號搜尋
        public member getbusnum(int busnum)
        {
            return busdriverEntities.member.FirstOrDefault(d => d.busnumbr == busnum);
        }
        #endregion
        #region 密碼搜尋
        public bool getpw(member CheckMem, string password)
        {
            bool result = (CheckMem.password == password);
            return result;
        }
        #endregion
        #region 登入
        public string loginCheck(string Account, string password/*,int Busnum*/)
        {
            member loginMember = getmem(Account);
            //member loginMemberNum = getbusnum(Busnum);

            if (loginMember != null && loginMember.account == Account)
            {
                //if (loginMemberNum !=null &&loginMemberNum.busnumbr==Busnum) {
                if (getpw(loginMember, password) == true)
                {
                    return "";
                }
                else
                {
                    return "wrong password";
                }

                //}
                //else
                //{
                //    return "wrong busnum";
                //}
            }
            else
            {
                return "wrong account";
            }

        }
        #endregion
        #region 取得角色
        public string getmemRole(string Account)
        {
            member loginmember = getmem(Account);
            string Role = "User";
            //if(loginmember.character == 1)
            //{
            //    Role += ",Admin";
            //}
            return Role;
        }
        #endregion
        #region 取得ticket
        public string GetEnTicket(string Account)
        {
            string RoleData = getmemRole(Account);
            FormsAuthenticationTicket Ticket = new FormsAuthenticationTicket(
                1,
                Account,
                DateTime.Now,
                DateTime.Now.AddYears(30),
                false,
                RoleData,
                FormsAuthentication.FormsCookiePath);
            string enTicket = FormsAuthentication.Encrypt(Ticket);
            return enTicket;
        }

        #endregion
    

    }
}