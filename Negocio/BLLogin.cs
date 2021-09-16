using Abstraccion;
using BE;
using Mapper;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Negocio
{
    public class BLLogin : IGestor<BELogin>
    {
        private MPPLogin mPPLogin;

        public BLLogin()
        {
            mPPLogin = new MPPLogin();
        }

        public static string GenerarSHA(string passwd)
        {
            UnicodeEncoding ueCodigo = new UnicodeEncoding();
            byte[] ByteSourceText = ueCodigo.GetBytes(passwd);
            SHA1CryptoServiceProvider SHA = new SHA1CryptoServiceProvider();
            byte[] ByteHash = SHA.ComputeHash(ueCodigo.GetBytes(passwd));
            return Convert.ToBase64String(ByteHash);
        }

        public bool Baja(BELogin Objeto)
        {
            throw new NotImplementedException();
        }

        public bool BajaLogica(BELogin Objeto)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BELogin Objeto)
        {
            throw new NotImplementedException();
        }

        public BELogin ListarObjeto(BELogin bELogin)
        {
            BELogin beLogin = new BELogin();
            bELogin.Passwd = GenerarSHA(bELogin.Passwd);
            beLogin = mPPLogin.ListarObjeto(bELogin);
            if (beLogin != null)
            {
                return beLogin;
            }

            return null;
        }

        public List<BELogin> ListarTodo()
        {
            throw new NotImplementedException();
        }
    }
}