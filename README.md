# PortDeCherbourg-PPE-
Client lourd Port de Cherbourg réalisé en C# sur Visual Studio

I – Présentation de la situation professionnelle 

Le port de Cherbourg est un port en eau profonde (13 mètre minimum d’eau). Bien protégé des vents, il possède la plus grande rade artificielle du monde. Il est accessible à toute heure, tous les jours de l’année, avec un passage direct sans écluse aux différents quais commerciaux.  Ses activités sont diverses : accueil de ferries (pour les liaisons transmanche), déchargement de fret (de marchandise), croisières et réparation navale. De par sa situation géographique et sa culture largement tournée vers le maritime, Cherbourg joue un rôle essentiel sur les marchés de la construction et de la réparation navale. Ce secteur d'activité représente en effet environ 3 500 emplois dans la communauté urbaine. Monsieur DUNARD est le gestionnaire du port de Cherbourg au travers d'une société d’économie mixte locale.  

Le système d’information est sous la responsabilité de son DSI (Directeur des Systèmes d’Information), M. Richard. Il est chargé, entre autres, avec l’aide de ses assistants, de la maintenance des solutions techniques d’accès (postes de travail, tablettes, smartphones), des serveurs et du réseau local. Le gestionnaire du port et le responsable informatique ont fait le choix en cas de besoins applicatifs spécifiques de faire appel à des ESN (Entreprise de Services du Numérique).  L’ESN Home Ingénierie a déjà été sollicitée pour la réalisation de plusieurs applications spécifiques dont fait partie le logiciel GEscale. Satisfaits des différentes prestations de l’ESN Home Ingénierie, le gestionnaire pense faire appel à cette société de service pour le développement de ses futures applications. 

GEscale est une application contenant des informations sur le trafic maritime.  

Mon travail lors de ce projet est de mettre à jour le formulaire Nouvelle Escale le formulaire permettra de créer une escale en prenant en compte différents facteurs : Le type de navire, les ports concernés, l’horodatages, les pilotes ainsi que le type de cargaisons de l’escale. 

 

II – Description de l’environnement de réalisation 

Environnement de développement  

TFS (Team Foundation Server) nous a permis la gestion des différentes versions de l’application ainsi que la répartition des taches de chaque membre l’équipe. 

Le formulaire a été créé sur Visual Studio en C# et Xaml pour pouvoir créer la forme du formulaire. Ce formulaire est associé à une base de données SQL Server.  Le développement de ce formulaire a été produit sur un réseau local. 

Environnement de production 

A terme l’application sera déployée dans l’environnement de production du port de Cherbourg. 

 

III – Production réalisées  

A partir de la documentation technique de l’application et de la base de données associée et du cahier des charges des modifications à apporter, notre travail a consisté à : 

    Faire une Maquette 

    Supprimer un type de cargaison 

     Modifier un type de cargaison 

    Créer un type de cargaison 

    Respecter l’architecture Modèle En couche pour l’implémentation des classes Métier, de la vue et de l’accès aux données 

    Créer un formulaire nouvelle Escale 

    Créer une classe d’accès aux données avec une méthode d’insertion permettant l’insertion d’une nouvelle Escale dans la base  

    Création d’un déclencheur permettant d’éviter les incohérences sur les dates d’escales dans la base de données 

    Élaborer et effectuer  des tests 
    
    ![maquette](https://github.com/khnaf/PortDeCherbourg-PPE-/blob/master/maquette.PNG)
