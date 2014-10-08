import pygame
pygame.init()

window = pygame.display.set_mode((500,500))

background = pygame.Surface(window.get_size())
background = background.convert()
background.fill((255,255,255))

window.blit(background, (0,0))

pygame.draw.polygon(window, (255,0,0), [(100,100),(100,150), (150,175), (150,125)])

pygame.display.update()

while True:
  pass
