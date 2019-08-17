//DesignModeler JScript, version: ANSYS DesignModeler Release 17.0 (Dec  2 2015, 15:14:07; 17,2015,336,1) SV4
//Created via: "Write Script: Sketch(es) of Active Plane"
// Written to: D:\SimpleModelJS\ConvexHead_Flat_Line_body\ConvexHead_Flat3_Line_body\Flat3_Head5_body15_chamfer_cd0.53662816.js
//         On: 07/01/19, 17:15:02
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
  p.Pt108 = ConstructionPoint(45.00000000, 10.00000000);
  p.Pt114 = ConstructionPoint(5.00000000, 5.00000000);
  p.Ln15 = Line(0.00000000, 0.00000000, -180.00000000, 0.00000000);
  p.Ln16 = Line(-180.00000000, 0.00000000, -180.00000000, 100.00000000);
  p.Ln17 = Line(-180.00000000, 100.00000000, 660.00000000, 100.00000000);
  p.Ln18 = Line(660.00000000, 100.00000000, 660.00000000, 0.00000000);
  p.Ln19 = Line(660.00000000, 0.00000000, 60.00000000, 0.00000000);
  p.Ln20 = Line(60.00000000, 0.00000000, 60.00000000, 10.00000000);
  p.Ln24 = Line(-0.00000000, 5.00000000, 0.00000000, 0.00000000);
  p.Ln43 = Line(-0.00000000, 5.00000000, 4.89938422, 5.00000000);
  p.Ln46 = Line(60.00000000, 10.00000000, 45.10061578, 10.00000000);
  p.Ln49 = Line(44.90016119, 9.98752015, 5.09983881, 5.01247985);
  p.Cr50 = ArcCtrEdge(
              45.10061578, 8.38388348,
              45.10061578, 10.00000000,
              44.90016119, 9.98752015);
  p.Cr50.DeleteCenter();
  p.Cr52 = ArcCtrEdge(
              4.89938422, 6.61611652,
              4.89938422, 5.00000000,
              5.09983881, 5.01247985);
  p.Cr52.DeleteCenter();
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
  dim = HorizontalDim(p.Ln19.Base, 660.00000000, 0.00000000, 
    p.Ln19.End, 60.00000000, 0.00000000, 
    244.61538462, -1.59258944);
  if(dim) dim.Name = "H10";
  dim = HorizontalDim(p.Origin, 0.00000000, 0.00000000, 
    p.Ln20.Base, 60.00000000, 0.00000000, 
    26.72686113, -4.56306538);
  if(dim) dim.Name = "H15";
  dim = HorizontalDim(p.Ln46.Base, 60.00000000, 10.00000000, 
    p.Pt108, 45.00000000, 10.00000000, 
    55.19340282, 11.09884475);
  if(dim) dim.Name = "H21";
  dim = HorizontalDim(p.Ln43.Base, -0.00000000, 5.00000000, 
    p.Pt114, 5.00000000, 5.00000000, 
    3.25119201, 6.08291601);
  if(dim) dim.Name = "H20";
  dim = VerticalDim(p.Ln16.Base, -180.00000000, 0.00000000, 
    p.Ln16.End, -180.00000000, 100.00000000, 
    -181.63342513, 37.86993243);
  if(dim) dim.Name = "V11";
  dim = VerticalDim(p.Ln20.Base, 60.00000000, 0.00000000, 
    p.Ln20.End, 60.00000000, 10.00000000, 
    61.55175387, 6.14859393);
  if(dim) dim.Name = "V13";
  dim = VerticalDim(p.Ln24.Base, -0.00000000, 5.00000000, 
    p.Ln24.End, 0.00000000, 0.00000000, 
    -1.36157420, 2.31027235);
  if(dim) dim.Name = "V18";

  //Constraints
  HorizontalCon(p.Ln15);
  HorizontalCon(p.Ln17);
  HorizontalCon(p.Ln19);
  HorizontalCon(p.Ln43);
  HorizontalCon(p.Ln46);
  VerticalCon(p.Ln16);
  VerticalCon(p.Ln18);
  VerticalCon(p.Ln20);
  VerticalCon(p.Ln24);
  TangentCon(p.Cr50, 45.10061578, 10.00000000, 
                p.Ln46, 57.50000000, 10.00000000);
  TangentCon(p.Cr50, 44.90016119, 9.98752015, 
                p.Ln49, 55.00000000, 7.50000000);
  TangentCon(p.Cr52, 4.89938422, 5.00000000, 
                p.Ln43, 52.50000000, 1.00000000);
  TangentCon(p.Cr52, 5.09983881, 5.01247985, 
                p.Ln49, 55.00000000, 3.50000000);
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
  CoincidentCon(p.Ln18.Base, 660.00000000, 100.00000000, 
                p.Ln17, 53.41300171, 23.39938417);
  CoincidentCon(p.Ln18.End, 660.00000000, 0.00000000, 
                p.XAxis, 53.41300171, 0.00000000);
  CoincidentCon(p.Ln18.Base, 660.00000000, 100.00000000, 
                p.Ln17.End, 660.00000000, 100.00000000);
  CoincidentCon(p.Ln19.Base, 660.00000000, 0.00000000, 
                p.Ln18, 53.41300171, -0.20417813);
  CoincidentCon(p.Ln19.End, 60.00000000, 0.00000000, 
                p.Ln15, 20.49948536, 0.00000000);
  CoincidentCon(p.Ln20.Base, 60.00000000, 0.00000000, 
                p.Ln19.End, 60.00000000, 0.00000000);
  CoincidentCon(p.Ln24.End, 0.00000000, 0.00000000, 
                p.Ln15.Base, 0.00000000, 0.00000000);
  CoincidentCon(p.Ln43.Base, -0.00000000, 5.00000000, 
                p.Ln24.Base, -0.00000000, 5.00000000);
  CoincidentCon(p.Ln46.Base, 60.00000000, 10.00000000, 
                p.Ln20.End, 60.00000000, 10.00000000);
  CoincidentCon(p.Pt108, 45.00000000, 10.00000000, 
                p.Ln46, 55.00000000, 10.00000000);
  CoincidentCon(p.Pt108, 45.00000000, 10.00000000, 
                p.Ln49, 55.00000000, 10.00000000);
  CoincidentCon(p.Ln46.End, 45.10061578, 10.00000000, 
                p.Cr50.Base, 45.10061578, 10.00000000);
  CoincidentCon(p.Ln49.Base, 44.90016119, 9.98752015, 
                p.Cr50.End, 44.90016119, 9.98752015);
  CoincidentCon(p.Pt114, 5.00000000, 5.00000000, 
                p.Ln43, 55.00000000, 1.00000000);
  CoincidentCon(p.Pt114, 5.00000000, 5.00000000, 
                p.Ln49, 55.00000000, 1.00000000);
  CoincidentCon(p.Ln43.End, 4.89938422, 5.00000000, 
                p.Cr52.Base, 4.89938422, 5.00000000);
  CoincidentCon(p.Ln49.End, 5.09983881, 5.01247985, 
                p.Cr52.End, 5.09983881, 5.01247985);
}

p.Plane.EvalDimCons(); //Final evaluate of all dimensions and constraints in plane

return p;
} //End Plane JScript function: planeSketchesOnly

//Call Plane JScript function
var ps1 = planeSketchesOnly (new Object());

//Finish
agb.Regen(); //To insure model validity
//End DM JScript