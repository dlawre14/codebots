#Testing parser for Codebots Language
#Input should be a .cbs file (Codebots Script)
#Outpu should be a .cbc file (Codebots Compiled)

class Parser:
  
  def __init__(self, infile, outfile):
    self.infile = infile
    self.outfile = outfile
    
  def parse(self):
    '''handles parsing of the file and writes the parse to an output file'''
    output = []
    stream = ''
    with open(infile, 'r') as f:
      for line in f:
          stream += line.rstrip('\n') + ' '
    tokens = stream.split()
    i = 0
    while i < len(tokens):
      if tokens[i] == 'Loop':
        subtokens = []
        loop_times = int(tokens[i+1])
        if tokens[i+2] == '{':
          i += 3
          close_bracket_count = 1
          while close_bracket_count > 0:
            if tokens[i] == '}':
              close_bracket_count -= 1
            if tokens[i] == '{':
              close_bracket_count += 1
            if close_bracket_count > 0:
              subtokens.append(tokens[i])
              i += 1
            if (i > len(tokens)):
              return
          self.loop(loop_times, subtokens, output)
        else:
          print('Syntax error! Missing "{" after Loop declaration')
          return
      elif tokens[i] == 'Forward':
        output.append('FWD')
      elif tokens[i] == 'Backward':
        output.append('BWD')
      elif tokens[i] == 'Left':
        output.append('LFT')
      elif tokens[i] == 'Right':
        output.append('RGT')
      else:
        print('Syntax error! Command ' + tokens[i] + ' is unknown')
      i += 1
    print(output)
    
  def loop(self, count, tokens, output):
    for j in range(count):
      i = 0
      while i < len(tokens):
        if tokens[i] == 'Loop':
          subtokens = []
          loop_times = int(tokens[i+1])
          if tokens[i+2] == '{':
            i += 3
            close_bracket_count = 1
            while close_bracket_count > 0:
              if tokens[i] == '}':
                close_bracket_count -= 1
              if tokens[i] == '{':
                close_bracket_count += 1
              if close_bracket_count > 0:
                subtokens.append(tokens[i])
                i += 1
              if (i > len(tokens)):
                return
            
            self.loop(loop_times, subtokens, output)
          else:
            print('Syntax error! Missing "{" after Loop declaration')
            return
        elif tokens[i] == 'Forward':
          output.append('FWD')
        elif tokens[i] == 'Backward':
          output.append('BWD')
        elif tokens[i] == 'Left':
          output.append('LFT')
        elif tokens[i] == 'Right':
          output.append('RGT')
        else:
          print('Syntax error! Command ' + tokens[i] + ' is unknown')
        i += 1
      
        
if __name__ == '__main__':
    infile = 'test.cbs'
    parser = Parser(infile, 'outfile.cbs')
    parser.parse()