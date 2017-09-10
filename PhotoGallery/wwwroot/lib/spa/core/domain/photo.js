"use strict";
class Photo {
    constructor(id, title, uri, albumId, albumTitle, dateUploaded) {
        this.Id = id;
        this.Title = title;
        this.Uri = uri;
        this.AlbumId = albumId;
        this.AlbumTitle = albumTitle;
        this.DateUploaded = dateUploaded;
    }
}
exports.Photo = Photo;
