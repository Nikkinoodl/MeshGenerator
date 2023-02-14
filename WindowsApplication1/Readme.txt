MeshGenerator
A VB project that generates a 2D mesh of delaunay triangles around objects.

I started this project many years ago as a way to get back up to speed with programming. I chose this particular project because I had come across this type of mesh generation
in Computational Fluid Dynamics programs when I was an engineer, but didn't know anything about how it was done. So, it became a two-fold exploration of new things.

Using Visual Basic was an easy way to transition from the kind of short VBA applications which I had written previously, without forcing me to go back to
C or Fortran which I had long-since forgotten. Obviously, it would not otherwise be anyone's first choice for this kind of application.

The project went through many versions as my experience grew and I took on some of the harder problems. This latest iteration uses a five-layer structure,
object oriented code and a limited amount of calculations are done in parallel. I have optimzed the mesh generation as much as possible, and the delaunay triangle
generation is especially compact (although it resists all attempts to do the calculations in parallel).

OpenGL is used for drawing the mesh.
