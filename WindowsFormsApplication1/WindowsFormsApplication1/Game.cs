﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireAndWaterGame
{
    public class Game
    {
        public readonly Level Level; // ? public ?
        public Field Field { get; private set; }

        public Game() : this(0)
        {
        }

        public Game(int levelId) : this(Constants.Levels[levelId])
        {
        }

        public Game(Level level)
        {
            this.Level = level;
            InitializeLevel();
        }

        public void Tick()
        {
            Field.WaterHero.RealiseMoves();
            Field.FireHero.RealiseMoves();
        }

        private void InitializeLevel()
        {
            Field = new Field(Level, this);

        }
    }
}