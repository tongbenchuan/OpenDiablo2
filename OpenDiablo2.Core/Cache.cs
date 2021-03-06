﻿/*  OpenDiablo 2 - An open source re-implementation of Diablo 2 in C#
 *  
 *   This program is free software: you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation, either version 3 of the License, or
 *   (at your option) any later version.
 *
 *   This program is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details.
 *
 *   You should have received a copy of the GNU General Public License
 *   along with this program.  If not, see <https://www.gnu.org/licenses/>. 
 */

using System;
using System.Runtime.Caching;
using OpenDiablo2.Common.Interfaces;

namespace OpenDiablo2.Core
{
    public sealed class Cache : ICache
    {
        private readonly static MemoryCache _cache = new MemoryCache("OpenDiablo2.Cache");

        public Cache() { }

        public T AddOrGetExisting<T>(string key, Func<T> valueFactory, CacheItemPolicy cacheItemPolicy = null)
        {
            var newValue = new Lazy<T>(valueFactory);
            var oldValue = _cache.AddOrGetExisting(key, newValue, cacheItemPolicy ?? new CacheItemPolicy()) as Lazy<T>;
            try
            {
                return (oldValue ?? newValue).Value;
            }
            catch
            {
                _cache.Remove(key);
                throw;
            }
        }

        public bool Exists(string key) => _cache.Contains(key);

        public T GetExisting<T>(string key) where T : class, new() => (_cache.Get(key) as Lazy<T>)?.Value;

        public void Add<T>(string key, T value, CacheItemPolicy cacheItemPolicy = null) => _cache.Add(key, value, cacheItemPolicy ?? new CacheItemPolicy());

    }
}
