using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Repositories;

namespace Models.Helpers
{
    public static class CreateMapHelper
    {
        public const string BLOCKTYPE_CITY = "City";
        public const string BLOCKTYPE_FOREST = "Forest";
        public const string BLOCKTYPE_ROCKY = "Rocky";

        public enum PathStartPositions { Left = 0, Bottom = 1, Right = 2, Top = 3 }
        public enum Directions { Left = 0, Down = 1, Right = 2, Up = 3 }

        public static Map CreateMap(int nrofblocks)
        {
            Map map = new Map();
            map.Id = -1;
            map.Created = DateTime.Now;
            map.NrOfBlocks = nrofblocks;
            map.MapTileBlocks.AddRange(CreateMapTileBlocks(map));
                
            return map;
        }

        public static List<MapTileBlock> CreateMapTileBlocks(Map map)
        {
            MapTileTypeRepository mttr = new MapTileTypeRepository();
            MapTileBlockTypeRepository mtbtr = new MapTileBlockTypeRepository();
            List<MapTileType> tileTypes = mttr.GetMapTileTypes();
            List<MapTileBlockType> blockTypes = mtbtr.GetBlockTypes();
            List<MapTileBlock> mapTileBlocks = new List<MapTileBlock>();
            
            for(int i = 0; i < map.NrOfBlocks; i++){
                Random r = new Random();

                var blockType = blockTypes[r.Next(0, blockTypes.Count)];
                var block = new MapTileBlock { Id = -1, Map = map, MapId = map.Id, MapTileBlockType = blockType, PositionIndex = i, TypeId = blockType.Id };
                block.MapTiles.AddRange(CreateMapTiles(blockType, tileTypes.Where(tt => tt.BlockTypeId == blockType.Id).ToList(), block));
                mapTileBlocks.Add(block);
            }

            return mapTileBlocks;
        }

        public static List<MapTile> CreateMapTiles(MapTileBlockType mapTileBlockType, List<MapTileType> tileTypes, MapTileBlock mapTileBlock)
        {
            List<MapTile> mapTiles = new List<MapTile>();
            Random r = new Random();

            mapTiles.AddRange(CreatePath(mapTileBlockType, mapTileBlock, tileTypes));

            //switch (mapTileBlockType.Name)
            //{
            //    case BLOCKTYPE_CITY: mapTiles.AddRange(CreateCity()); break;
            //    case BLOCKTYPE_FOREST: mapTiles.AddRange(CreateForest()); break;
            //    case BLOCKTYPE_ROCKY: mapTiles.AddRange(CreateMountains()); break;
            //}

            ////while (mapTiles.Count != 240)
            ////{

            ////}

            //for (int i = 0; i < 20; i++)
            //{
            //    for (int j = 0; j < 12; j++)
            //    {
            //        var tileType = tileTypes[r.Next(0, tileTypes.Count)];
            //        mapTiles.Add(new MapTile { Height = 50, Width = 50, X = i, Y = j, TypeId = tileType.Id, Id = i * j, MapTileType = tileType, MapTileBlock = mapTileBlock, MapTileBlockId = mapTileBlock.Id });
            //    }
            //}

            return mapTiles;
        }

        public static List<MapTile> CreatePath(MapTileBlockType mapTileBlockType, MapTileBlock mapTileBlock, List<MapTileType> tileTypes)
        {
            List<MapTile> path = new List<MapTile>();

            Random r = new Random();
            int start = r.Next(0, 3);
            bool pathIsComplete = false;
            int x = 0;
            int y = 0;
            int tileTypeId = -1;

            switch(mapTileBlockType.Name)
            {
                case BLOCKTYPE_CITY: tileTypeId = 10; break;
                case BLOCKTYPE_FOREST: tileTypeId = 8; break;
                case BLOCKTYPE_ROCKY: tileTypeId = 12; break;
            }

            switch (start)
            {
                case (int)Directions.Left: 
                    x = 0;
                    y = r.Next(0, 11);
                    break;
                case (int)Directions.Down:
                    x = r.Next(0, 19);
                    y = 11;
                    break;
                case (int)Directions.Right:
                    x = 19;
                    y = r.Next(0, 11);
                    break;
                case (int)Directions.Up:
                    x = r.Next(0, 19);
                    y = 0;
                    break;
            }

            MapTile tile = null;
            int lastDirection = start;
            while (!pathIsComplete)
            {
                if (tile == null)
                {
                    tile = new MapTile { Height = 50, Width = 50, X = x, Y = y, TypeId = tileTypeId, Id = x * y, MapTileType = tileTypes.Single(tt => tt.Id == tileTypeId), MapTileBlock = mapTileBlock, MapTileBlockId = mapTileBlock.Id };

                    switch (lastDirection)
                    {
                        case (int)Directions.Left: x++;
                            break;
                        case (int)Directions.Down: y--;
                            break;
                        case (int)Directions.Right: x--;
                            break;
                        case (int)Directions.Up: y++;
                            break;
                    }
                }
                else
                    tile = new MapTile { Height = 50, Width = 50, X = x, Y = y, TypeId = tileTypeId, Id = x * y, MapTileType = tileTypes.Single(tt => tt.Id == tileTypeId), MapTileBlock = mapTileBlock, MapTileBlockId = mapTileBlock.Id };

                path.Add(tile);

                if (x == 19 || (y == 0 || y == 11))
                {
                    pathIsComplete = true;
                    break;
                }

                int nextDirection = -1;
                bool nextDirectionChosen = false;
                int notAllowedDirection = -1;

                switch(lastDirection)
                {
                    case (int)Directions.Left: notAllowedDirection = (int)Directions.Right; break;
                    case (int)Directions.Down: notAllowedDirection = (int)Directions.Up; break;
                    case (int)Directions.Right: notAllowedDirection = (int)Directions.Left; break;
                    case (int)Directions.Up: notAllowedDirection = (int)Directions.Down; break;
                }

                while (!nextDirectionChosen)
                {
                    nextDirection = r.Next(0, 3);
                    int tempX = x;
                    int tempY = y;

                    switch (nextDirection)
                    {
                        case (int)Directions.Right:
                            tempX++;
                            break;
                        case (int)Directions.Left:
                            tempX--;
                            break;
                        case (int)Directions.Up:
                            tempY--;
                            break;
                        case (int)Directions.Down:
                            tempY++;
                            break;
                    }

                    if(nextDirection == notAllowedDirection || path.Any(mt => mt.Y == y && mt.X == x)) continue;

                    break;
                }

                switch (nextDirection)
                {
                    case (int)Directions.Right:
                        x++;
                        break;
                    case (int)Directions.Left:
                        x--;
                        break;
                    case (int)Directions.Up:
                        y--;
                        break;
                    case (int)Directions.Down:
                        y++;
                        break;
                }

                lastDirection = nextDirection;
            }
                    

            return path;
        }

        public static List<MapTile> CreateForest()
        {
            List<MapTile> forest = new List<MapTile>();

            return forest;
        }

        public static List<MapTile> CreateCity()
        {
            List<MapTile> city = new List<MapTile>();

            return city;
        }

        public static List<MapTile> CreateMountains()
        {
            List<MapTile> city = new List<MapTile>();

            return city;
        }

    }

    
}
