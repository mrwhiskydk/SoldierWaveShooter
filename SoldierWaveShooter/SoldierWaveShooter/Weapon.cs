﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoldierWaveShooter
{
    public abstract class Weapon
    {
        protected int ammo;
        protected float firerate;
        protected float projectilespeed;
        protected int damage;
    }
}