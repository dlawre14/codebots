inputs = input('Enter height width wall_height base_color: ')
file_name = input('Enter name of file: ')
inputs = inputs.split(' ')

print (inputs)

output = ''
for i in range(int(inputs[0])):
  for j in range (int(inputs[1])):
    if (i == 0 or i == int(inputs[0]) - 1 or j == 0 or j == int(inputs[1]) - 1):
      output += '(' + inputs[2] + ' , ' + inputs[3] + ') '
    else:
      output += '(1 , ' + inputs[3] + ') '
  output.rstrip(' ')
  output += '\n'
with open(file_name + '.txt','w') as f:
  f.write(output)
