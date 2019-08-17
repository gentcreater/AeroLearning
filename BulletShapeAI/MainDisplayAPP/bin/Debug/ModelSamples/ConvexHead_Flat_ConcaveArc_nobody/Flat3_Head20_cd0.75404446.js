//DesignModeler JScript, version: ANSYS DesignModeler Release 17.0 (Dec  2 2015, 15:14:07; 17,2015,336,1) SV4
//Created via: "Write Script: Sketch(es) of Active Plane"
// Written to: G:\workbench\SimpleModelJS\ConvexHead_Flat_ConcaveArc_nobody\Flat3_Head20_cd0.75404446.js
//         On: 06/22/19, 19:38:14
//Using:
//  agb ... pointer to batch interface


//Note:
// You may be able to re-use below JScript function via cut-and-paste;
// however, you may have to re-name the function identifier.
//

function planeSketchesOnly (p)
{

//Plane
p.Plane  = agb.GetActivePlane();
p.Origin = p.Plane.GetOrigin();
p.XAxis  = p.Plane.GetXAxis();
p.YAxis  = p.Plane.GetYAxis();

//Sketch
p.Sk2 = p.Plane.NewSketch();
p.Sk2.Name = "Sketch2";

//Edges
with (p.Sk2)
{
  p.Ln15 = Line(0.00000000, 0.00000000, -180.00000000, 0.00000000);
  p.Ln16 = Line(-180.00000000, 0.00000000, -180.00000000, 100.00000000);
  p.Ln17 = Line(-180.00000000, 100.00000000, 659.19470405, 100.00000000);
  p.Ln18 = Line(659.19470405, 100.00000000, 659.19470405, 0.00000000);
  p.Ln19 = Line(659.19470405, 0.00000000, 59.19470405, 0.00000000);
  p.Ln24 = Line(-0.00000000, 3.00000000, 0.00000000, 0.00000000);
  p.Ln43 = Line(-0.00000000, 3.00000000, 20.00000000, 3.00000000);
  p.Ln46 = Line(59.19470405, 0.00000000, 59.19470405, 10.00000000);
  p.Cr47 = ArcCtrEdge(
              20.00000000, 116.23034470,
              20.00000000, 3.00000000,
              59.19470405, 10.00000000);
}

//Dimensions and/or constraints
with (p.Plane)
{
  //Dimensions
  var dim;
  dim = HorizontalDim(p.Ln15.Base, 0.00000000, 0.00000000, 
    p.Ln15.End, -180.00000000, 0.00000000, 
    -119.56521739, -1.59258944);
  if(dim) dim.Name = "H9";
  dim = HorizontalDim(p.Ln19.Base, 659.19470405, 0.00000000, 
    p.Ln19.End, 59.19470405, 0.00000000, 
    243.81008867, -1.59258944);
  if(dim) dim.Name = "H10";
  dim = HorizontalDim(p.Ln43.Base, -0.00000000, 3.00000000, 
    p.Ln43.End, 20.00000000, 3.00000000, 
    13.00476804, 4.08291601);
  if(dim) dim.Name = "H20";
  dim = VerticalDim(p.Ln16.Base, -180.00000000, 0.00000000, 
    p.Ln16.End, -180.00000000, 100.00000000, 
    -181.63342513, 37.86993243);
  if(dim) dim.Name = "V11";
  dim = VerticalDim(p.Ln24.Base, -0.00000000, 3.00000000, 
    p.Ln24.End, 0.00000000, 0.00000000, 
    -1.36157420, 1.38616341);
  if(dim) dim.Name = "V18";
  dim = VerticalDim(p.Ln46.Base, 59.19470405, 0.00000000, 
    p.Ln46.End, 59.19470405, 10.00000000, 
    60.29934626, 5.43476858);
  if(dim) dim.Name = "V21";

  //Constraints
  HorizontalCon(p.Ln15);
  HorizontalCon(p.Ln17);
  HorizontalCon(p.Ln19);
  HorizontalCon(p.Ln43);
  VerticalCon(p.Ln16);
  VerticalCon(p.Ln18);
  VerticalCon(p.Ln24);
  VerticalCon(p.Ln46);
  TangentCon(p.Cr47, 20.00000000, 3.00000000, 
                p.Ln43, 20.00000000, 3.00000000);
  CoincidentCon(p.Ln15.Base, 0.00000000, 0.00000000, 
                p.XAxis, 0.16334251, 0.00000000);
  CoincidentCon(p.Ln15.End, -180.00000000, 0.00000000, 
                p.XAxis, -33.81190016, 0.00000000);
  CoincidentCon(p.Ln15.Base, 0.00000000, 0.00000000, 
                p.Origin, 0.00000000, 0.00000000);
  CoincidentCon(p.Ln16.Base, -180.00000000, 0.00000000, 
                p.Ln15, -33.81190016, 0.00000000);
  CoincidentCon(p.Ln16.Base, -180.00000000, 0.00000000, 
                p.Ln15.End, -180.00000000, 0.00000000);
  CoincidentCon(p.Ln17.Base, -180.00000000, 100.00000000, 
                p.Ln16, -33.81190016, 23.39881404);
  CoincidentCon(p.Ln17.Base, -180.00000000, 100.00000000, 
                p.Ln16.End, -180.00000000, 100.00000000);
  CoincidentCon(p.Ln18.Base, 659.19470405, 100.00000000, 
                p.Ln17, 53.41300171, 23.39938417);
  CoincidentCon(p.Ln18.End, 659.19470405, 0.00000000, 
                p.XAxis, 53.41300171, 0.00000000);
  CoincidentCon(p.Ln18.Base, 659.19470405, 100.00000000, 
                p.Ln17.End, 659.19470405, 100.00000000);
  CoincidentCon(p.Ln19.Base, 659.19470405, 0.00000000, 
                p.Ln18, 53.41300171, -0.20417813);
  CoincidentCon(p.Ln19.End, 59.19470405, 0.00000000, 
                p.Ln15, 20.49948536, 0.00000000);
  CoincidentCon(p.Ln24.End, 0.00000000, 0.00000000, 
                p.Ln15.Base, 0.00000000, 0.00000000);
  CoincidentCon(p.Ln43.Base, -0.00000000, 3.00000000, 
                p.Ln24.Base, -0.00000000, 3.00000000);
  CoincidentCon(p.Ln46.Base, 59.19470405, 0.00000000, 
                p.Ln19.End, 59.19470405, 0.00000000);
  CoincidentCon(p.Cr47.End, 59.19470405, 10.00000000, 
                p.Ln46.End, 59.19470405, 10.00000000);
  CoincidentCon(p.Cr47.Base, 20.00000000, 3.00000000, 
                p.Ln43.End, 20.00000000, 3.00000000);
}

p.Plane.EvalDimCons(); //Final evaluate of all dimensions and constraints in plane

return p;
} //End Plane JScript function: planeSketchesOnly

//Call Plane JScript function
var ps1 = planeSketchesOnly (new Object());

//Finish
agb.Regen(); //To insure model validity
//End DM JScript