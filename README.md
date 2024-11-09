#MeshGenerator:
This Windows Forms/VB application generates a 2D mesh of delaunay triangles around objects.

I started this project many years ago to refresh my programming skills (I had previously used CFD mesh generation software
while working in the aerospace industry but didn't know anything about how it worked).

Visual Basic was an easy way to transition from my previous experience writing VBA applications without needing to go back to
C or Fortran which I had long-since forgotten.

The project went through many versions as I worked through the problems. In addition to carrying out delaunay calculations, I had to discover ways to optimize
and refine the mesh as it grew.

This latest iteration uses a five-layer structure, object oriented code and a limited amount of calculations are done in parallel.
I have optimzed the mesh generation as much as possible. The delaunay triangle
generation is especially compact although it resists all attempts to do the triangle calculations in parallel.

Drawing the completed mesh proved to be one of the bottlenecks in performance, so OpenGL 1.0 was used for drawing the grid.

Some of the coding remains clunky, but everything runs.
