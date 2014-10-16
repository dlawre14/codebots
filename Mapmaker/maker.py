print()
print('Welcome to the Codebots Map Generator')
print()
name = input('Enter a map name: ')
print()
dimensions = [0,0]
dimensions[0] = input('Enter the length of the map: ')
print()
dimensions[1] = input('Enter the width of the map: ')
print()
wallheight = input('Enter a heigh for the edge walls (must be > 1): ')
print()
print(name, dimensions, wallheight)

map = ''
for i in range(int(dimensions[0])):
  if i != 0:
    map += '\n'
  for j in range(int(dimensions[1])):
    if i == 0 or j == 0 or j == int(dimensions[1])-1 or i == int(dimensions[0])-1:
      map += '(' + str(wallheight) + ' , red) '
    else:
      map += '(1 , red)'

print(map)

inp = 'blah'
while inp != "":
  inp = input('Enter a map coordiante as x [space] y: ')
  print(inp)
