import cs1graphics as cs1

class Cube(cs1.Drawable):

  def __init__(self, center, scale, color=None):
    cs1.Drawable.__init__(self)
    self._leftFace = cs1.Polygon([cs1.Point(0,0),cs1.Point(0,1),cs1.Point(1,1.65),cs1.Point(1,0.65)])
    self._leftFace.moveTo(center.getX(), center.getY())
    self._leftFace.scale(scale)
    self._leftFace.setFillColor('red')

    self._rightFace = cs1.Polygon()
    self._topFace = cs1.Polygon()

  def _draw(self):
    self._leftFace._draw()
    self._rightFace._draw()
    self._topFace._draw()


if __name__ == '__main__':
  canvas = cs1.Canvas(400,400)
  c = Cube(cs1.Point(30,30), 30)
  canvas.add(c)
