﻿using System.Net;

namespace Discoteque.Domain.Dto
{
    public class EntityMessage<TEntity>
    {
        public string Message { get; set; } = "";
        public HttpStatusCode StatusCode { get; set; }
        public int TotalElements { get; set; } = 0;
        public List<TEntity> Elements { get; set; } = new List<TEntity>();
    }
    public static class EntityMessageStatus
    {
        public const string OK_200 = "200 OK";
        public const string BAD_REQUEST_400 = "400 Bad Request";
        public const string INTERNAL_SERVER_ERROR_500 = "500 Internal Server Error";
        public const string NOT_FOUND_404 = "404 Not Found";
        public const string ALBUM_NOT_FOUND = "404 Album Not Found";
        public const string ARTIST_NOT_FOUND = "404 Artist Not Found";
    }
}
