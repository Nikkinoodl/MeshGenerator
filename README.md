#MeshGenerator:
This Windows Forms/VB application generates a 2D mesh of delaunay triangles around objects.

I started this project many years ago as a way to refresh and update my programming skills. I had previously used this type of mesh generation
in Computational Fluid Dynamics programs when I was an engineer at Rolls-Royce, but didn't know anything about how it was done. So, it became a two-fold
exploration of new things.

Visual Basic was an easy way to transition from my previous experience writing short VBA applications, without forcing me to go back to
C or Fortran which I had long-since forgotten. Obviously, it would not otherwise be my first choice for this kind of application.

The project went through many versions as I worked through the problems. This latest iteration uses a five-layer structure,
object oriented code and a limited amount of calculations are done in parallel. I have optimzed the mesh generation as much as possible, and the delaunay triangle
generation is especially compact (although it resists all attempts to do the triangle calculations in parallel). OpenGL is used for drawing the mesh.

Some of the coding remains clunky, but everything runs.
