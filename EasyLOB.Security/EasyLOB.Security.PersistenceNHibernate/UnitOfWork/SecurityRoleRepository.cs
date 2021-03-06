﻿using Microsoft.AspNet.Identity;
using System;
using EasyLOB.Security.Data;
using EasyLOB.Identity;
using EasyLOB.Library;
using EasyLOB.Persistence;

namespace EasyLOB.Security.Persistence
{
    public class SecurityRoleRepository : SecurityGenericRepositoryNH<Role>
    {
        #region Methods

        public SecurityRoleRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override bool Create(ZOperationResult operationResult, Role entity)
        {
            try
            {
                ApplicationRole role = new ApplicationRole { Name = entity.Name };
                IdentityResult identityResult = IdentityHelperNH.RoleManager.Create(role);
                if (!identityResult.Succeeded)
                {
                    operationResult.ParseIdentityResult(identityResult);
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseExceptionNHibernate(exception);
            }

            return operationResult.Ok;
        }

        public override bool Delete(ZOperationResult operationResult, Role entity)
        {
            try
            {
                ApplicationRole role = IdentityHelperNH.RoleManager.FindById(entity.Id);
                if (role != null)
                {
                    IdentityResult identityResult = IdentityHelperNH.RoleManager.Delete(role);
                    if (!identityResult.Succeeded)
                    {
                        operationResult.ParseIdentityResult(identityResult);
                    }
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseExceptionNHibernate(exception);
            }

            return operationResult.Ok;
        }

        public override bool Update(ZOperationResult operationResult, Role entity)
        {
            try
            {
                ApplicationRole role = IdentityHelperNH.RoleManager.FindById(entity.Id);
                role.Name = entity.Name;
                IdentityResult identityResult = IdentityHelperNH.RoleManager.Update(role);
                if (!identityResult.Succeeded)
                {
                    operationResult.ParseIdentityResult(identityResult);
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseExceptionNHibernate(exception);
            }

            return operationResult.Ok;
        }

        #endregion Methods
    }
}