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

using Fur.DependencyInjection;
using System.Data;

namespace Fur.DatabaseAccessor
{
    /// <summary>
    /// Sql 语句执行代理
    /// </summary>
    [SkipScan]
    public class SqlSentenceProxyAttribute : SqlProxyAttribute
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sql"></param>
        public SqlSentenceProxyAttribute(string sql)
        {
            Sql = sql;
            CommandType = CommandType.Text;
        }

        /// <summary>
        /// Sql 语句
        /// </summary>
        public string Sql { get; set; }

        /// <summary>
        /// 命令类型
        /// </summary>
        public CommandType CommandType { get; set; }
    }
}