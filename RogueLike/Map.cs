namespace RogueLike {
    /// <summary>
    /// Map object
    /// </summary>
    class Map {
        /// <summary>
        /// Construct a new Map
        /// </summary>
        public Map() { }

        /// <summary>
        /// Sets all tiles to Explored
        /// </summary>
        /// <param name="myWorld"></param>
        public void UseMap(World myWorld) {
            for (int row = 0; row < myWorld.Rows; row++) {
                for (int column = 0; column < myWorld.Columns; column++) {
                    myWorld.myTiles[row, column].Explored = true;
                }
            }
        }
    }
}
