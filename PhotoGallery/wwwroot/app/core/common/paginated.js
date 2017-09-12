"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Paginated = /** @class */ (function () {
    function Paginated(page, pagesCount, totalCount) {
        this._page = 0;
        this._pagesCount = 0;
        this._totalCount = 0;
        this._page = page;
        this._pagesCount = pagesCount;
        this._totalCount = totalCount;
    }
    Paginated.prototype.range = function () {
        if (!this._pagesCount) {
            return [];
        }
        var step = 2;
        var doubleStep = step * 2;
        var start = Math.max(0, this._page - step);
        var end = start + 1 + doubleStep;
        if (end > this._pagesCount) {
            end = this._pagesCount;
        }
        var ret = [];
        for (var i = start; i != end; ++i) {
            ret.push(i);
        }
        return ret;
    };
    Paginated.prototype.pagePlus = function (count) {
        return +this.pagePlus + count; // + returns numeric representation
    };
    Paginated.prototype.search = function (i) {
        this._page = i;
    };
    ;
    return Paginated;
}());
exports.Paginated = Paginated;
//# sourceMappingURL=paginated.js.map