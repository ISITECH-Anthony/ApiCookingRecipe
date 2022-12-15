# API COOKING RECIPE

## Réponses aux questions
[Réponses aux questions QUESTIONS.md](QUESTIONS.md)

## Résumé
L'api CookingRecipe permet à des utilisateurs de créer leurs propre recette de cuisine mais aussi des regarder les recettes de cuisine des autres utilisateurs de la plateforme.
Chaque recette a des étapes qui comportent des instructions et des aliments.
Un utilisateur peut définir la quantité qu'il faut pour chaque élément, par exemple il peut préciser qu'il faut "500 G/gramme de farine".
Un utilisateur peut aussi ajouter un avis sur une recette d'un autre utilisateur.
Pour chaque avis il faut donner une note et un écrire un commentaire.

Par la suite il faudrait rajouter :
- Les types d'aliments (table : food_type)
- Pouvoir mettre des recettes en favoris (table : favorites)
- ...


## À savoir
- L'OpinionController n'est pas terminé
    - Potentiel changement pour les opinions en bdd, potentiellement y passer en table n:n
- DTO
    - Upsert => update && insert (create)

## À faire
- Système d'authentification
    - Token pour les utilisateurs
    - Login
    - Register

- Faire des seeders

- Faire de correct DTO

- Terminer le OpinionController
    - Voir si je ne peux pas le passer en n:n

