﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IDamagable
{
    bool TakeDamage(int amount);
    void Die();
}

