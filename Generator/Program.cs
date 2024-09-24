﻿using Generator;


Parameter time = new Parameter('t', "Time", "time");
Parameter distance = new Parameter('s', "Distance", "distance");
Parameter startSpeed = new Parameter('u', "Speed", "startSpeed");
Parameter endSpeed = new Parameter('v', "Speed", "endSpeed");
Parameter constSpeed = new Parameter('v', "Speed", "speed");
Parameter acceleration = new Parameter('a', "Acceleration", "acceleration");

FormulaSet tsv = new FormulaSet("v=s/t", "t=s/v", "s=v*t", constSpeed, distance, time);
FormulaSet tsuv = new FormulaSet("s=0.5*(v-u)*t", "t=2*s/(v-u)", "v=u+2*s/t", "u=v-2*s/t", time, distance, startSpeed, endSpeed);
FormulaSet tuva = new FormulaSet("a=(v-u)/t", "v=u+a*t", "u=v-a*t", "t=(v-u)/a", time, startSpeed, endSpeed, acceleration);
FormulaSet suva = new FormulaSet("v=SQRT(POW2(u)+2*a*s)", "u=SQRT(POW2(v)-2*a*s)", "a=(POW2(v)-POW2(u))/(2*s)", "s=(POW2(v)-POW2(u))/(2*a)", distance, startSpeed, endSpeed, acceleration);
FormulaSet tsua = new FormulaSet("s=u*t+0.5*a*POW2(t)", "a=2*(s+u*t)/POW2(t)", "u=s/t-0.5*a*t", "t=(SQRT(2*a*s+POW2(u))-u)/a", startSpeed, acceleration, distance, time);
FormulaSet tsva = new FormulaSet("s=v*t-0.5*a*POW2(t)", "a=UMIN2*(s-v*t)/POW2(t)", "v=s/t+0.5*a*t", "t=(SQRT(UMIN2*a*s+POW2(v))+v)/a", endSpeed, acceleration, distance, time);

TimeGenerator.Generate(tsv, tsuv, tuva, tsua, tsva);
DistanceGenerator.Generate(tsv, tsuv, suva, tsua, tsva);
SpeedGenerator.Generate(tsv, tsuv, tuva, suva, tsua, tsva);
AccelerationGenerator.Generate(tuva, suva, tsua, tsva);
