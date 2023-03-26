#MeshGenerator:
This Windows Forms/VB application generates a 2D mesh of delaunay triangles around objects.

I started this project many years ago to refresh my programming skills (I had previously used CFD mesh generation software
when I was an engineer at Rolls-Royce, but didn't know anything about how it worked).

Visual Basic was an easy way to transition from my previous experience writing short VBA applications, without needing to go back to
C or Fortran which I had long-since forgotten.

The project went through many versions as I worked through the problems. In addition to carrying out delaunay calculations, I had to discover ways to optimize
and refine the mesh as it grew.

This latest iteration uses a five-layer structure, object oriented code and a limited amount of calculations are done in parallel.
I have optimzed the mesh generation as much as possible, and the delaunay triangle
generation is especially compact (although it resists all attempts to do the triangle calculations in parallel).

Drawing the completed mesh proved to be one of the bottlenecks in performance, so OpenGL 1.0 was used for drawing the grid.

Some of the coding remains clunky, but everything runs. Sample grids are show below:

![diamond with grid](https://user-images.githubusercontent.com/17559271/227782854-034e1445-a09c-4cab-87a8-f8fa693086a9.png)
![square with grid](https://user-images.githubusercontent.com/17559271/227782858-920a1e7b-2632-4688-acd1-fc29a559b7f4.png)
![airfoil with grid2](https://user-images.githubusercontent.com/17559271/227782862-24d19678-ff6d-4405-9c86-1467d4cfeb5f.png)
![circle with grid](https://user-images.githubusercontent.com/17559271/227782868-d238138b-b9a3-4802-a2d4-b7d85af12479.png)
