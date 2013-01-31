function Map(canvas, map) {
    this.Canvas = canvas;
    this.Map = map;
    this.MapTileBlocks = this.InitMapTileBlocks();
}

Map.prototype.InitMapTileBlocks = function () {
    var blocks = [];
    
    for (var i = 0; i < this.Map.MapTileBlocks.length; i++)
        blocks.push(new MapTileBlock(this.Map, this.Canvas, this.Map.MapTileBlocks[i]))

    return blocks;
};

function MapTileBlock(map, canvas, mapTileBlock) {
    this.Map = map;
    this.Canvas = canvas;
    this.PositionIndex = mapTileBlock.PositionIndex;
    this.MapTiles = this.InitMapTiles(mapTileBlock.MapTiles);
}

MapTileBlock.prototype.InitMapTiles = function (mapTiles) {
    var tiles = [];
    
    for (var i = 0; i < mapTiles.length; i++){
        var tile = this.Canvas.addChild(this.Canvas.display.rectangle({
            x: (mapTiles[i].X * mapTiles[i].Width),
            y: (mapTiles[i].Y * mapTiles[i].Height),
            width: mapTiles[i].Width,
            height: mapTiles[i].Height,
            fill: mapTiles[i].MapTileType.Background
        }));

        tiles.push(tile);
    }

    return tiles;
};

//function MapTile(map) {
//    this.Map = map;
//    this.PositionIndex = posIndex;
//    this.MapTiles = this.InitMapTiles(mapTiles);
//}