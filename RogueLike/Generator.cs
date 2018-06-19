using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike {
    class Generator {
        Random rnd;

        // Current Level
        private int level;

        public Generator(int level, World myWorld, Random rnd) {
            this.rnd = rnd;
            this.level = level;
        }
    }
}
