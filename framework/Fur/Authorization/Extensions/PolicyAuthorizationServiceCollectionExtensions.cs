﻿// -----------------------------------------------------------------------------
// Fur 是 .NET 5 平台下极易入门、极速开发的 Web 应用框架。
// Copyright © 2020 Fur, Baiqian Co.,Ltd.
//
// 框架名称：Fur
// 框架作者：百小僧
// 框架版本：1.0.0-rc2.2020.10.13
// 官方网站：https://chinadot.net
// 源码地址：Gitee：https://gitee.com/monksoul/Fur
// 				    Github：https://github.com/monksoul/Fur
// 开源协议：Apache-2.0（http://www.apache.org/licenses/LICENSE-2.0）
// -----------------------------------------------------------------------------

using Fur.Authorization;
using Fur.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 策略授权服务拓展类
    /// </summary>
    [SkipScan]
    public static class PolicyAuthorizationServiceCollectionExtensions
    {
        /// <summary>
        /// 添加策略授权服务
        /// </summary>
        /// <typeparam name="TAuthorizationHandler">策略授权处理程序</typeparam>
        /// <param name="services">服务集合</param>
        /// <param name="configure">自定义配置</param>
        /// <param name="enableGlobalAuthorize">是否启用全局授权</param>
        /// <returns>服务集合</returns>
        public static IServiceCollection AddPolicyAuthorization<TAuthorizationHandler>(this IServiceCollection services, Action<IServiceCollection> configure = null, bool enableGlobalAuthorize = false)
            where TAuthorizationHandler : class, IAuthorizationHandler
        {
            // 注册授权策略提供器
            services.TryAddSingleton<IAuthorizationPolicyProvider, AuthorizePolicyProvider>();

            // 注册策略授权处理程序
            services.TryAddSingleton<IAuthorizationHandler, TAuthorizationHandler>();

            //启用全局授权
            if (enableGlobalAuthorize)
            {
                services.Configure<MvcOptions>(options =>
                {
                    options.Filters.Add(new AuthorizeFilter());
                });
            }

            configure?.Invoke(services);
            return services;
        }
    }
}