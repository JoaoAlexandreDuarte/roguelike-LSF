namespace RogueLike {
    class Map {
        public Map() { }

        public void UseMap(World myWorld) {
            for (int row = 0; row < myWorld.Rows; row++) {
                for (int column = 0; column < myWorld.Columns; column++) {
                    myWorld.myTiles[row, column].Explored = true;
                }
            }
        }
    }
}
